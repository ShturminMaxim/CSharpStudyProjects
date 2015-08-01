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
        });
    }

    var addEvents = function () {
        /**
        *  Search events
        */
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
    };


    /**
    * Render HTML Template
    */
    renderTemplate().done(function () {
        addEvents();
    });
});