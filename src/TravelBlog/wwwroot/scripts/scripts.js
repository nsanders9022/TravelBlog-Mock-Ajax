$(document).ready(function () {
    $('.hello-ajax').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: $(this).data('request-url'),
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });
    $('.sum').click(function () {
        $.ajax({
            type: 'GET',
            data: { firstNumber: 1, secondNumber: 2 },
            dataType: 'html',
            url: $(this).data('request-url'),
            success: function (result) {
                $('#result2').html(result);
            }
        });
    });
    $('.display-object').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: $(this).data('request-url'),
            success: function (result) {
                var resultString = 'Id: ' + result.id + '<br>City: ' + result.city + '<br>Country: ' + result.country;
                $('#result3').html(resultString);
            }
        });
    });
    $('.display-view').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: $(this).data('request-url'),
            success: function (result) {
                $('#result4').html(result);
            }
        });
    });
    $('.display-random-database-items').submit(function (event) {
        event.preventDefault();
        console.log($(this).serialize());
        $.ajax({
            url: $(this).data('request-url'),
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (result) {
                var stringResult = '<ul>';
                for (var i = 0; i < result.length; i++) {
                    stringResult += '<li>' + result[i].city + ', ' + result[i].country + '</li>';
                }
                stringResult += '</ul>';
                $('#result5').html(stringResult);
            }
        });
    });
    $('.new-destination').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var resultMessage = 'You\'ve added a new destination to the database!<br>Id: ' + result.id + '<br>City: ' + result.city + '<br>Country: ' + result.country;
                $('#result6').html(resultMessage);
            }
        });
    });
    $('.new-person').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).data('request-url'),
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function(data){
            window.location.href = data;
        }
        });
    });
});