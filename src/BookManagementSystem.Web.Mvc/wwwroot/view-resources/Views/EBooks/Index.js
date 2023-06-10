(function ($) {
    var _eBookService = abp.services.app.eBook,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#EBookCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#EBooksTable');
    console.log(_eBookService);

    $(document).ready(function () {
        $.ajax({
            url: '/EBooks/GetAuthors',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var select = $('#author-details');
                $.each(data.result, function (index, author) {
                    select.append($('<option>', {
                        value: author.id,
                        text: author.authorName
                    }));
                });
            },
            error: function (e) {
            }
        });
    });

    var _$eBooksTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _eBookService.getAll,
            inputFilter: function () {
                return $('#EBooksSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$eBooksTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'eBookName',
                sortable: false
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: 'filePath',
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-ebook" data-ebook-id="${row.id}" data-toggle="modal" data-target="#EBookEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-ebook" data-ebook-id="${row.id}" data-ebook-name="${row.eBookName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var form = document.querySelector('form[name="eBookCreateForm"]');
        console.log(form);
        var formData = new FormData(form);
        console.log(formData);

        var ebook = {
            eBookName: formData.get("EBookName"),
            description: formData.get("Description"),
            filePath: 'EBookFile\\'+formData.get("FilePath").name
        };

        var author = {
            id: formData.get("AuthorId")
        };

        var ebookAndAuthor = {
            eBook: ebook,
            author: author
        };

        if (formData.get("FilePath").type === "application/pdf") {
            console.log(ebookAndAuthor);
            abp.ui.setBusy(_$modal);
            $.ajax({
                url: '/EBooks/UploadFile',
                type: 'Post',
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {
                    _eBookService.createEBookAndAuthors(ebookAndAuthor).done(function () {
                        _$modal.modal('hide');
                        _$form[0].reset();
                        abp.notify.info(l('savedsuccessfully'));
                        _$eBooksTable.ajax.reload();
                    }).fail(function (data) {
                        abp.ui.clearBusy(_$modal);
                        abp.notify.error(l('ErrorWhileSaving'));
                    }).always(function () {
                        abp.ui.clearBusy(_$modal);
                    });

                },
                error: function (e) {
                    abp.ui.clearBusy(_$modal);
                    abp.notify.error("Error while uploading...");

                }
            });
        } else {
            abp.notify.error("Please provide pdf file");
        }

    });

    $(document).on('click', '.delete-ebook', function () {
        var eBookId = $(this).attr("data-ebook-id");
        var eBookName = $(this).attr('data-ebook-name');

        deleteEBook(eBookId, eBookName);
    });

    function deleteEBook(eBookId, eBookName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                eBookName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _eBookService.delete({
                        id: eBookId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$eBooksTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-ebook', function (e) {
        var eBookId = $(this).attr("data-ebook-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'EBooks/EditModal?ebookId=' + eBookId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#EBookEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#EBookCreateModal"]', (e) => {
        $('.nav-tabs a[href="#ebook-details"]').tab('show')
    });

    abp.event.on('ebook.edited', (data) => {
        _$eBooksTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$eBooksTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$eBooksTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
