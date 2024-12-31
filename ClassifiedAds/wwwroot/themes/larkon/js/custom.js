$(function () {
    // When the file input changes (i.e., when an image is selected)
    console.log(111)
    $('input[type=file][data-preview]').on('change', function (e) {
        // Get the file object from the input
        var file = e.target.files[0];

        // Ensure the file is an image
        if (file && file.type.startsWith('image')) {
            var reader = new FileReader();

            // When the image is loaded, show the preview
            reader.onload = function (event) {
                // Construct the class name by appending "_preview" to the input's name
                var previewClass = e.target.name + '_preview';

                // Get the corresponding div to append the image to by class name
                var previewDiv = $('div.' + previewClass);

                // Clear any previous image
                previewDiv.empty();

                // Create an image element
                var img = $('<img>').attr('src', event.target.result);

                // Optionally, set styles or other properties to control the preview size
                img.css({
                    'max-width': '100%',
                    'max-height': '300px',
                    'object-fit': 'contain'
                });

                // Append the image to the preview div
                previewDiv.append(img);
            }

            // Read the image file as data URL
            reader.readAsDataURL(file);
        } else {
            // If the selected file is not an image
            alert('Please select a valid image file.');
        }
    });
});
