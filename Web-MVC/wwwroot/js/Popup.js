export default class Popup {
    constructor(popupSelector) {
        console.log(popupSelector);
        this._popup = document.querySelector(popupSelector);
        this._container = this._popup.querySelector(".popup__container");
        this._handleEscClose = this._handleEscClose.bind(this);
    }
    open() {
        this._popup.classList.add('popup_opened');
        document.addEventListener('keydown', this._handleEscClose)
    }
    close() {
        this._popup.classList.remove('popup_opened');
        document.removeEventListener('keydown', this._handleEscClose)
    }

    // hide() {
    //     this._container.classList.add("invisible");
    // }
    // show() {
    //     this._container.classList.remove("invisible");
    // }

    _handleEscClose(event) {
        if (event.key === 'Escape') {
            this.close()
        }
    }
    setEventListeners() {
        //this._popup.querySelector(".popup__dackground").addEventListener('click', this.close);//(event)=> {
        this._popup.querySelector(".popup__dackground").addEventListener('click', () => { this.close() })
    }
}