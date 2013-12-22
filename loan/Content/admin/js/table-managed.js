var TableManaged = function () {

    return {

        //main function to initiate the module
        init: function () {

            if (!jQuery().dataTable) {
                return;
            }

            // begin first table
            $('#sample_1').dataTable({

                "aLengthMenu": [
                    [5, 15, 20, -1],
                    [5, 15, 20, "所有"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 5,
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sInfo": "共 _TOTAL_ 条 当前第 _START_ 到 _END_ 条 ",
                    "sLengthMenu": "展示 _MENU_ 条信息",
                    "sSearch": "搜 索 ",
                    "oPaginate": {
                        "sFirst": "第一页",
                        "sPrevious": "Prev",
                        "sNext": "Next",
                        "sLast": " 最后一页 "
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }
                ]
            });




            jQuery('#sample_1 .group-checkable').change(function () {
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                    $(this).parents('tr').toggleClass("active");

                });

                jQuery.uniform.update(set);

            });

            jQuery('#sample_1 tbody tr .checkboxes').change(function () {
                $(this).parents('tr').toggleClass("active");
            });

            jQuery('#sample_1_wrapper .dataTables_filter input').addClass("form-control input-medium"); // modify table search input
            jQuery('#sample_1_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            jQuery('#sample_1_wrapper .dataTables_length select').select2(); // initialize select2 dropdown


        }

    };

}();