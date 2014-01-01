function _delete(url, oTable) {

    $(".getChecked").click(function () {
        var jqConfirm = confirm('确定要删除选中的信息吗?');
        if (jqConfirm == true) {
            var selectedItems = new Array();
            $("input[type='checkbox'][value]:checked").each(function () { selectedItems.push($(this).val()); });

            if (selectedItems.length == 0)
                alert("请选择需要删除的项");

            else
                $.ajax({
                    type: "POST",
                    url: url,
                    data: 'idlist=' + selectedItems.toString(),
                    dataType: "text",
                    success: function (request) {
                        oTable.fnReloadAjax();

                    },
                    error: function (request, error) {
                        alert('Error deleting item(s), try again later.');
                    }
                });
        }
    })
}