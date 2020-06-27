$(document).ready(function () {

    $("#myform").submit(function (e) {
        e.preventDefault();

        var insert = {};
        var formData = new FormData($("#myform")[0]);
        insert.UserName = formData.get('UserName');
        insert.Password = formData.get('Password');

        $.ajax({
            type: 'POST',
            url: '/Api/Player/LogInPlayer',
            dataType: 'JSON',
            contentType: 'Application/Json',
            data: JSON.stringify(insert),
            success: function (data) {
                sessionStorage.setItem("SendUserName", data);          
                location.href = "/Order/Create";
            },
            error: function (er, exception) {
                //alert("Error is " + er.statusText);
            }
        })



    })
});