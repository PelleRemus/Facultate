$(document).ready(function() {
    $('body').on('change', '#select-1', function(event) {
        var url = $(this).attr('data-url');
        $.ajax({
            url: url,
            method: 'GET',
            data: {},
            success: function(data) {
                console.log(data);
            },
            error: function(error) {
                console.log(error);
            },
            complete: function() {}
        });
    });
});