

function findById(event) {
    event.preventDefault();
    const anchorElement = event.target;
    const inputIdValue = $("#carIdInput").val();

    $.get(anchorElement.attributes.href.value + "/" + inputIdValue, function (result) {

        $('#' + anchorElement.attributes["data-target"].value).html(result);

    }).fail(function () {
        alert("Car with this Id: " + inputIdValue + " was not found");
    });
};

function GetCreateCarForm(urlToCreateForm) {
    const createBtn = $("#btn-car-create");

    $.get(urlToCreateForm, function (result) {
        createBtn.replaceWith(result);
    })
}

