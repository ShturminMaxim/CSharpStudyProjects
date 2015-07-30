$(function () {
    var wrapper = $('.wrapper');

    wrapper.on('click', '.create-new-event', function () {
        $.get('/AddEvent', function (data) {
            wrapper.append(data);
        });
    });

    wrapper.on('click', '.submit-event', function () {
        var addBox = $('.add-event-form');
        $.ajax({
            url: '/AddEvent/Create',
            type: 'POST',
            data: {
                Name: addBox.find('input[name="Name"]').val(),
                Description: addBox.find('input[name="Description"]').val(),
                Teaser: addBox.find('input[name="Teaser"]').val(),
                Cost: addBox.find('input[name="Cost"]').val(),
                Discount: addBox.find('input[name="Discount"]').val(),
                CategoryId: 1,
            },
            success: function () {
                alert('added');
                window.renderTemplate();
            }
        });
    });
});