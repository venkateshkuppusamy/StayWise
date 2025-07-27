// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function populateForm(hotelId, name, location) {
    // Populate the hidden input for HotelId
    document.querySelector('[name="Hotel.HotelId"]').value = hotelId;

    // Populate the input for Name
    document.querySelector('[name="Hotel.Name"]').value = name;

    // Populate the input for Location
    document.querySelector('[name="Hotel.Location"]').value = location;

    // Update the submit button's asp-page-handler to "Edit"
    const submitButton = document.querySelector('form button[type="submit"]');
    submitButton.setAttribute('formaction', '/Hotels?handler=Edit');
    submitButton.textContent = 'Save Changes'; // Update button text to reflect Edit action

    // Optionally, scroll to the form
    document.querySelector('form').scrollIntoView({ behavior: 'smooth' });
}
