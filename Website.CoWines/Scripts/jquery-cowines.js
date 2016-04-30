$(function () {
    $('.navbar').sticky({
        topSpacing: 0
    });

    $('.btn-add-to-cart').click(function (e) {
        e.preventDefault();
        var catalogItem = $(this).parent().parent().parent();
        addToCart(catalogItem.attr('id'), 1);
    });

    $('.btn-add-twelve-to-cart').click(function (e) {
        e.preventDefault();
        var catalogItem = $(this).parent().parent().parent();
        addToCart(catalogItem.attr('id'), 12);
    })
});

var addToCart = function (id, quantity) {
    var cookieName = 'shoppingcart';
    var currentShoppingCartDetails = getCookie(cookieName);
    var updatedShoppingCartDetails = currentShoppingCartDetails + 'item=' + id + ':' + quantity + ',';
    createCookie('shoppingcart', updatedShoppingCartDetails);

    showToast('Added to cart');
};

var getCookie = function (cookieName) {
    var name = cookieName + '=';
    var cookieSplits = document.cookie.split(';');
    for (var i = 0; i < cookieSplits.length; i++) {
        var cookie = cookieSplits[i];
        while (cookie.charAt(0) == ' ') cookie = cookie.substring(1);
        if (cookie.indexOf(name) == 0) return cookie.substring(name.length, cookie.length);
    }

    return '';
};

var checkCookie = function (cookieName) {
    var cookie = getCookie(cookieName);
    if (cookie == "") return false;

    return true;
};

var createCookie = function (cookieName, cookieValue) {
    document.cookie = cookieName + '=' + cookieValue + '; expires=' + addDays(30) + ';path=/;';
};

var addDays = function (days) {
    var today = new Date();
    var futureDate = new Date();

    futureDate.setDate(today.getDate() + days);

    return futureDate;
}

var showToast = function (message) {
    toastr['success'](message);

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": "toast-top-full-width",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}