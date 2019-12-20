$(document).ready(function() {
    $('body').on('keyup', '#search', function(e) {
        var url = $(this).attr('data-url');
        $.ajax({
            url: url,
            method: 'GET',
            data: {
                search: $(this).val(),
                selected: $('#selector').val()
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