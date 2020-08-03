jQuery(document).ready(function () {

    $('#data_table__Developer thead th').each(function () {
        var title = $(this).text();
        var count = title.length;
        if (title == "Ticket Details" || title === "Name") {
            $(this).html('<div style="width:' + (count + 12) + '0px"><lable style="text-align: center;" class="control-lable text-center">' + title + '</lable></div>');
        }
        else {
            $(this).html('<div style="width:' + count.toString() + '0px"><lable style="text-align: center;" class="control-lable text-center">' + title + '</lable></div>');
        }
    });


    var _columns = [];
    for (i = 1; i < $("#data_table__Developer > thead > tr:first > th").length; i++) {
        _columns.push(i);
    }


    var table = $('#data_table__Developer').DataTable({

        dom: '<"html5buttons"B>lTfgitp',
        scrollY: '50vh',
        scrollX: true,
        scrollCollapse: true,
        destroy: true,
        select: true,
        order: [[1, "desc"]],
        //buttons: ['copy', 'csv', 'excel', 'pdf', 'print', 'colvis'],
        columnDefs: [
            {
                targets: 0,
                orderable: false,
            },
            {
                targets: 10,
                render: function (data, type, full, meta) {
                    var status = _status;
                    if (typeof status[data] === 'undefined') {
                        return data;
                    }
                    return '<span class="kt-badge ' + status[data].class + ' kt-badge--inline kt-badge--pill" style="width: 100px;">' + status[data].title + '</span>';
                },
            },
        ],
        buttons: [
            //{
            //    extend: 'colvis'
            //},
            {
                extend: 'copy'
                , exportOptions: {
                    columns: _columns
                }
            },
            {
                extend: 'csv', exportOptions: {
                    columns: _columns
                }
            },
            {
                extend: 'excel', exportOptions: {
                    columns: _columns
                }
            },
            {
                extend: 'pdf', exportOptions: {
                    columns: _columns
                }
                , orientation: 'landscape',
                pageSize: 'LEGAL'
            },
            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                }, exportOptions: {
                    columns: _columns
                }
            }

        ],
        initComplete: function (settings, json) {
            $('.dataTables_filter input[type="search"]').css({ 'width': '350px', 'display': 'inline-block' });
            $('.html5buttons').css({ 'padding': '20px' });
            $('body').find('.dataTables_scrollBody').addClass("scrollbar");

        },
    });

});