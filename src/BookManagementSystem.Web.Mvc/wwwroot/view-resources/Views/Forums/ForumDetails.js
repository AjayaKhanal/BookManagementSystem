(function ($) {
    var _forumReplyService = abp.services.app.forumReply,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#ForumDetails'),
        _$forumList = $('#ForumReplyList');
    console.log(_forumReplyService);

    _$modal.find('.reply-post').on('click', (e) => {
        e.preventDefault();

        var reply = $('#forumReply').val();
        var forum = $('#Id').val();

        var forumReply = {
            replyDescription: reply,
            forumId: forum
        };
        console.log(forumReply);

        abp.ui.setBusy(_$modal);
        _forumReplyService.create(forumReply).done(function () {
            console.log("Created");
            console.log("Reset");
            abp.notify.info(l('SavedSuccessfully'));
            console.log("Saved");
        }).fail(function (data) {
            console.log(data);
            abp.notify.error(l('Error While Sending'));
        }).always(function () {
            console.log("ClearBusy");
            abp.ui.clearBusy(_$modal);
        });
    });

    function LoadForumReply() {
        abp.ui.setBusy(_$forumList);
        var id = $('#Id').val();
        console.log(id);
        _forumReplyService.getForumReply(id).done(function (result) {
            console.log(result);
            console.log(result.items);
            _$forumList.empty();
            if (result.items && result.items.length > 0) {
                $.each(result.items, function (i, item) {
                    var $li = $('<li>').addClass('list-group-item mt-4');

                    $('<div>').addClass('list-group-item-text').text(moment(item.creationTime).format('YYYY-MM-DD HH:mm:ss')).appendTo($li);
                    $('<h5>').addClass('list-group-item-heading').text(item.replyDescripion).appendTo($li);
                    _$forumList.append($li);
                });
            } else {
                $('<li>').addClass('list-group-item').text(l('No Replies Yet...')).appendTo(_$forumList);
            }
        }).always(function () {
            abp.ui.clearBusy(_$forumList);
        });
    }
    LoadForumReply();
})(jQuery);