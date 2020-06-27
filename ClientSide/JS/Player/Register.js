$(document).ready(function () {
    $("#myform").submit(function (e) {
        e.preventDefault();

        var insert = {};
        var formData = new FormData($("#myform")[0]);
        insert.PlayerName = formData.get('PlayerName');
        insert.UserName = formData.get('UserName');
        insert.Email = formData.get('Email');
        insert.Phone = formData.get('Phone');
        insert.BirthDate = formData.get('BirthDate');
        insert.Gender = formData.get('Gender');
        insert.Password = formData.get('Password');

        $.ajax({
            type: 'POST',
            url: '/Api/Player/CreatePlayer',
            dataType: 'JSON',
            contentType: 'Application/Json',
            data: JSON.stringify(insert),
            success: function (data) {
                console.log(data.UserName);
                //$("#LogInLink").text(data);
                //$.cookie("name", data);
                //Cookies.set('CurrentUserName', "fdff");                
                //location.href = "/Home/Index";
                ////Cookies.get('CurrentUserName');
                //console.log(Cookies.get('CurrentUserName'));
            },
            error: function (er, exception) {
                console.log(er.statusText);
                //alert("Error is " + er.statusText);
            }
        })

    })
});