let navigationService = {
    cardSpace: document.getElementById("cardSpace"),

}

let apiService = {
    data: "",

}

let mentorsFound = document.getElementById("mentors-found")

let contactUs = document.getElementById("btnContactUs")

let closeBtn = document.getElementById("closebtn")

contactUs.addEventListener("click", function() {
    document.getElementById("mySidebar").style.width = "500px";
    document.getElementById("main").style.marginLeft = "500px";
});

closeBtn.addEventListener("click", function() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
});


let uiService = {

    printCards: (data) => {

        navigationService.cardSpace.innerHTML = "";
        data.map(item => {
            navigationService.cardSpace.innerHTML += `
            <div class="col-md-6 col-lg-4 item">
            <div class="box"> <a href="./profile${item.userId}.html"><img " class="rounded-circle"" src="${item.img}" alt="random photo">
                <h3 class="name"><a id="link" href="profile${item.userId}.html">${item.firstName} ${item.lastName}</h3>
                <p class="title">${item.skill}</p>
                <p class="description"> City: ${item.location}
                <br> Address: ${item.address}
                <br> Working Hours : ${item.workingHours} 
                <br> Price/Hour: ${item.price}$               
                <br> Rating :${item.rating}</p>
                <div class="social"><a href="#"><i class="fa fa-linkedin-square"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"></a></div>
            </div>
        </div>
            `


        })
    }
}

let filterService = {


    theFilter: () => {

        document.addEventListener(`change`, function() {
            let areaOfExpertiseCheckBoxes = document.querySelectorAll('input[name="areaOfExpertise"]:checked');
            let areaOfExpertise = [];
            areaOfExpertiseCheckBoxes.forEach(checkbox => areaOfExpertise.push(checkbox.value));

            let availabilityBoxes = document.querySelectorAll('input[name="availability"]:checked');
            let availability = [];
            availabilityBoxes.forEach(checkbox => availability.push(checkbox.value));

            let sessionBoxes = document.querySelectorAll('input[name="session"]:checked');
            let sessionFilter = [];
            sessionBoxes.forEach(checkbox => sessionFilter.push(checkbox.value));

            let typeOfConsultantBoxes = document.querySelectorAll('input[name="typeOfConsultant"]:checked');
            let typeOfConsultant = [];
            typeOfConsultantBoxes.forEach(checkbox => typeOfConsultant.push(checkbox.value));

            let priceHourBoxes = document.querySelectorAll('input[name="priceHour"]:checked');
            let priceHour = [];
            priceHourBoxes.forEach(checkbox => priceHour.push(checkbox.value));

            let areaOfExpertiseData = filterService.filterAreaOfExpertise(apiService.data, areaOfExpertise);
            let availabilityData = filterService.filterAvailability(areaOfExpertiseData, availability);
            let sessionData = filterService.filterSessionAvailability(availabilityData, sessionFilter);
            let timesData = filterService.filterTimesAvailability(sessionData, typeOfConsultant);
            let priceData = filterService.filterPriceHour(timesData, priceHour);


            uiService.printCards(priceData);
        })
    },

    filterAreaOfExpertise: (data, filters) => {

        if (filters.length == 0) {
            mentorsFound.innerText = `These are Our Consultants`;
            return data
        } else {
            data = data.filter(item => filters.includes(item.skill));
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }

    },

    filterAvailability: (data, filters) => {


        if (filters.length == 0) { return data }

        if (filters == "10") {
            data = data.filter(item => item.availability < 10);
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }
        if (filters == "20") {
            data = data.filter(item => item.availability >= 10 && item.availability <= 20); {
                mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
                return data
            }
        }


        if (filters == "30") {
            data = data.filter(item => item.availability >= 20 && item.availability <= 30); {
                mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
                return data
            }
        }

        if (filters == "40") {
            data = data.filter(item => item.availability > 30);
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }
        return data;

    },

    filterSessionAvailability: (data, filters) => {
        if (filters.length == 0) {
            return data
        } else {
            data = data.filter(item => filters.toString().includes(item.sessionAvailability.toString()));
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }
    },
    filterTimesAvailability: (data, filters) => {


        if (filters.length == 0) {
            return data
        } else {
            data = data.filter(item => filters.includes(item.typeOfConsultant));
            console.log(data.typeOfConsultant)
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }

    },
    filterPriceHour: (data, filters) => {

        if (filters.length == 0) { return data }

        if (filters == "0") {
            data = data.filter(item => item.price == "Free");
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }
        if (filters == "25") {
            data = data.filter(item => item.price <= 25); {
                mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
                return data
            }
        }


        if (filters == "50") {
            data = data.filter(item => item.price >= 25 && item.price <= 50); {
                mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
                return data
            }
        }

        if (filters == "100") {
            data = data.filter(item => item.price >= 50 && item.price <= 100);
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }

        if (filters == "110") {
            data = data.filter(item => item.price >= 100);
            mentorsFound.innerText = `Number of Consultants Found: ${data.length}`
            return data
        }
        counter = 0
        return data;

    },

}


let errorService = {}

//works with liveServer only!
async function GetData() {

    // let data = await fetch(`./lib/js/test.json`);

    let data = await fetch(`http://www.json-generator.com/api/json/get/bUZOYXyuCq?indent=2`);

    let theData = await data.json();

    apiService.data = theData
    uiService.printCards(apiService.data)
    filterService.theFilter();

}

GetData();