import Popup from "./Popup.js";

export class PopupWithWasteList extends Popup {
    
    
    constructor(popupSelector) {
        super(popupSelector);
        this._title = this._popup.querySelector(".popup__title");
    }
    
    setEventListeners(popupWaste) {
        super.setEventListeners()
        this._popup.querySelector(".popup__button-add").addEventListener('click', (event) => {
            event.preventDefault();
            popupWaste.open();
            //this._handleFormSubmit(this._getInputValues());
            //this.close()

        })
    }

    open() {
        //this._title.textContent = title;
        super.open()
    }

    set Title(text) {
        this._title.textContent = text;
    }

    // hide(){
    //     super.hide();
    // }
    // show(){
    //     super.show();
    // }

}