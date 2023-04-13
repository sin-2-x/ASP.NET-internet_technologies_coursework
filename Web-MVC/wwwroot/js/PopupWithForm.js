import Popup from "./Popup.js";
export class PopupWithForm extends Popup {
    parent

    constructor({ popupSelector, handleFormSubmit }) {
        super(popupSelector);
        this._handleFormSubmit = handleFormSubmit;
        this._inputList = this._popup.querySelectorAll('.popup__input');
        this._popupForm = this._popup.querySelector('.popup__current_waste')
    }

    _getInputValues() {
        this.formValues = {};
        this._inputList.forEach(input => this.formValues[input.name] = input.value);
        this.formValues['id'] = this.idWaste;
        return this.formValues;
    }
    _setInputValues(values) {
        this._inputList.forEach(input => {
            if (input.name === "value")
                input.value = values.value;
            else if (input.name === "category")
                input.value = values.category;
            else if (input.name === "comment")
                input.value = values.comment;
            
        });
        
        this.idWaste = values.id; //Создали заметку об id
    }

    setEventListeners() {
        super.setEventListeners()
        this._popup.addEventListener('submit', (event) => {
            event.preventDefault();
            this._handleFormSubmit(this._getInputValues(), this.parent._title.textContent);
            this.close()

        })
    }
    // resetSubmit(submitAction) {
    //     this._handleFormSubmit = submitAction;
    // }

    close() {

        super.close()
        this._popupForm.reset();
        this.parent.open();
    }

    set Parent(item) {
        this.parent = item;
    }

    open(wasteItem) {
        //получаем трату которую нужно отразить в форме
        if (typeof wasteItem !== 'undefined')
            this._setInputValues(wasteItem);
        else
            this.idWaste = null;
        super.open();
        this.parent.close();
    }

    // setMessage(span){
    //     this._popupForm.querySelector('.popup__submit-button').textContent = span;
    // }
}
