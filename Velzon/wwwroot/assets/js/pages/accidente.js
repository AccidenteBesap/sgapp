/*
Template Name: Velzon - Admin & Dashboard Template
Author: Themesbrand
Website: https://Themesbrand.com/
Contact: Themesbrand@gmail.com
*/

function loadTrabajadores() {
	console.log("loadTrabajadores function called");
	// Get the selected Rut from the "entrada-empresa" select
	var selectedRut = $("#entrada-empresa").val();

	// Make an AJAX request to fetch the trabajadores for the selected Rut
	$.ajax({
		url: "/Accidentes/GetTrabajadores", // Replace with the actual controller and action
		type: "GET",
		data: { rut: selectedRut },
		success: function (data) {
			// Clear the existing options in the "entrada-trabajador" select
			$("#entrada-trabajador").empty();

			$("#entrada-trabajador").append('<option value="">Seleccione trabajador</option>');

			// Populate the "entrada-trabajador" select with the fetched data
			$.each(data, function (index, item) {
				$("#entrada-trabajador").append('<option value="' + item.value + '">' + item.text + '</option>');
			});

			// Enable the "entrada-trabajador" select
			$("#entrada-trabajador").prop("disabled", false);
		},
		error: function () {
			// Handle errors if needed
		}
	});
}