$(document).ready(function () {
    var subscribeBtn = $('#subscription-button');
    subscribeBtn.click(function (e) {
        e.preventDefault();
        e.stopPropagation();

        var email = $('#email').val();
        var city = $('title').text().split(' - ')[0];

        if (!isValid(email)) {
            alert("Check your email");
            return;
        }
        if (city.length == 0) {
            alert("City is not defined");
            return;
        }

        $.ajax({
            url: "/Cities/Subscribe",
            type: "POST",
            dataType: "json",
            data: { Email: email, City: city },
            success: function (data) {
                if (data.statusCode === 200)
                    alert("Ajax responded with success");
                else
                    alert("Ajax responded with error");
                console.log(data);
            }
        });
    });
})