var officesData = [
    {officeId:1, name: "Sofia, BG" },
    {officeId:2, name: "Palo Alto, USA" },
    {officeId:3, name: "Boston, USA" },
    {officeId:4, name: "Houston, USA" },
    {officeId:5, name: "Munich, DE" },
];

var neighborhoodData = [
    {officeId: 1, id:1, name: "Lozenec" },
    {officeId: 1, id:2, name: "Mladost 1" },
    {officeId: 1, id:3, name: "Mladost 2" },
    {officeId: 1, id:4, name: "Strelbishte" },
    {officeId: 1, id:5, name: "Dyrventsa" },
    {officeId: 2, id:6, name: "Palo Alto 1" },
    {officeId: 2, id:7, name: "Palo Alto 2" },
    {officeId: 3, id:8, name: "Boston 1" },
    {officeId: 3, id:9, name: "Boston 2" },
    {officeId: 4, id:10, name: "Houston 1" },
    {officeId: 4, id:11, name: "Houston 2" },
    {officeId: 5, id:12, name: "Munich 1" },
    {officeId: 5, id:13, name: "Munich 2" },
];
    
var arrivalTimes = [
    {id:1, name: "7:30" },
    {id:2, name: "8:00" },
    {id:3, name: "8:30" },
    {id:4, name: "9:00" },
    {id:5, name: "9:30" },
    {id:6, name: "10:00" },
    {id:7, name: "10:30" },
];

var travelMatches = [
    {
        user: {
            name: "Kiril Nikolov",
            email: "kiril.nikolov@telerik.com",
            team:"Kendo UI",
            phone: "+359887405602"
        },
        travelInfo:{
            office: {officeId:1, name: "Sofia, BG" },
            neighborhood: {officeId: 1, id:1, name: "Lozenec" },
            arrivalTime: {id:1, name: "7:30" },
            rideType: 0,            
        }
    },{
        user:{
            name: "Viktor Bukurov",
            email: "viktor.bukurov@telerik.com",
            team:"Sitefinity",
            phone: "+359887549181"
        },
        travelInfo:{
            office: {officeId:1, name: "Sofia, BG" },
            neighborhood: {officeId: 1, id:1, name: "Lozenec" },
            arrivalTime: {id:4, name: "9:00" },
            rideType: 1,            
        }
    },{
        user:{
            name: "Georgi Mateev",
            email: "Georgi.Mateev@telerik.com",
            team:"Sitefinity",
            phone: "+359887546981"
        },
        travelInfo:{
            office: {officeId:1, name: "Sofia, BG" },
            neighborhood: {officeId: 1, id:1, name: "Lozenec" },
            arrivalTime: {id:5, name: "9:30" },
            rideType: 2,            
        }
    }

];

function getRideTypeDescription(type) {
    switch (type) {
        case 0:
            return "drive"; 
        case 1:
            return "ride"; 
        case 2:
            return "drive or ride";
    }
}

var carsViewModel = kendo.observable({
    offices: officesData,
    neighborhoods: neighborhoodData,
    arrivalTimes: arrivalTimes,
    travelMatches: travelMatches,  
    
    office: officesData[0],
    neighborhood: neighborhoodData[0],
    arrivalTime: arrivalTimes[0],
    rideType: 1,
    isEdit: false,
    
    getRideType: function() {
        var type = carsViewModel.get("rideType");
        return getRideTypeDescription (type);
    },
    
    checkIsEdit: function() {
        return carsViewModel.get("isEdit");
    },
    checkIsNotEdit: function() {
        return !carsViewModel.get("isEdit");
    },

    onRideSelected: function(e) {
        var buttonGroup = e.sender;
        var index = buttonGroup.current().index();
        carsViewModel.set("rideType", index);
    },
    
    onSubmit: function() {
        console.log(carsViewModel);
        carsViewModel.set("isEdit", false); 
    },
    
    onEdit: function() {
        console.log(carsViewModel);
        carsViewModel.set("isEdit", true); 
    },
    
});