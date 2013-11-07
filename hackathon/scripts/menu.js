var el = new Everlive({
    apiKey: 'tkDRCGTsZLcnEtsZ'
});

function setMenu() {
    var data = Everlive.$.data('Menu');
    var date = new Date();
    data.create({
        'Food' : {
            soup:[
                {name:"Leshta Soup", price:3},
                {name:"Potato Soup", price:3}
            ],
            salad:[
                {name:"Shopska Salad", price:3.5},
                {name:"Caprese", price:4}
            ],
            dessert:[
                {name:"Milk rice", price:1},
                {name:"Pumpkin pie", price:3.5},
            ],
            main:[
                {name:"Friccadeli", price:1},
                {name:"Salmon with cream", price:7.5},
                {name:"Broccoli with cheese", price:3.9},
                {name:"Rice and mushrooms", price:3},
            ]
        },
        'Date': date
    },
                function(data) {
                    console.log(JSON.stringify(data));
                },
                function(error) {
                    alert(JSON.stringify(error));
                });
}

function parseMenu(food, container) {
    for (var i = 0; i < food.length; i++) {
        var item = "<li>" + food[i].name + "<span>" + food[i].price + "</span></li>";
        container.append(item);
    }
}

function getMenu() {
    var data = Everlive.$.data('Menu');
    data.get()
    .then(function(data) {
        var soups = data.result[0].Food.soup;
        var mains = data.result[0].Food.main;
        var desserts = data.result[0].Food.dessert;
        var salad = data.result[0].Food.salad;
        parseMenu(soups,$('#soups'));
        parseMenu(mains,$('#main-courses'));
        parseMenu(salad,$('#salads'));
        parseMenu(desserts,$('#desserts'));
    },
          function(error) {
              alert(JSON.stringify(error));
          });
}