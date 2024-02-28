function statistics() {
    $('#statisticsBtn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statisticsBox').hasClass('d-none')){
            $.get('https://localhost:7215/api/statistics', function (data) {
                let totalHouses = $('#totalHouses');
                let totalRents = $('#totalRents');

                let totalHousesCount = data.totalHouses;
                let totalRentsCount = data.totalRents;

                totalHouses.text(totalHousesCount + (totalHousesCount === 1 ? " House" : " Houses"));

                totalRents.text(totalRentsCount + (totalRentsCount === 1 ? " Rent" : " Rents"));

                $('#statisticsBox').removeClass('d-none');
                $('#statisticsBtn').text('Hide statistics');
                $('#statisticsBtn').removeClass('btn-primary');
                $('#statisticsBtn').addClass('btn-danger');
            });
        } else {
            $('#statisticsBox').addClass('d-none');
            $('#statisticsBtn').text('Show statistics');
            $('#statisticsBtn').addClass('btn-primary');
            $('#statisticsBtn').removeClass('btn-danger');
        };
    })
}