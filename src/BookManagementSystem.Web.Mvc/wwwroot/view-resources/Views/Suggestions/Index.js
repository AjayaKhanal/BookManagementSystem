(function ($) {
    var _suggestionService = abp.services.app.suggestion,
        l = abp.localization.getSource('BookManagementSystem'),
        _$modal = $('#modal'),
        _$form = _$modal.find('form'),
        _$table = $('#SuggestionsTable');
    console.log(_suggestionService);
    
    var _$suggestionsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _suggestionService.getAll
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$suggestionsTable.draw(true)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            //{
            //    targets: 0,
            //    className: 'control',
            //    defaultContent: '',
            //},
            {
                targets: 0,
                data: 'suggestionDescription',
                sortable: false
            }
        ]
    });
    console.log(_$suggestionsTable);

    $(document).ready(function () {
        // Hide the #hidden-section element initially
        $('#hidden-section').hide();

        $('#view-all-suggestion').click(function () {
            // Toggle the visibility of the #hidden-section element
            $('#hidden-section').toggle();

            // Change the text of the button
            var buttonText = $(this).val();
            if (buttonText === 'View All Suggestions') {
                $(this).val('Hide All Suggestions');
            } else {
                $(this).val('View All Suggestions');
            }

        });

    });


    //Add a click event handler to the "Add Suggestion" button
    $('input[value="Add Suggestion"]').click(function () {
        // Get the value of the Suggestion Description input
        //var suggestionDescription = $('#suggestionDescription').val();

        // get form data using serializeFormToObject() method
        var suggestionsDescription = $('form[name="addSuggestionForm"]').serializeFormToObject();
        console.log(suggestionsDescription);


        // Call the suggestion service to add the new suggestion
        _suggestionService.addSuggestion(suggestionsDescription).done(function () {
            // Clear the Suggestion Description input
            $('#suggestionDescription').val('');

            // Reload the SuggestionsTable to show the newly added suggestion
            _$suggestionsTable.ajax.reload();
        });

    });
})(jQuery);