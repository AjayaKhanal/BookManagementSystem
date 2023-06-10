(function ($) {
    var _forumService = abp.services.app.forum,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#ForumCreateModal'),
        _$form = _$modal.find('form'),
        _$forumList = $("#ForumList");
    console.log(_forumService);

    function loadForums(keyword) {
        abp.ui.setBusy(_$forumList);
        _forumService.getAll({ keyword: keyword }).done(function (result) {
            
            _$forumList.empty();
            if (result.items && result.items.length > 0) {
                $.each(result.items, function (i, item) {
                    console.log(result);
                    var $li = $('<li>').addClass('list-group-item mt-4');
                    // Add hidden input field to store forum ID
                    $('<input>').attr({
                        'type': 'hidden',
                        'class': 'forum-id',
                        'value': item.id // Set value to forum ID
                    }).appendTo($li);
                    $('<span>').addClass('list-group-item-text').text(item.createdBy).appendTo($li);
                    $('<h1>').addClass('list-group-item-heading').text(item.title).appendTo($li);
                    $('<div>').addClass('list-group-item-text').text(moment(item.creationTime).format('YYYY-MM-DD HH:mm:ss')).appendTo($li);
                    _$forumList.append($li);
                });

                _$forumList.find('li').hover(function () { // Attach hover event listener to list items
                    $(this).css('cursor', 'pointer'); // Set cursor to pointer when hovering over list item
                }).click(function () { // Attach click event listener to list items
                    var forumId = $(this).find('.forum-id').val(); // Get forum ID from hidden input field in clicked list item
                    console.log(forumId);
                    window.location.href = '/forums/ForumDetails?id=' + forumId; // Redirect to ForumDetails action with forum ID parameter
                });
            } else {
                $('<li>').addClass('list-group-item').text(l('NoForumsFound')).appendTo(_$forumList);
            }
        }).always(function () {
            abp.ui.clearBusy(_$forumList);
        });
    }

    $(document).ready(function () {
        loadForums();

        $('#btn-search').on('click', function (e) {
            e.preventDefault();
            var keyword = $('.txt-search').val();
            loadForums(keyword);
        });

        });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }
        var forum = _$form.serializeFormToObject();
        console.log(forum);

        abp.ui.setBusy(_$modal);
        _forumService.create(forum).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$forumList.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });
}

)(jQuery)
