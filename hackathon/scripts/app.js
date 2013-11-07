function tap(e){
    var navTo = + e.sender.element[0].innerText.toLowerCase();
    app.navigate(navTo);
}

var app = new kendo.mobile.Application()