(function ($) {
    var _ebookService = abp.services.app.eBook,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#EBookEditModal'),
        _$form = _$modal.find('form');

    $(document).ready(function () {
        $.ajax({
            url: '/EBooks/GetAuthors',
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

        var form = _$form.serializeFormToObject();
        console.log(form);

        var ebook_form = document.querySelector('form[name="EBookEditForm"]');
        var ebook_details = new FormData(ebook_form);

        var ebook = {
            id: form.Id,
            ebookName: ebook_details.get("EBookName"),
            description: ebook_details.get("Description"),
            filePath: 'EBookFile\\' + ebook_details.get("FilePath").name
        };
        console.log(ebook);

        var author = {
            id: ebook_details.get("AuthorId")
        }; console.log(author);

        var ebookAndAuthor = {
            ebook: ebook,
            author: author
        }; console.log(ebookAndAuthor);

        if (ebook_details.get("FilePath").type === "application/pdf") {
            abp.ui.setBusy(_$modal);
            $.ajax({
                url: '/EBooks/UploadFile',
                type: 'Post',
                data: ebook_details,
                contentType: false,
                processData: false,
                success: function (data) {
                    _ebookService.updateEBookAuthors(ebookAndAuthor).done(function () {
                        _$modal.modal('hide');
                        abp.notify.info(l('SavedSuccessfully'));
                        abp.event.trigger('ebook.edited', ebook);
                    }).always(function () {
                        abp.ui.clearBusy(_$modal);
                    });
                    //abp.ui.clearBusy(_$modal);
                },
                error: function (e) {
                    abp.ui.clearBusy(_$modal);
                    abp.notify.error("Error while uploading...");

                }
            });
        } else {
            abp.notify.error("Please provide pdf file");
        }
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