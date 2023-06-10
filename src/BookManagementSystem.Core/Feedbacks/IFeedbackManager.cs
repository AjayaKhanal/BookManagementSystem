using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks
{
    public interface IFeedbackManager
    {
        Task CreateFeedbackAsync(Feedback feedback);
        Task<List<Feedback>> GetAllFeedbacksAsync();
        Task UpdateFeedbackAsync(Feedback feedback);
    }
}
