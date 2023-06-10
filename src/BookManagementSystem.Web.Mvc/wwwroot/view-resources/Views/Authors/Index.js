(function ($) {
    var _authorService = abp.services.app.author,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#AuthorCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#AuthorsTable');
    console.log(_authorService);

    var _$authorsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _authorService.getAll,
            inputFilter: function () {
                return $('#AuthorsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$authorsTable.draw(false)
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
                data: 'authorName',
                sortable: false
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-author" data-author-id="${row.id}" data-toggle="modal" data-target="#AuthorEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-author" data-author-id="${row.id}" data-author-name="${row.authorName}">`,
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
        var author = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _authorService.create(author).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$authorsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });
    console.log(_$authorsTable);

    $(document).on('click', '.delete-author', function () {
        var authorId = $(this).attr("data-author-id");
        var authorName = $(this).attr('data-author-name');

        console.log(authorId);
        console.log(authorName);

        deleteAuthor(authorId, authorName);
    });

    $(document).on('click', '.edit-author', function (e) {
        var authorId = $(this).attr("data-author-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Authors/EditModal?authorId=' + authorId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#AuthorEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    abp.event.on('author.edited', (data) => {
        _$authorsTable.ajax.reload();
    });

    function deleteAuthor(authorId, authorName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                authorName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _authorService.delete({
                        id: authorId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$authorsTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$authorsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$authorsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
