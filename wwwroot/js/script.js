
//run the LoadTable function when the page has loaded
$(document).ready(function () {
   // alert("hi"); //checked the file is linked or not
    LoadTable();
});
const uri = "/api/Sellerslists"; //api/Sellerslists the api as a controller name
let allSellers = null; //holds the data 

//this function reloads the table 
function LoadTable() {
    $.ajax({
        type: "GET", 
        url: uri, 
        cache: false, 
        success: function (data) { //if the request succeeds ....
            const tBody = $("#allSellers"); //for the tbody bind with allsellers <tbody id="allsellers"></tbody>
            allSellers = data; //pass in all the data to allsellers use it in Edit
            $(tBody).empty(); //empty out old data
          
            //foreach data will appear in rows
            $.each(data,function (key, item) {
                    const tr = $("<tr></tr>")
                        .append($("<td></td>").text(item.sellername)) //fill content in the tags
                        .append($("<td></td>").text(item.company))
                        .append($("<td></td>").text(item.producttype))
                        .append($("<td></td>").text(item.commission))
                        .append($("<td></td>")
                            //creating link for editing data
                            .append($("<a href='#editSellerModal' data-toggle='modal'><i class='material-icons' style='font-size:30px; color: yellow;' title='Edit'>&#xE254;</i></a>)")
                              
                                    .on("click",
                                        function () {
                                            editItem(item.id);
                                        }) 
                                )
                            )
                            .append($("<td></td>") //creating link for delete data
                                .append($("<a  href='#deleteSellerModal' data-toggle='modal'><i class='material-icons' style='font-size:30px; color: red;' data-toggle='tooltip' title='Delete'>&#xE872;</i></a>)")
                                   
                                                    .on("click", function () {
                                                        $("#delete-id").val(item.id);
                                                    }
                                                        
                                                    )
                                        
                                )
                            
                            
                             );
                    tr.appendTo(tBody);//add all the rows to the tbody
                });
        }
    });
}
//Add an Detail of Seller to the database
function addItem() {
    const item = {
        sellername: $("#add-name").val(),
        company: $("#add-company").val(),
        producttype: $("#add-producttype").val(),
        commission: $("#add-commission").val(),
    };
    $.ajax({
        type: "POST", //Here the POST is calles in the API controller
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        //if there is an error
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong !!" );
        },
        //if it is successfully added
        success: function (result) {
            LoadTable();
            $("#add-name").val(""); //clear entry boxes
            $("#add-Company").val("");
            $("#add-Producttype").val("");
            $("#add-Commission").val("");

            alert("Successfully Seller added!!");
        }
    });
}
//Delete Seller detail from the database
function deleteItem(id) {

    $.ajax({
        url: uri + "/" + id, //add the ID to the end of the URI
        type: "DELETE", //Here DELETE is called in the API controller
        success: function (result) {
            LoadTable();
        }
    });
}
//click event for edit button to load details into form. Go through each entry held in allseller and add in the one that matches the id from the click
function editItem(id) {
    $.each(allSellers,
        function (key, item) {
            if (item.id === id) {//where the ID == the one on the click
                $("#edit-name").val(item.sellername); //add it to the form field
                $("#edit-id").val(item.id);
                $("#edit-company").val(item.company);
                $("#edit-producttype").val(item.producttype);
                $("#edit-commission").val(item.commission);;
            }
        });
}
//$(".my-form").on("submit", //saving the edited information in database
function saveItem() {
    const item = { //pass all the data on the form to a variable called item use later to send to server
        sellername: $("#edit-name").val(),
        company: $("#edit-company").val(),
        producttype: $("#edit-producttype").val(),
        commission: $("#edit-commission").val(),
        id: $("#edit-id").val()
    };
    alert("Seller updated successfully!!");

    $.ajax({
        url: uri+"/"+$("#edit-id").val(), //add the row id to the uri
        type: "PUT", //send it to the PUT controller
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item), //take the item data and pass it to the serever data is moved to server
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
          
            alert("Seller upated successfully!!");
            LoadTable(); //load the table fresh
        }
    });
    return false;
};


