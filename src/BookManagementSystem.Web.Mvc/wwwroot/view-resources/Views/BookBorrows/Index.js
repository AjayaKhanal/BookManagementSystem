(function ($) {
    var _bookBorrowService = abp.services.app.bookBorrow,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#modal'),
        _$form = _$modal.find('form');

    _$form.find('.borrow-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }
        
        var book = $('#book').val();
        var student = $('#email').val();
        var author = $('#author').val();


        var book_borrow = {
            bookId : book,
            userId : student,
            authorId : author
        };
        console.log(book_borrow);
        
        abp.ui.setBusy(_$modal);
        _bookBorrowService.create(book_borrow).done(function () {
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
        }).fail(function (data) {
            console.log(data);
            abp.notify.error(l('ErrorWhileSaving'));
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).ready(function () {
        $.ajax({
            url: '/BookBorrows/GetEmails',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var select = $('#email');
                $.each(data.result, function (index, email) {
                    select.append($('<option>', {
                        value: email.id,
                        text: email.email
                    }));
                });
            },
            error: function (e) {
            }
        });

        // Add event listener to email select element
        $('#email').on('change', function () {
            var selectedEmailId = $(this).val();
            if (selectedEmailId !== '') {
                // Retrieve and display student name
                $.ajax({
                    url: '/BookBorrows/GetStudentName',
                    type: 'GET',
                    dataType: 'json',
                    data: { id: selectedEmailId },
                    success: function (data) {
                        $('#student-name').val(data.result.studentName);
                    },
                    error: function (e) {
                    }
                });
            } else {
                // Clear student name input field if no email is selected
                $('#student-name').val('');
            }
        });
    });


    $(document).ready(function () {
        $.ajax({
            url: '/BookBorrows/GetAuthors',
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
            }
        });
    });

    $(document).ready(function () {
        $.ajax({
            url: '/BookBorrows/GetBooks',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var select = $('#book');
                $.each(data.result, function (index, book) {
                    select.append($('<option>', {
                        value: book.id,
                        text: book.bookName
                    }));
                });
            },
            error: function (e) {
            }
        });
    });
})(jQuery);