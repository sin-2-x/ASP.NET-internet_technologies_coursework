export default class Api {
    constructor({ url, token }) {
        this._url = url;
        this._token = token;
    }

    async _checkData(res) {
        if (!res.ok) {
            return Promise.reject(`Ошибка: ${res.status}`);
        }
        return await res.json();
    }

    async getWaists(montDate) {
        const response = await fetch(`Waste/GetWastes?year=${montDate.getFullYear()}&month=${montDate.getMonth() + 1}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        return await this._checkData(response);
    }

    // getInitialCards() {
    //     return fetch(`${this._url}/cards`, {
    //         method: 'GET',
    //         headers: {
    //             authorization: this._token
    //         }
    //     })
    //         .then(this._checkData);
    // }

    // // getInitialData() {
    // //     return Promise.all([this.getUserInfo(), this.getInitialCards()]);
    // // }

    // setUserInfo(user) {
    //     return fetch(`${this._url}/users/me`, {
    //         method: 'PATCH',
    //         headers: {
    //             authorization: this._token,
    //             'Content-Type': 'application/json'
    //         },
    //         body: JSON.stringify({
    //             name: user.name,
    //             about: user.about
    //         })
    //     })
    //         .then(this._checkData);
    // }

    async addWaste(waste, date) {
        resp = await fetch(`Waste/AddWasteToDay?date=` + date, {
            method: 'POST',
            headers: {
                //             authorization: this._token,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(waste)
        });
        return this._checkData(resp);
    }

    // deleteCard (id) {
    //     return fetch(`${this._url}/cards/${id}`, {
    //         method: 'DELETE',
    //         headers: {
    //             authorization: this._token
    //         }
    //     })
    //         .then(this._checkData);

    // }

    // setLike(id) {
    //     return fetch(`${this._url}/cards/likes/${id}`, {
    //         method: 'PUT',
    //         headers: {
    //             authorization: this._token
    //         }
    //     })
    //         .then(this._checkData);
    // }

    // deleteLike(id) {
    //     return fetch(`${this._url}/cards/likes/${id}`, {
    //         method: 'DELETE',
    //         headers: {
    //             authorization: this._token
    //         }
    //     })
    //         .then(this._checkData);
    // }

    // updateAvatar(data) {
    //     return fetch(`${this._url}/users/me/avatar`, {
    //         method: 'PATCH',
    //         headers: {
    //             authorization: this._token,
    //             'Content-Type': 'application/json'
    //         },
    //         body: JSON.stringify({
    //             avatar: data.avatar
    //         })
    //     })
    //         .then(this._checkData);
    // }
}

