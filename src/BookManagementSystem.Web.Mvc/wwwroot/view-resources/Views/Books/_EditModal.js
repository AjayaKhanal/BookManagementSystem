(function ($) {
    var _bookService = abp.services.app.book,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#BookEditModal'),
        _$form = _$modal.find('form');

    $(document).ready(function () {
        $.ajax({
            url: '/Books/GetAuthors',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var select = $('#author');
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

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var book_details = _$form.serializeFormToObject();
        console.log(book_details);

        var book = {
            id: book_details.Id,
            bookName: book_details.BookName,
            quantity: book_details.Quantity,
            description: book_details.Description
        };
        console.log(book);

        var author = {
            id: book_details.AuthorId
        }; console.log(author);

        var bookAndAuthor = {
            book: book,
            author: author
        }; console.log(bookAndAuthor);

        abp.ui.setBusy(_$form);
        _bookService.updateBookAndAuthors(bookAndAuthor).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('book.edited', book);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
