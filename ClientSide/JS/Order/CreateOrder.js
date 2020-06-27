$(document).ready(function () {

    $("#BuyCart").hide();
    // Get the "UserName" from "LogIn" Page
    var obj = sessionStorage.getItem("SendUserName");
    $("#SelectedUserName").text("Hi, " + obj);

    var SeletedGameId = [];
    var UserId = "";

    //Get the User's "Id" from "UserName" 
    $.ajax({
        url: "/api/Player/AllPlayers/" + obj,
        type: "GET",
        dataType:"JSON",
        contentType: "Application/Json",
        success: function (data) {
            UserId = data.Id;
            //console.log(UserId);
        }
    })

    //Click on "Add to Cart" to Push all Selected "GameId" to array "SeletedGameId"
    $('#ListOfGames').on('click', 'button', function (e) {
        e.preventDefault();
        var ClickedGameId = $(this).attr('GameId');
        SeletedGameId.push(ClickedGameId);
        //console.log(JSON.stringify(SeletedGameId))
    })

    //Displays all Cart Item Lists with DYNAMIC "DiscountPrice"
    $("#CartButton").click(function (e) {
        e.preventDefault();
        for (var i = 0; i < SeletedGameId.length; i++) {

            $.ajax({
                type: 'GET',
                url: '/Api/Game/' + SeletedGameId[i],
                dataType: 'JSON',
                contentType: 'Application/Json',
                success: function (data) {
                    $("#CartofList").append("Name : " + data.GameName+"<br/>");
                    $("#CartofList").append("Publisher : " + data.Publisher + "<br/>");
                    $("#CartofList").append("Play Time : " + data.PlayTime + "<br/>");
                    $("#CartofList").append("Release Date : " + data.ReleaseDate + "<br/>");
                    $("#CartofList").append("Game Type : " + data.GameType + "<br/>");
                    $("#CartofList").append("Price : " + data.Price + "<br/>");
                    $("#CartofList").append("Discount Price : <input type='number' Id='DiscountPrice-" + data.Id + "' name='DiscountName-"+data.Id+"' /><br/><hr/>");
                },
                error: function (er, exception) {
                    console.log(er.statusText);
                }
            })          
        }       
        $("#BuyCart").show();
    })

    //When click on "Buy Now" button > get "DiscountPrice" and "SeletedGameId" and "UserId" and insert
    $("#BuyCart").click(function (e) {
        e.preventDefault();
        var DiscountPriceList = [];

        var insert = {};

        for (var i = 0; i < SeletedGameId.length; i++) {
            var DiscountList = "#DiscountPrice-" + SeletedGameId[i];
            var DiscountPriceList = ($(DiscountList).val());

            var d = new Date();
            var TodayDate = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
            insert.Gameid = SeletedGameId[i];
            insert.Playerid = UserId;
            insert.DiscountPrice = DiscountPriceList;
            insert.OrderDate = TodayDate;

            $.ajax({
                type: "POST",
                url: "/Api/Order",
                dataType: "Json",
                contentType: "Application/Json",
                data: JSON.stringify(insert),
                success: function (data) {
                    console.log(data.Id);
                },
                error: function (er, exception) {
                    console.log(er.statusText);
                }
            })
        }
    })

    // List of Games with "Add to Cart" button added dynamically
    $.ajax({
        type: 'GET',
        url: '/Api/Game',
        dataType: 'JSON',
        contentType: 'Application/Json',
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ListOfGames").append("<li>" + value.GameName + "<button GameId='" + value.Id + "' id='Item-" + value.Id + "'>Add to Cart</button>" + "</li>");
            })
        },
        error: function (er, exception) {
            console.log(er.statusText);
            //alert("Error is " + er.statusText);
        }
    })

});