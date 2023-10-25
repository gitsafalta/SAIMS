var myDatatable = new DataTable('#salesSummaryReportTable', {
    columns: [
        { title: 'Date' },
        { title: 'Customer' },
        { title: 'Item' },
        { title: 'Category' },
        { title: 'Quantity' },
        { title: 'Amount (Rs.)' },
        { title: 'Discount' },
        { title: 'Total Amount (Rs.)' },
    ],
    data: [],
    columnDefs: [
        { "width": "100px", "targets": [0] }
    ],
    footerCallback: function (row, data, start, end, display) {
        let api = this.api();

        // Remove the formatting to get integer data for summation
        let intVal = function (i) {
            return typeof i === 'string'
                ? i.replace(/[\$,]/g, '') * 1
                : typeof i === 'number'
                    ? i
                    : 0;
        };

        // Total over all pages
        total = api
            .column(7)
            .data()
            .reduce((a, b) => intVal(a) + intVal(b), 0);

        // Total over this page
        pageTotal = api
            .column(7, { page: 'current' })
            .data()
            .reduce((a, b) => intVal(a) + intVal(b), 0);

        // Update footer
        api.column(7).footer().innerHTML =  pageTotal + ' ( ' + total + ' total)';
    }
});

var d = new Date();
var year = d.getFullYear();
var select_year =  document.getElementById("year");
for(var i =1; i<=10;i++){
   var option = document.createElement("option");
   option.text = year;
   option.value = year;
   select_year.appendChild(option);
   year--;
}

const month = ["January","February","March","April","May","June","July","August","September","October","November","December"];
var select_month =  document.getElementById("month");
var option = document.createElement("option");
option.text = "select";
option.value = "-1";
select_month.appendChild(option);
for(var i=0; i<=11; i++){
   var option = document.createElement("option");
   option.text = month[i];
   option.value = i+1;
   select_month.appendChild(option);
}

var select_day =  document.getElementById("day");
var option = document.createElement("option");
option.text = "select";
option.value = "-1";
select_day.appendChild(option);
for(var i=1; i<=31; i++){
   var option = document.createElement("option");
   option.text = i;
   option.value = i;
   select_day.appendChild(option);
}

const searchSales = document.getElementById("search");
const selectPeriod = document.getElementById("selectPeriod");
searchSales.addEventListener('click', function handleChange(event){

    if(selectPeriod.selectedIndex == 0)
        return;
    postData();
    var el = event.target;
    document.getElementById("periodSelectedValue").innerText = selectPeriod.options[selectPeriod.selectedIndex].text;  
    
});

function postData()
{
    let postObj = { 
        year: document.getElementById("year").value, 
        month: document.getElementById("month").value, 
        day: document.getElementById("day").value,
        period: parseInt(document.getElementById("selectPeriod").value)
    };
    let post = JSON.stringify(postObj);
    fetch("http://localhost:5281/api/sales", {
        method: 'post',
        body: post,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).then((response) => {
        return response.json()
    }).then((res) => {
        myDatatable.clear();
        document.getElementById("totalsales").innerText = res.totalSales;
        const data = [];
        res.salesDetails.map(x => 
            {
                data.push([x.date, x.customerName, x.itemName, x.categoryName, x.quantity, x.price, x.discountAmount,  x.totalAmount]);
            });
    
        myDatatable.rows.add(data);
        myDatatable.draw();
    }).catch((error) => {
        console.log(error)
    })
}

/*var ctx = document.getElementById("dailySalesLineChart").getContext('2d');

var myChart = nfew Chart(ctx, {
    type: 'line',
    data: {
        labels: ["2023-09-12", "2023-09-13", "2023-09-14", "2023-09-15", "2023-09-16", "2023-09-17", "2023-09-18", "2023-09-19", "2023-09-20", "2023-09-21"],
        datasets: [{
            label: 'Daily Sales (Past 10 days)', // Name the series
            data: [500, 50, 2500, 1200, 1400, 4111, 4544, 47, 5555, 6811], // Specify the data values array
            fill: false,
            borderColor: '#2196f3', // Add custom color border (Line)
            backgroundColor: '#2196f3', // Add custom color background (Points and Fill)
            borderWidth: 1 // Specify bar border width
        }]
    },
    options: {
        responsive: true, // Instruct chart js to respond nicely.
        maintainAspectRatio: false, // Add to prevent default behaviour of full-width/height 
    }
});*/
