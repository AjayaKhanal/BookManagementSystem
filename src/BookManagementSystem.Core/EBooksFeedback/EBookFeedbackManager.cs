using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooksFeedback
{
    public class EBookFeedbackManager : DomainService, IEBookFeedbackManager
    {
        private readonly IRepository<EBookFeedback> _ebookFeedbackRepository;

        public EBookFeedbackManager(IRepository<EBookFeedback> feedbackRepository)
        {
            _ebookFeedbackRepository = feedbackRepository;
        }
        public async Task CreateEBookFeedbackAsync(EBookFeedback feedback)
        {
            await _ebookFeedbackRepository.InsertAsync(feedback);
        }

        public async Task<List<EBookFeedback>> GetAllEBookFeedbacksAsync()
        {
            return await _ebookFeedbackRepository.GetAllListAsync();
        }

        public async Task UpdateEBookFeedbackAsync(EBookFeedback feedback)
        {
            await _ebookFeedbackRepository.UpdateAsync(feedback);
        }
    }
}
