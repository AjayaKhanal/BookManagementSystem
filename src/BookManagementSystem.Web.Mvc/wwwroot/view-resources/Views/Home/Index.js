(function ($) {
    var _feedbackAppService = abp.services.app.eBookFeedback,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#EBookDetails'),
        _$feedbackList = $('#EBookFeedbackList');
    console.log(_feedbackAppService);

    $("#readBook").on("click", function () {
        console.log("Reading book..");
        var id = $("#ebookId").val();
        var url = "/Home/ViewPdf/" + id;

        $.ajax({
            url: "/BookHistory/Create",
            data: { userId: abp.session.userId, eBookId: id },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
            },
            error: function (e) {
                abp.notify.error(l('Error...'));
            }

        });

    });

    _$modal.find('.feedback-post').on('click', (e) => {
        e.preventDefault();
        var feedback = $('#feedback').val();
        var id = $('#ebookId').val();

        var feedbackDetails = {
            feedbackDescription: feedback,
            eBookId: id
        };
        console.log(feedbackDetails);
        abp.ui.setBusy(_$modal);
        _feedbackAppService.createEBookFeedback(feedbackDetails).done(function () {

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
        var id = $('#ebookId').val();
        console.log("ID " + id);

        _feedbackAppService.getEBookFeedbacks(id).done(function (result) {
            console.log(result);
            _$feedbackList.empty();
            if (result.items && result.items.length > 0) {
                $.each(result.items, function (i, item) {
                    var $li = $('<li>').addClass('list-group-item mt-4');
                    $('<h4>').addClass('list-group-item-heading').text(item.feedbackDescription).appendTo($li);
                    $('<div>').addClass('list-group-item-text').text(moment(item.creationTime).format('YYYY-MM-DD HH:mm:ss')).appendTo($li);
                    _$feedbackList.append($li);
                });
            } else {
                $('<li>').addClass('list-group-item').text(l('No Feedbacks Yet')).appendTo(_$feedbackList);
            }
        }).fail(function (data) {
            console.log(data);
            abp.notify.error(l('Error While getting feedbacks'));
        }).always(function () {
            abp.ui.clearBusy(_$feedbackList);
        });
    }
    loadFeedbacks();
})(jQuery)