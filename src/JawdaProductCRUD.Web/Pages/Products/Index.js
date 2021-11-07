$(function () {
    var l = abp.localization.getResource('JawdaProductCRUD');
    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');
    var categoryID = "";
    function loadData() {

        var dataTable = $('#ProductsTable').DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                retrieve: true,

                paging: false,
                order: [[1, "asc"]],
                searching: false,
                scrollX: true,
                ajax:
                //{
                //    url: "https://localhost:44316/api/app/product/by-category",
                //    dataSrc: categoryID
                    
                //},
                abp.libs.datatables.createAjax(jawdaProductCRUD.services.product.getListByCategory,
                    function () {
                        debugger;
                        return {
                            categoryID:     categoryID
                        }
                    }  ),
                columnDefs: [
                    {
                        title: l('Actions'),
                        rowAction: {
                            items:
                                [
                                    {
                                        text: l('Edit'),
                                        //visible: abp.auth.isGranted('Permission.Products.Edit'),
                                        action: function (data) {
                                            editModal.open({ id: data.record.id });
                                        }
                                    },
                                    {
                                        text: l('Delete'),
                                        //visible: abp.auth.isGranted('Permission.Products.Delete'),
                                        confirmMessage: function (data) {
                                            return l(
                                                'ProductDeletionConfirmationMessage',
                                                data.record.title
                                            );
                                        },
                                        action: function (data) {
                                            jawdaProductCRUD.services.product
                                                .delete(data.record.id)
                                                .then(function () {
                                                    abp.notify.info(
                                                        l('SuccessfullyDeleted')
                                                    );
                                                    dataTable.ajax.reload();
                                                });
                                        }
                                    }
                                ]
                        }
                    },
                    {
                        title: l('Name'),
                        data: "title_ar"
                    },
                    {
                        title: l('Name'),
                        data: "title_en"
                    },
                    {
                        title: l('Category'),
                        data: "categoryTitle"
                    },
                    {
                        title: l('Price'),
                        data: "price"
                    },

                ]
            })
        );
    }
    var dataTable = loadData();

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#searchCategory').click(function (e) {
        categoryID = $('#ddCategory').find('option:selected').val();
        $("#ProductsTable").dataTable().fnDestroy();
        loadData();
    });


    //$('#ddCategory').change(function () {
    //    //Use $option (with the "$") to see that the variable is a jQuery object
    //    var $option = $(this).find('option:selected');
    //    //Added with the EDIT
    //    var value = $option.val();//to get content of "value" attrib
    //    categoryID = value;
    //    $("#ProductsTable").dataTable().fnDestroy();
    //    loadData();
    //});


});
