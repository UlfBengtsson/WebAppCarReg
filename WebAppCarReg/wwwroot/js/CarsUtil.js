var createBtn = null;

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
    createBtn = $("#btn-car-create");

    $.get(urlToCreateForm, function (result) {
        createBtn.replaceWith(result);
    })
}

function PostCreatecarForm(event, createForm) {
    event.preventDefault();
    //console.log("Create Form post:", createForm);
    event.preventDefault();

    //console.log("action url:", createForm.action);
    //console.log("form value brand:", createForm.Brand.value);

    $.post(createForm.action,
        {
            Brand: createForm["Brand"].value,
            ModelName: createForm.ModelName.value,
            Year: createForm.Year.value
        },
        function (data, status) {
            $("#carsListDiv").append(data);
            $("#createCarDiv").html(createBtn); //document.getElementById("createCarDiv").innerHTML = createBtn;

        }).fail(function (badForm) {
            //console.log("badForm: ", badForm);
            $("#createCarDiv").html(badForm.responseText);
        });

}