function navPeople() {
    app.navigate("views/people.html");
}
function navCars() {
    app.navigate("views/cars.html");
}
function navMassages() {
    app.navigate("views/massages.html");
}
function navLeaves() {
    app.navigate("views/leaves.html");
}
function navMenu() {
    app.navigate("views/menu.html");
}

function mobileListViewFiltering() {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: function(o){
                o.success(peopleData);
            }
        },
        sort: {
            field: "name",
            dir: "asc"
        },
        pageSize: 50
    });

    $("#filterable-listview").kendoMobileListView({
        dataSource: dataSource,
        template: $("#mobile-listview-filtering-template").text(),
        filterable: {
            field: "name",
            operator: "startswith"
        },
        endlessScroll: true
    });
}

var app = new kendo.mobile.Application()