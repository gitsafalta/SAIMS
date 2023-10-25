const dataSet = [
    ['Percentage', '10', '1000',],
    ['Fixed Amount', '100', '1000',],
    ['Random Offer', '24' , '1000',],
];

new DataTable('#discountUsageReportTable', {
    columns: [
        { title: 'Discount Type' },
        { title: 'Discount Used' },
        { title: 'Discount Amount' }
    ],
    data: dataSet
});
