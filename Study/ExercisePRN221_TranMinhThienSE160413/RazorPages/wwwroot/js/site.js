
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrHubServer").build();
    connection.start();

    connection.on("LoadCustomer", function () {
        LoadCandidate(); 
    })
   
    function LoadCandidate() {

        $.ajax({
            url: '/CandidateProfileView/?handler=Reload', // Use the correct URL for the GetProducts action
            method: 'GET',
            success: (result) => {
          
                // Parse the returned HTML string into a jQuery object
                var $html = $(result);

                // Find the table with the ID "table1"
                var $table = $html.find('#table1');

                // Update the existing table on the page
                $('#table1').replaceWith($table);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }

});
