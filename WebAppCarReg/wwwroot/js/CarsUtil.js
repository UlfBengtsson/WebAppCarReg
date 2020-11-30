

function findById(event, urlHelper) {
    console.log(urlHelper);
    event.preventDefault();
    const anchorElement = event.target;
    const inputIdValue = $("#carIdInput").val();

    $.get(anchorElement.attributes.href.value + "/" + inputIdValue, function (result) {

        $('#' + anchorElement.attributes["data-target"].value).html(result);

    }).fail(function () {
        alert("Car with this Id: " + inputIdValue + " was not found");
    });
};