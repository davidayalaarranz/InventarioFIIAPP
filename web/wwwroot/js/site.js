// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ActivarTooltips()
{
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
}

function showSuccessToast (xhr) {
    var toastElList = [].slice.call(document.querySelectorAll('.toast-success'))
    var toastList = toastElList.map(function(toastEl) {
        return new bootstrap.Toast(toastEl)
    })
    $('.toast-success > .toast-body').text(xhr);
    toastList.forEach(toast => toast.show()) 
}

function showErrorToast (req, status, errorThrown) {
    var toastElList = [].slice.call(document.querySelectorAll('.toast-error'))
    var toastList = toastElList.map(function(toastEl) {
        return new bootstrap.Toast(toastEl)
    })
    $('.toast-error > .toast-body').text(req.responseText);
    toastList.forEach(toast => toast.show()) 
}

function OpenEditModal(id) {
    var data = { id: id };
    $.ajax(
        {
            type: 'GET',
            url: '/Usuario/Edit',
            contentType: 'application/json; charset=utf=8',
            data: data,
            success: function (result) {
                $('#modal-edit-content').html(result);
                $('#modal-edit').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}

function OpenDeleteModal(id) {
    var data = { id: id };
    $.ajax(
        {
            type: 'GET',
            url: '/Usuario/Delete',
            contentType: 'application/json; charset=utf=8',
            data: data,
            success: function (result) {
                $('#modal-delete-content').html(result);
                $('#modal-delete').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}

function OpenDetailsModal(id) {
    var data = { id: id };
    $.ajax(
        {
            type: 'GET',
            url: '/Usuario/Details',
            contentType: 'application/json; charset=utf=8',
            data: data,
            success: function (result) {
                $('#modal-details-content').html(result);
                $('#modal-details').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}

function OpenAddModal() {
    $.ajax(
        {
            type: 'GET',
            url: '/Usuario/Create',
            contentType: 'application/json; charset=utf=8',
            success: function (result) {
                $('#modal-add-content').html(result);
                $('#modal-add').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}