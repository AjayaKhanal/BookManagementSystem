(function ($) {
    var _feedbackAppService = abp.services.app.feedback,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#BookDetails'),
        _$feedbackList = $('#BookFeedbackList');
    console.log(_feedbackAppService);

    _$modal.find('.feedback-post').on('click', (e) => {
        e.preventDefault();

        var feedback = $('#feedback').val();
        var id = $('#bookId').val();

        var feedbackDetails = {
            feedbackDescription: feedback,
            bookId: id
        };
        console.log(feedbackDetails);
        abp.ui.setBusy(_$modal);
        _feedbackAppService.createFeedback(feedbackDetails).done(function () {

            abp.notify.info(l('SavedSuccessfully'));
            $('#feedback').val("");
            loadFeedbacks();
        }).fail(function (data) {
            console.log(data);
            abp.notify.error(l('Error While Sending'));
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    function loadFeedbacks() {
        abp.ui.setBusy(_$feedbackList);
        var id = $('#bookId').val();
        _feedbackAppService.getBookFeedbacks(id).done(function (result) {
            console.log(result);
            _$feedbackList.empty();
            if (result.items && result.items.length > 0) {
                $.each(result.items, function (i, item) {
                    var $li = $('<li>').addClass('list-group-item mt-4');
                    $('<h5>').addClass('list-group-item-heading').text(item.feedbackDescription).appendTo($li);
                    $('<div>').addClass('list-group-item-text').text(moment(item.creationTime).format('YYYY-MM-DD HH:mm:ss')).appendTo($li);
                    _$feedbackList.append($li);
                });
            } else {
                $('<li>').addClass('list-group-item').text(l('No Feedbacks Yet')).appendTo(_$feedbackList);
            }
        }).always(function () {
            abp.ui.clearBusy(_$feedbackList);
        });
    }
    loadFeedbacks();
})(jQuery); 