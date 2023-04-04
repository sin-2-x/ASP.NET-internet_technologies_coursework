// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

let months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
let calendar = document.querySelector(".calendar");

let popupWasteList = document.querySelector(".popup_type_waste-list");
popupWasteList.querySelector(".popup__dackground").addEventListener('click', closePopupWasteList);

let popupCurrentWaste = document.querySelector(".popup_type_waste");
popupCurrentWaste.querySelector(".popup__dackground-transparent").addEventListener('click', closePopupCurrentWaste);

let dropdownMenuButtonYear = document.querySelector("#dropdownMenuButtonYear");
dropdownMenuButtonYear.addEventListener('click', setYearValues);
let dropdownMenuButtonMonth = document.querySelector("#dropdownMenuButtonMonth");
dropdownMenuButtonMonth.addEventListener('click', setMonthValues);


let montDate = new Date(2023, 2);

function setYearValues() {
    for (let year = new Date().getFullYear(); year >= 1920; year--) {
        let options = document.createElement("div");
        options.onclick = change;
        options.classList.add("dropdown-item");
        document.getElementById("dropdownMenuUlYear").appendChild(options).innerHTML = year;
        document.getElementById("dropdownMenuUlYear").appendChild(options).value = year;
    }
    new SimpleBar(document.querySelector("#dropdownMenuUlYear"));
    this.removeEventListener('click', setYearValues);
}
function setMonthValues() {
    for (let month = 0; month < months.length; month++) {
        let options = document.createElement("div");
        options.onclick = change;
        options.classList.add("dropdown-item");
        document.getElementById("dropdownMenuUlMonth").appendChild(options).innerHTML = months[month];
        document.getElementById("dropdownMenuUlMonth").appendChild(options).value = month;
    }
    new SimpleBar(document.querySelector("#dropdownMenuUlMonth"));
    this.removeEventListener('click', setMonthValues);
}
let wastesOfOneDay;
async function PopupWasteListOpen() {

    
    let dayNum = this.children[0].firstChild.wholeText;
    popupWasteList.querySelector(".popup__title").textContent=`${dayNum}.${montDate.getMonth() + 1}.${montDate.getFullYear()}`;
    popupWasteList.classList.add("popup_opened");
    
     wastesOfOneDay = await GetWastesOfDay(dayNum);
    let html = [];
    
    for (let i = 0; i < wastesOfOneDay.length; i++) {
        let waste = document.createElement("div");

        waste.classList.add("popup__watelist_item");
        waste.setAttribute("id", i);
        waste.innerHTML =`
                <div class="align-self-center">${wastesOfOneDay[i].value}</div>
                <div class="align-self-center">${wastesOfOneDay[i].category}</div>`;
        waste.onclick=PopupCurrentWasteOpen;
        html.push(waste);
    }
   
    let waistsHTML = popupWasteList.querySelector(".waists_list");
    waistsHTML.innerHTML = "";
    html.forEach(waste => {
        waistsHTML.appendChild(waste);
    });
    
        new SimpleBar(waistsHTML);
        
    
}

function PopupCurrentWasteOpen(waste){
    popupCurrentWaste.classList.add("popup_opened");
 

}

function closePopupWasteList(){

    popupWasteList.classList.remove("popup_opened");
}

function closePopupCurrentWaste(){

    popupCurrentWaste.classList.remove("popup_opened");
}




async function GetWastesByDays() {
    //Находим эелмент календарь
    
    //добавляем эффект загрузки
    SetCalendarLoader();
    
    let num = montDate.getDay();

    // отправляет запрос и получаем ответ
    const response = await fetch(`Waste/GetWastes?year=${montDate.getFullYear()}&month=${montDate.getMonth() + 1}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    // если запрос прошел нормально
    if (response.ok === true) {
        // получаем данные
        const wastes = await response.json();
        let html = [];
        for (let i = 1; i < num; i++) {
            let badDay = document.createElement("div");
            badDay.classList.add("calendar__day","calendar__day-bad_day");
            
            html.push(badDay);
        }

        for (let i = 0; i < wastes.length; i++) {
            let goodDay = document.createElement("div");

            goodDay.classList.add("calendar__day", "calendar__day-good_day");
            goodDay.innerHTML =`
                    <div class="calendar__day_text calendar__day_text-top">${i + 1}</div>
                    <div class="calendar__day_text calendar__day_text-bottom">${wastes[i]}</div>`;
            goodDay.onclick = PopupWasteListOpen;

            html.push(goodDay);
        }
        for (let i = 0; i < 35 - num + 1 - wastes.length; i++) {
            let badDay = document.createElement("div");
            badDay.classList.add("calendar__day","calendar__day-bad_day");
            
            html.push(badDay);
        }

        RemoveCalendarLoader();

        calendar.innerHTML = "";
        html.forEach(day => {
            calendar.appendChild(day);
        });
    }

}

async function GetWastesOfDay(dayNum) {
    const response = await fetch(`Waste/GetWastesOfOneDay?year=${montDate.getFullYear()}&month=${montDate.getMonth() + 1}&day=${dayNum}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        return await response.json();
    }

}





function SetCalendarLoader(){
    for (let i = 0; i < 35; i++) {
        calendar.appendChild(document.createElement("div"));
        calendar.lastChild.classList.add("calendar__day","calendar__day-bad_day");
    }
    
    calendar.classList.add("calendar_loader");
}

function RemoveCalendarLoader(){
    calendar.classList.remove("calendar_loader");
}

GetWastesByDays();
