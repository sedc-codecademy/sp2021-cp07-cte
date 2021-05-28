let navigationService = 
{
    cardSpace : document.getElementById("cardSpace"),
   
}

let apiService  = {
        data : "",
        
}

let uiService  = {
    printCards : (data)=>{
        navigationService.cardSpace.innerHTML = "";
        data.map(item => {
            navigationService.cardSpace.innerHTML += `
            <div class="col-md-6 col-lg-4 item">
            <div class="box"><img class="rounded-circle" src="" alt="no photo">
                <h3 class="name">${item.firstName} ${item.lastName}</h3>
                <p class="title">${item.skill}</p>
                <p class="description"> City: ${item.location} Address: ${item.address}</p>
                <p class="description"> Rating :${item.rating}   Working Hours : ${item.workingHours}</p>
                <div class="social"><a href="#"><i class="fa fa-facebook-official"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"><i class="fa fa-instagram"></i></a></div>
            </div>
        </div>
            `
        })
    }
}

let filterService = {
    
    
    theFilter : () => {
        document.addEventListener(`change`, function(){
            let skillCheckBoxes = document.querySelectorAll('input[name="skills"]:checked');
            let skills =[];
            skillCheckBoxes.forEach(checkbox => skills.push(checkbox.value));
            let daysAvailableBoxex = document.querySelectorAll('input[name="daysAvailable"]:checked');
            let daysAvailable = [];
            daysAvailableBoxex.forEach(checkbox => daysAvailable.push(checkbox.value));
            let sessionBoxes = document.querySelectorAll('input[name="session"]:checked');
            let sessionFilter = [];
            sessionBoxes.forEach(checkbox => sessionFilter.push(checkbox.value));
            let skillData = filterService.filterSkills(apiService.data , skills);
            let daysData = filterService.filterDaysAvailable(skillData , daysAvailable);
            let sessionData = filterService.filterSessionAvailability(daysData , sessionFilter);
            uiService.printCards(sessionData);
    })},
    filterSkills : (data , filters) =>{
        if(filters.length == 0){ return data}
        return data.filter(item => filters.includes(item.skill));
    },
    filterDaysAvailable : (data , filters) =>{
        if(filters.length == 0){ return data}
        return data.filter(item => item.daysAvailable.some(r=> filters.indexOf(r) >= 0))
    },
    filterSessionAvailability : (data , filters) =>{
        if(filters.length == 0){ return data}
        return data.filter(item => filters.includes(item.sessionAvailability));
    },
  

}

let errorService = {}

//works with liveServer only!
async function GetData(){
   let data = await fetch(`./lib/js/test.json`);
   let theData = await data.json();
  
apiService.data = theData
    uiService.printCards(apiService.data)
    filterService.theFilter();
    
}

GetData();



