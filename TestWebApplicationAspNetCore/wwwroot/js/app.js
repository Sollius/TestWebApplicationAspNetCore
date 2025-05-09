﻿class Point {
    constructor(allLayerPoints, id, x, y, radius, color, comments = []) {
        this.id = id;
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.color = color;
        this.comments = comments;
        this.shape = null;
    }

    static async create(allLayerPoints, x, y, radius, color) {
        const response = await fetch(`/api/v1/points`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                x: x,
                y: y,
                radius: radius,
                color: color
            })
        });

        if (response.ok) {
            console.log(`Создана точка на (${x.toFixed(0)}, ${y.toFixed(0)})`);
        } else {
            alert('Ошибка создания');
            return;
        }

        const createdPoint = await response.json();
        return new Point(allLayerPoints, createdPoint.id, createdPoint.x, createdPoint.y, createdPoint.radius, createdPoint.color, createdPoint.comments);
    }

    draw(layer) {
        this.shape = new Konva.Circle({
            x: this.x,
            y: this.y,
            radius: this.radius,
            fill: this.color,
            draggable: true
        });

        this.shape.on('dblclick', async () => {
            await this.delete(layer);
        });

        this.shape.on('dragend', async () => {
            this.x = this.shape.x();
            this.y = this.shape.y();
            await this.update();
        });

        this.shape.on('click tap', () => {
            openEditPointModal(this);
        });

        layer.add(this.shape);
    }

    async delete(layer) {
        if (!confirm('Удалить эту точку?')) return;

        const response = await fetch(`/api/v1/points/${this.id}`, {
            method: 'DELETE'
        });

        var thisPoint = this;
        if (response.ok) {
            var arrayToDestroy = [];
            layer.children.forEach(c => {
                if (c.attrs.pointId == thisPoint.id) {
                    arrayToDestroy.push(c);
                }
            })

            while (arrayToDestroy[0]) {
                arrayToDestroy[0].destroy();
                arrayToDestroy.splice(0, 1);
            }
            this.shape.destroy();
        } else {
            alert('Ошибка удаления');
        }
    }

    async update() {
        const updatedPoint = {
            id: this.id,
            x: this.x,
            y: this.y,
            radius: this.radius,
            color: this.color,
            comments: this.comments
        };

        const response = await fetch(`/api/v1/points/${this.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedPoint)
        });

        if (!response.ok) {
            alert('Ошибка обновления');
        }
    }

    async addComment(commentText, backgroundColor) {
        const commentData = {
            text: commentText,
            backgroundColor: backgroundColor
        };

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(commentData)
        };

        const apiUrl = `/api/v1/comments/${this.id}`;

        const response = await fetch(apiUrl, requestOptions);

        if (response.ok) {
            const newComment = await response.json();
            this.comments.push(newComment);
            return newComment.id;
        } else {
            alert('Ошибка добавления комментария');
            return -1;
        }
    }
}