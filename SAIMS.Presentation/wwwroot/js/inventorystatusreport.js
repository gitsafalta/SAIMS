new DataTable('#inventoryStatusReportTable', {
    "filter": true,
    "ajax": {
        "url": "http://localhost:5281/api/inventory",
        "type": "POST",        
        "contentType": "application/json",
        "data" : function(d) {
            return JSON.stringify( d );
            }
    },
    columns: [
        { "data": "id", "name": "Id", "autoWidth": true },
        { "data": "item", "name": "Item", "autoWidth": true },
        { "data": "category", "name": "Category", "autoWidth": true },
        { "data": "availableQuantity", "name": "Available Quantity", "autoWidth": true },
    ],
    processing: true,
    serverSide: true,
    "rowCallback": function (row, data) {
        if (data.availableQuantity == 0) {
            $(row).addClass('bg-danger');
        }
        else if (data.availableQuantity <= 10) {
            $(row).addClass('bg-warning');
        }

    }
});