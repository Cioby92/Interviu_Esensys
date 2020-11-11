function display() {
    var e = document.getElementById("country_input").value;
    updateUrl("?country=" + e);
    var country_input = e;
    var how = buildIbans(country_input);
    document.getElementById("demo").innerHTML = how;
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function updateUrl(url_extension) {
    window.history.pushState('page2', 'Title', '/' + url_extension);
}


$('document').ready(function () {

    var sel = document.getElementById('country_input');
    for (var i = 0; i < countries.length; i++) {
        var opt = document.createElement('option');
        opt.innerHTML = countries[i].replace(/_/g, " ");
        opt.value = countries[i];
        opt.id = "country_" + countries[i];
        sel.appendChild(opt);
    }
    var active_country = null;
    if (getParameterByName("country") === null) {
        active_country = "Netherlands";
        updateUrl("?country=Netherlands");
    }
    else {
        active_country = getParameterByName("country");
    }
    var x = document.getElementById("demo").innerHTML = buildIbans(active_country);
    document.getElementById("country_" + active_country).selected = true;
});