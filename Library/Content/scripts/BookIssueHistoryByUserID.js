
function fetchData(userId) {
    $.ajax({
        type: "POST",
        url: "http://localhost:57336/User/GetIssueHistory",
        dataType: "html",
        data: { id: userId }
    }).done((result) => {
        console.log("successfulyy got data");
        console.log(result);
        debugger;
        popUp(result,userId);
    }).fail((xhr,status,err) => {
        console.log("Error in ajax -",status,err);
    });
}

$(".button").click(function () {

    var userid = $(".textbox").val();


    if (userid == "")
        {
            alert("please enter the userid");
        }
    fetchData(userid);

});

//to show Book Issue History of a particular user in a Popup (Modal)
function popUp(htmlData,userId) {
    debugger;
    ShowUserinHeader(userId)
    $("#bodytodisplay").html(htmlData);
    $("#myModal").modal("show");
}

function ShowUserinHeader(userId) {
    $("#myModalLabel").html(userId +" has issued these books till now. ")
}