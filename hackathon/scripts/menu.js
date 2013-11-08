function backToMainMenu(){
    app.navigate("index.html");
}

function parseMenu(food, container) {
    container.html("");
    for (var i = 0; i < food.length; i++) {
        var price;
        if (food[i].price == 0) 
            price = "Free";
        else
            price = food[i].price.toFixed(2) + ' лв.';
        
        var weight = (food[i].hasOwnProperty('weight')) ? food[i].weight + 'гр.' : '';
        
        var item = "<li class='menu-item'><span class='food-name'>" + food[i].name + "</span> <span class='food-weight'>" +
           weight + "</span> <span class='food-price'>" + price + "</span></li>";
        container.append(item);
    }
}

function getMenu() {
    var now = new Date();
    var startDate = new Date(now.getFullYear(), now.getMonth(), now.getDate());
    var endDate = new Date(now.getFullYear(), now.getMonth(), now.getDate() + 1);
    
    var query = new Everlive.Query();
    query.where().gte('Date', startDate).lt('Date', endDate).done();
    
    var data = Everlive.$.data('Menu');
    data.get(query)
    .then(function(data) {
        if (data.count == 0) {
            var date = kendo.toString(now, "dddd MMMM d, yyyy");
            navigator.notification.alert("Sorry, no menu is available for today.", backToMainMenu,  date);
        }
        else {
            var soups = data.result[0].Food.soups;
            var salad = data.result[0].Food.salads;
            var mains = data.result[0].Food.mains;
            var desserts = data.result[0].Food.desserts;
            
            parseMenu(soups,$('#soups'));
            parseMenu(salad,$('#salads'));
            parseMenu(mains,$('#main-courses'));
            parseMenu(desserts,$('#desserts'));
            
            $('#menu-list').show();
        }
    },
    function(error) {
        alert(JSON.stringify(error));
    });
}

function initializeMenuView() {
    $('#menu-list').hide();
    
    var now = new Date();
    $('#menu-date').html(kendo.toString(now, "dddd MMMM d, yyyy" ));
    getMenu();
}