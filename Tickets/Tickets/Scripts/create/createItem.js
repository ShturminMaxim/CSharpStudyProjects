$(function () {
    var wrapper = $('.wrapper');
    var uploadFile = function (filesData) {
        return $.ajax({
            url: '/AddEvent/UploadFile',
            type: 'POST',
            data: filesData,
            contentType: false,
            processData: false,
        });
    };
    var createItem = function (data) {
        var imagePath = data && data.imagePath || '';

        return $.ajax({
            url: '/AddEvent/Create',
            type: 'POST',
            data: {
                Name: addBox.find('input[name="Name"]').val(),
                Description: addBox.find('input[name="Description"]').val(),
                Teaser: imagePath,
                Cost: addBox.find('input[name="Cost"]').val(),
                Discount: addBox.find('input[name="Discount"]').val(),
                CategoryId: 1,
            },
            success: function () {
                alert('added');
                window.renderTemplate();
                $('.add-event-box, .overlay').remove();
            }
        });
    };

    wrapper.on('click', '.create-new-event', function () {
        $.get('/AddEvent', function (data) {
            wrapper.append(data);
        });
    });

    wrapper.on('click', '.submit-event', function () {
        var addBox = $('.add-event-form');
        var data = new FormData();
        var file = addBox.find('input[name="Teaser"]')[0].files[0];

        data.append(file.name, file);

        /**
        * Upload file
        */
        uploadFile(data)
            .success(function (imagePath) {
                createItem({
                    imagePath: imagePath
                });
        })
    });
});