let navigationService = {
    cardSpace: document.getElementById("cardSpace"),

}

let apiService = {
    data: "",

}

let uiService = {
    printCards: (data) => {
        navigationService.cardSpace.innerHTML = "";
        data.map(item => {
            navigationService.cardSpace.innerHTML += `
            <div class="col-md-6 col-lg-4 item">
            <div class="box"> <a href="./profile.html"><img " class="rounded-circle"" src="${item.img}" alt="random photo">
                <h3 class="name"><a id="link" href="profile.html">${item.firstName} ${item.lastName}</h3>
                <p class="title">${item.skill}</p>
                <p class="description"> City: ${item.location}
                <br> Address: ${item.address}
                <br> Working Hours : ${item.workingHours} 
                <br> Price/Hour: ${item.price}$               
                <br> Rating :${item.rating}</p>
                <div class="social"><a href="#"><i class="fa fa-facebook-official"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"><i class="fa fa-instagram"></i></a></div>
            </div>
        </div>
            `


        })
    }
}

let filterService = {


    theFilter: () => {
        document.addEventListener(`change`, function() {
            let skillCheckBoxes = document.querySelectorAll('input[name="skills"]:checked');
            let skills = [];
            skillCheckBoxes.forEach(checkbox => skills.push(checkbox.value));

            let daysAvailableBoxes = document.querySelectorAll('input[name="daysAvailable"]:checked');
            let daysAvailable = [];
            daysAvailableBoxes.forEach(checkbox => daysAvailable.push(checkbox.value));

            let sessionBoxes = document.querySelectorAll('input[name="session"]:checked');
            let sessionFilter = [];
            sessionBoxes.forEach(checkbox => sessionFilter.push(checkbox.value));

            let timesAvailableBoxes = document.querySelectorAll('input[name="timeAvailable"]:checked');
            let timeAvailable = [];
            timesAvailableBoxes.forEach(checkbox => timeAvailable.push(checkbox.value));

            let priceHourBoxes = document.querySelectorAll('input[name="priceHour"]:checked');
            let priceHour = [];
            priceHourBoxes.forEach(checkbox => priceHour.push(checkbox.value));

            let skillData = filterService.filterSkills(apiService.data, skills);
            let daysData = filterService.filterDaysAvailable(skillData, daysAvailable);
            let sessionData = filterService.filterSessionAvailability(daysData, sessionFilter);
            let timesData = filterService.filterTimesAvailability(sessionData, timeAvailable);
            let priceData = filterService.filterPriceHour(timesData, priceHour);


            uiService.printCards(priceData);
        })
    },
    filterSkills: (data, filters) => {
        if (filters.length == 0) { return data }
        return data.filter(item => filters.includes(item.skill));
    },
    filterDaysAvailable: (data, filters) => {
        if (filters.length == 0) { return data }
        return data.filter(item => item.daysAvailable.some(r => filters.indexOf(r) >= 0))
    },

    filterSessionAvailability: (data, filters) => {
        if (filters.length == 0) { return data }
        return data.filter(item => filters.toString().includes(item.sessionAvailability.toString()));
    },
    filterTimesAvailability: (data, filters) => {
        if (filters.length == 0) { return data }
        return data.filter(item => filters.includes(item.workingHours));
    },
    filterPriceHour: (data, filters) => {

        if (filters.length == 0) { return data }

        if (filters == "0") return data.filter(item => item.price == "Free");

        if (filters == "25") return data.filter(item => item.price <= 25);

        if (filters == "50") return data.filter(item => item.price >= 25 && item.price <= 50);

        if (filters == "100") return data.filter(item => item.price >= 50 && item.price <= 100);

        if (filters == "110") return data.filter(item => item.price >= 100);

        return data;

    },

}

let errorService = {}

//works with liveServer only!
async function GetData() {

    // let data = await fetch(`./lib/js/test.json`);

    let data = await fetch(`http://www.json-generator.com/api/json/get/ckFMBtEmxu?indent=2`);
    let theData = await data.json();

    apiService.data = theData
    uiService.printCards(apiService.data)
    filterService.theFilter();

}

GetData();