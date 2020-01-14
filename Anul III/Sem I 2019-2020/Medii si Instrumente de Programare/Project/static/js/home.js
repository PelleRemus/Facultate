$(document).ready(function() {
    $('body').on('keyup', '#search-location', function(e) {
        var url = $(this).attr('data-url');
        $.ajax({
            url: url,
            method: 'GET',
            data: {
                searchLocation: $(this).val(),
                searchDate: $('#search-date').val()
            },
            success: function(data) {
                $('#list-container').html(data);
            },
            error: function(error) {
                console.log(error);
            },
            complete: function() {}
        });
    });
    $('body').on('keyup', '#search-date', function(e) {
        var url = $(this).attr('data-url');
        $.ajax({
            url: url,
            method: 'GET',
            data: {
                searchLocation: $('#search-location').val(),
                searchDate: $(this).val()
            },
            success: function(data) {
                $('#list-container').html(data);
            },
            error: function(error) {
                console.log(error);
            },
            complete: function() {}
        });
    });
});