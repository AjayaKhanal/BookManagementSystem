(function ($) {
    var _authorService = abp.services.app.author,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#AuthorEditModal'),
        _$form = _$modal.find('form');
    console.log(_authorService);

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var author = _$form.serializeFormToObject();
        console.log(author);

        abp.ui.setBusy(_$form);
        _authorService.update(author).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('author.edited', author);
        }).fail(function (error) {
            abp.notify.error(error.responseJSON.error.message);
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
