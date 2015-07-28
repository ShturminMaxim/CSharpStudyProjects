$(function () {
    var mainWrapper = $('.wrapper');
        

    // Grab the template script
    var theTemplateScript = $("#index-template").html();

    // Compile the template
    var theTemplate = Handlebars.compile(theTemplateScript);

    $.getJSON('/Events', function (data) {
        
        // Define our data object
        var data = {
            events: data
        };

        // Pass our data to the template
        var theCompiledHtml = theTemplate(data);

        // Add the compiled html to the page
        mainWrapper.html(theCompiledHtml);
    })

  
});
