var pagenumber = 1;
var rowcount = 2;
var data;
function Paging(pagenumber, rowcount) {
    $.ajax({
        type: "POST",
        url: "http://localhost:57336/User/GetAllUsers",
        dataType: "html",
        data:   {
            pagenumber: pagenumber,
            rowcount: rowcount
                }
    }).done((resultSet) => {
        if (resultSet == null) {
            $("#display").html("Nothing to show");
            return null;
        }
       data= JSON.parse(resultSet);
        console.log("successfuly got data");
        console.log(data["Results"]);
        printHtml(data);
  
    }).fail((xhr, status, err) => {
        console.log("Error in ajax -", status, err);
    });
}


//function generatePages(totalrecords,rowcount)
//{
//    var list = "<li class=\"page-item \"><a id=\"pageprevious\" class=\"page-link\"  tabindex=\"-1\">Previous</a></li>";
//    var pages = Math.ceil(totalrecords / rowcount);
//    debugger;
//    for (var z = 0; z < pages;z++) {
//        list += "<li class=\"page-item\"><a id=\"page"+(z+1)+"\" class=\"page-link\" >" +(z+1)+ "</a></li>";
//    }
//    list += "<li class=\"page-item\"><a id=\"pagenext\" class=\"page-link\">Next</a></li>";
//    $(".pagination").append(list);
//}




function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}

//function DateConversion(datestring){
//    var date = new Date(parseInt(datestring.replace(/\/Date\((\d+)\)\//, '$1')));
//    return date.toDateString();
//}




    function convertTable(jsonresult)
{
        var htmlData = "<table>";
    debugger;
    for (data in jsonresult)
    {
        debugger;
        htmlData += "<tr>";
        htmlData += "<td>" + jsonresult[data].Username + "</td>";
        htmlData += "<td>" + jsonresult[data].FirstName + "</td>";
        htmlData += "<td>" + jsonresult[data].LastName + "</td>";
        htmlData += "<td>" + jsonresult[data].Created + "</td>";
        htmlData += "<td>" + jsonresult[data].Modified + "</td>";
        htmlData += "</tr>";
    }
    htmlData += "</table>";
    debugger;
        return htmlData;
    }

    function printHtml(resultSet) {
        debugger;
        var result = resultSet["Results"];
        for(data in result)
        {
            result[data].Created = ToJavaScriptDate(result[data].Created);
            result[data].Modified = ToJavaScriptDate(result[data].Modified);
        }

        debugger;
        var htmlData = convertTable(result);
      //  generatePages(resultSet.TotalRecordCount, rowcount)
        $("#displayuser").html(htmlData);
        debugger;
    }
    
    Paging(1, 2);

  
