using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks
{
    public class FeedbackManager : DomainService, IFeedbackManager
    {
        private readonly IRepository<Feedback> _bookFeedbackRepository;

        public FeedbackManager(IRepository<Feedback> feedbackRepository)
        {
            _bookFeedbackRepository = feedbackRepository;
        }
        public async Task CreateFeedbackAsync(Feedback feedback)
        {
            await _bookFeedbackRepository.InsertAsync(feedback);
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            return await _bookFeedbackRepository.GetAllListAsync();
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            await _bookFeedbackRepository.UpdateAsync(feedback);
        }
    }
}
