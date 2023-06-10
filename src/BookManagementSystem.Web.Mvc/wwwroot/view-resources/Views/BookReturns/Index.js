(function ($) {
    var _bookReturnService = abp.services.app.bookBorrow,
        l = abp.localization.getSource('BookManagementSystem'),
        _$table = $('#BookReturnsTable'),
        _$modal = $('#modal'),
        _$form = _$modal.find('form');
    console.log(_bookReturnService);

    _$form.find('.return-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var student = $('#email').val();

        abp.ui.setBusy(_$modal);
        _bookReturnService.getBookBorrowingDetails(student).done(function (data) {
            _$form[0].reset();
            _$table.find('tbody').empty();
            console.log(data);

            if (data && data.length > 0) {
                $.each(data, function (index, item) {
                    var borrowDate = new Date(item.creationTime),
                        currentDate = new Date(),
                        daysBorrowed = Math.floor((currentDate - borrowDate) / (1000 * 60 * 60 * 24)),
                        daysLate = Math.max(0, daysBorrowed - 7);

                    var $row = $('<tr>').append(
                        $('<td>').text(index + 1),
                        $('<td>').text(item.bookName),
                        $('<td>').text(item.authorName),
                        $('<td>').text(daysLate),
                        $('<td>').append(
                            $('<button>').addClass('btn btn-success return-book').text('Return Book').attr('data-book-id', item.id).on('click', function () {
                                // Handle return book button click
                                console.log(item.id);
                                _bookReturnService.bookReturn(item.id);
                                _$table.DataTable().ajax.reload();
                            })
                        )
                    );
                    _$table.find('tbody').append($row);
                });
            } else {
                var $row = $('<tr>').append(
                    $('<td colspan="5">').text('No Book Borrow Data')
                );
                _$table.find('tbody').append($row);
            }
        }).fail(function (data) {
            console.log(data);
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).ready(function () {
        $.ajax({
            url: '/BookReturns/GetEmails',
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
})(jQuery);