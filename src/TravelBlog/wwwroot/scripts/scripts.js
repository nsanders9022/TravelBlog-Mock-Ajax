$(document).ready(function () {
    $('.hello-ajax').click(function () {
        $.ajax({
            type: 'GET',
            url: '@Url.Action("HelloAjax")',
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });
});