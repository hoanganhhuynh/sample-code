$(document).ready(function () {

    getPeople();
    getCountry();

    $("#createBtn").on("click", function () {
        var people = {
            firstName: $("#ifirstName").val(),
            lastName: $("#ilastName").val(),
            countryId: $("#country").val(),
            gender: $("#gender").val()
        }
        createPeople(people);
    });
});

function getCountry() {
    var mySelect = $('#country');
    $.ajax({
        url: "https://localhost:5001/country", success: function (result) {
            if (result) {
                $.each(result, function (_, item) {
                    mySelect.append(
                        $('<option></option>').val(item.id).html(item.name)
                    );
                });
            }
        }
    });
}

function getPeople() {
    $.ajax({
        url: "https://localhost:5001/people", success: function (result) {
            if (result) {
                $('#grid').grid({
                    dataSource: result,
                    columns: [
                        { field: 'firstName', title: 'First Name', sortable: true },
                        { field: 'lastName', title: 'Last Name', sortable: true },
                        { field: 'gender', title: 'Gender' }
                    ],
                    pager: { limit: 5 }
                });
                
            }
        }
    });
}


function createPeople(people) {
    $.ajax({
        type: "POST",
        url: "https://localhost:5001/people",
        data: JSON.stringify(people),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            if (!data.ErrorCode) {
                var grid = $('#grid').grid();
                grid.addRow(data);
            }
            else
                alert('Failed adding person: ' + data.Message);
        }
    });
}