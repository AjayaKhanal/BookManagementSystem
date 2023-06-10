(function ($) {
    $(document).ready(function () {
        var _bookReturnService = abp.services.app.bookBorrow,
            _$table = $('#BookReturnsTable');

        var id = abp.session.userId;
        _$table.find('tbody').empty();
        abp.ui.setBusy();
        _bookReturnService.getBookBorrowingDetails(id).done(function (data) {

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
                        $('<td>').text(borrowDate),
                        $('<td>').text(daysLate),

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
            abp.ui.clearBusy();
        });
    });
})(jQuery);