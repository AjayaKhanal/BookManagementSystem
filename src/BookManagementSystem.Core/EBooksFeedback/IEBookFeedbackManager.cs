using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooksFeedback
{
    public interface IEBookFeedbackManager
    {
        Task CreateEBookFeedbackAsync(EBookFeedback feedback);
        Task<List<EBookFeedback>> GetAllEBookFeedbacksAsync();
        Task UpdateEBookFeedbackAsync(EBookFeedback feedback);
    }
}
