$(function () {
    var teplateWrapper = $('.index-template');
    var wrapper = $('.wrapper');

    // Grab the template script
    var theTemplateScript = $("#index-template").html();

    // Compile the template
    var theTemplate = Handlebars.compile(theTemplateScript);
    window.renderTemplate = function () {
        return $.getJSON('/Events').success(function (data) {

            // Define our data object
            var data = {
                events: data
            };

            // Pass our data to the template
            var theCompiledHtml = theTemplate(data);

            // Add the compiled html to the page
            teplateWrapper.html(theCompiledHtml);

            //Add events
        });
    }

    var addEvents = function () {
        wrapper.on('click', '.search-form .submit-search', function () {
            var val = $('.search-form').find('input[name="word"]').val();
            $.ajax({
                url: '/Events/SearchFor',
                type: 'GET',
                data: {
                    categoryName: val
                },
                success: function (data) {

                    // Define our data object
                    var data = {
                        events: data
                    };

                    // Pass our data to the template
                    var theCompiledHtml = theTemplate(data);

                    // Add the compiled html to the page
                    teplateWrapper.html(theCompiledHtml);
                }
            });
        });

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
                    renderTemplate();
                }
            });
        });
    };

    renderTemplate().done(function () {
        addEvents();
    });
});