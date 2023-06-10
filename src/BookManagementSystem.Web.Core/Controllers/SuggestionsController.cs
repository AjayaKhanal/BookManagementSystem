using BookManagementSystem.Models.Suggestions;
using BookManagementSystem.Suggestions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class SuggestionsController : BookManagementSystemControllerBase
    {
        private readonly ISuggestionAppService _suggestionAppService;

        public SuggestionsController(ISuggestionAppService suggestionAppService)
        {
            _suggestionAppService = suggestionAppService;
        }

        public async Task<IActionResult> Index()
        {
            var suggestions = (await _suggestionAppService.GetSuggestionsAsync()).Items;
            var model = new SuggestionListViewModel() { 
                Suggestion = suggestions
            };
            return View(model);
        }
    }
}
