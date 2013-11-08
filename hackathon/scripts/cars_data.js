var timeOptionsDS = [
    {id:1, name: "7:30" },
    {id:2, name: "8:00" },
    {id:3, name: "8:30" },
    {id:4, name: "9:00" },
    {id:5, name: "9:30" },
];

var travelMatches = [
    {
        user: {
            name: "Todd Anglin",
            email: "todd.anglin@telerik.com",
            team:"VP",
            phone: "+1564753247",
            imageUrl:"images/people/todd-anglin.jpg"
        },
        travelInfo:{
            office: {officeId:1, name: "Sofia, BG" },
            neighborhood: {officeId: 1, id:1, name: "Lozenec" },
            leaveTime: {id:1, name: "7:30" },
            rideType: 0,            
        }
    },{
        user:{
            name: "Doug Laird",
            email: "doug.laird@telerik.com",
            team:"CMO",
            phone: "+155584756",
            imageUrl:"images/people/doug-laird.jpg"
        },
        travelInfo:{
            office: {officeId:1, name: "Sofia, BG" },
            neighborhood: {officeId: 1, id:1, name: "Lozenec" },
            leaveTime: {id:4, name: "9:00" },
            rideType: 1,            
        }
    },{
        user:{
            name: "Petya Bogdanova",
            email: "petya.bogdanova@telerik.com",
            team:"Sales",
            phone: "+359889147648",
            imageUrl:"images/people/petya-bogdanova.jpg"
        },
        travelInfo:{
            office: {officeId:1, name: "Sofia, BG" },
            neighborhood: {officeId: 1, id:1, name: "Lozenec" },
            leaveTime: {id:5, name: "9:30" },
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

var officesDS = new kendo.data.DataSource({
    type: 'everlive',
    transport: {
        typeName: 'Offices'
    },
    schema: {
        model: {
            id: Everlive.idField,
            fields: {
                officeId: Everlive.idField,
                name: "Name"
            }
        }
    }
});

var districtsDS = new kendo.data.DataSource({
    type: 'everlive',
    transport: {
        typeName: 'Districts'
    },
    schema: {
        model: {
            id: Everlive.idField,
            fields: {
                officeId: "Office",
                name: "Name"
            }
        }
    }
});

var carsViewModel = kendo.observable({
    offices: officesDS,
    districts: districtsDS,
    timeOptions: timeOptionsDS,
    travelMatches: travelMatches,  
    
    office: null,
    dsitrict: null,
    leaveTime: null,
    rideType: 1,
    isEdit: true,
    
    getRideType: function() {
        var type = carsViewModel.get("rideType");
        return getRideTypeDescription(type);
    },
    
    checkIsEdit: function() {
        return carsViewModel.get("isEdit");
    },
    checkIsNotEdit: function() {
        return !carsViewModel.get("isEdit");
    },

    onDistrictChange: function() {
        var district = this.dataSource.get(this.value());
        carsViewModel.set("district", district); 
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
    
    onFilterSelected: function(e) {
        var buttonGroup = e.sender;
        var index = buttonGroup.current().index();
        if (index === 0) {
            carsViewModel.set("travelMatches", travelMatches);
        }
        else {
            carsViewModel.set("travelMatches", travelMatches.slice(2, 3));
        }
    }
});