(function ($) {
    var _bookService = abp.services.app.book,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#BookCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#BooksTable');

    $(document).ready(function () {
        $.ajax({
            url: '/Books/GetAuthors',
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
                console.log("Error: " + e);
            }
        });
    });

    var _$booksTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _bookService.getAll,
            inputFilter: function () {
                return $('#BooksSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$BooksTable.draw(false)
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
                data: 'bookName',
                sortable: false,
                render: (data, type, row, meta) => {
                    return `<a href="/Books/BookDetails/${row.id}">${data}</a>`;
                }
            },
            {
                targets: 2,
                data: 'quantity',
                sortable: false
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    var isAdminOrStaff = currentUserRole === 'Admin' || currentUserRole === 'Staff';
                    console.log(isAdminOrStaff);

                    if (isAdminOrStaff) {
                    
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-book" data-book-id="${row.id}" data-toggle="modal" data-target="#BookEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-book" data-book-id="${row.id}" data-book-name="${row.bookName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                    } else {
                        return '';
                    }
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var book_details = _$form.serializeFormToObject();
        console.log(book_details);

        var book = {
            bookName: book_details.BookName,
            quantity: book_details.Quantity,
            description: book_details.Description
        };
        console.log(book);

        var author = {
            id: book_details.AuthorId
        }
        console.log(author);

        var bookAndAuthor = {
            book: book,
            author: author
        };
        console.log(bookAndAuthor);

        abp.ui.setBusy(_$modal);
        _bookService.createBookAndAuthors(bookAndAuthor).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$booksTable.ajax.reload();
        }).fail(function (data) {
            console.log(data);
            abp.notify.error(l('ErrorWhileSaving'));
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-book', function () {
        var bookId = $(this).attr("data-book-id");
        var bookName = $(this).attr('data-book-name');

        deleteBook(bookId, bookName);
    });

    function deleteBook(bookId, bookName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                bookName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _bookService.delete({
                        id: bookId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$booksTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-book', function (e) {
        var bookId = $(this).attr("data-book-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Books/EditModal?Id=' + bookId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#BookEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#BookCreateModal"]', (e) => {
        $('.nav-tabs a[href="#book-details"]').tab('show')
    });

    abp.event.on('book.edited', (data) => {
        _$booksTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$booksTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$booksTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
