// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

let months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
let calendarDate = {};
let popup = document.querySelector(".popup");

let dropdownMenuButtonYear = document.querySelector("#dropdownMenuButtonYear");
dropdownMenuButtonYear.addEventListener('click', setYearValues);
let dropdownMenuButtonMonth = document.querySelector("#dropdownMenuButtonMonth");
dropdownMenuButtonMonth.addEventListener('click', setMonthValues);


async function popupOpen() {
    popup.classList.add("popup_opened");



    let montDate = new Date(2023, 2);
    const response = await fetch(`Waste/GetWastesOfOneDay?year=${montDate.getFullYear()}&month=${montDate.getMonth() + 1}&day=27`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        // получаем данные
        const wastes = await response.json();
        let html = [];

        for (let i = 0; i < wastes.length; i++) {
            let goodDay = document.createElement("div");

            goodDay.classList.add("calendar__day", "calendar__day-good_day");
            goodDay.innerHTML =`
                    <div class="calendar__day_text calendar__day_text-top">${wastes[i].value} ${wastes[i].category} ${wastes[i].comment}</div>`;
            goodDay.onclick = popupOpen;

            html.push(goodDay);
        }
       
        let waistsHTML = document.querySelector(".waists_list");
        waistsHTML.innerHTML = "";
        html.forEach(day => {
            waistsHTML.appendChild(day);
        });
    }
}

async function GetWastes() {
    //Находим эелмент календарь
    let calendar = document.querySelector(".calendar");
    //добавляем эффект мерцания
    calendar.classList.add("calendar_loader");

    //находим месяц
    let montDate = new Date(2023, 2);
    let num = montDate.getDay();


    let loader_html = '';

    for (let i = 0; i < 35; i++) {
        loader_html +=
            `<div class="calendar__day calendar__day-bad_day">
                <div class="calendar__day_text calendar__day_text-top"></div>
                <div class="calendar__day_text calendar__day_text-bottom"></div>
            </div>`;
    }
    calendar.innerHTML = loader_html;

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
            badDay.innerHTML = `
                <div class="calendar__day_text calendar__day_text-top"></div>
                <div class="calendar__day_text calendar__day_text-bottom"></div>
            `;
            html.push(badDay);
        }

        for (let i = 0; i < wastes.length; i++) {
            let goodDay = document.createElement("div");

            goodDay.classList.add("calendar__day", "calendar__day-good_day");
            goodDay.innerHTML =`
                    <div class="calendar__day_text calendar__day_text-top">${i + 1}</div>
                    <div class="calendar__day_text calendar__day_text-bottom">${wastes[i]}</div>`;
            goodDay.onclick = popupOpen;

            html.push(goodDay);
        }
        for (let i = 0; i < 35 - num + 1 - wastes.length; i++) {
            let badDay = document.createElement("div");
            badDay.classList.add("calendar__day","calendar__day-bad_day");
            badDay.innerHTML = `<div class="calendar__day_text calendar__day_text-top"></div>
                <div class="calendar__day_text calendar__day_text-bottom"></div>`;
            html.push(badDay);
        }

        calendar.classList.remove("calendar_loader");

        calendar.innerHTML = "";
        html.forEach(day => {
            calendar.appendChild(day);
        });
    }

}



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



function change(e) {
    alert(this.value);
}


GetWastes();



