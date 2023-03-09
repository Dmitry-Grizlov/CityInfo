$(document).ready(function () {
    $(document).mouseup(function (e) {
        var container = $('#autocomplete');
        if (!container.is(e.target) && container.has(e.target).length === 0)
            container.hide();
    });

    var input = $("#city-input[type='text']");
    input.keyup(function () {
        var value = input.val();
        var list = $('#autocomplete');
        if (value.length < 3) {
            list.empty();
            list.hide();
            return;
        }
        $.ajax({
            url: "/Cities/CitiesList",
            type: "POST",
            dataType: "json",
            data: { input: value },
            success: function (data) {
                citiesListSuccess(list, data.data);
            }
        })
    });
});

function citiesListSuccess(list, data) {
    list.empty()
    if (data.results == null || data.results.length === 0) {
        list.hide();
        return;
    }

    var elData;
    data.results.forEach(element => {
        elData = element.name + ', ' + element.admin1 + ', ' + element.country;
        url = window.location.origin + '/cities/index?coordinates=' + element.name + '|' + element.latitude + '|' + element.longitude;
        list.append('<li class="autocomplete-list-item"><a href="' + url + '">' + elData + '</a></li>');
    });

    list.show();
}

function isValid(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}