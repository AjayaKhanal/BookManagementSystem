using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementSystem.EBookFeedbacks.Dto;
using Abp.Domain.Repositories;
using BookManagementSystem.EBooksFeedback;
using Abp.Timing;
using Abp.Runtime.Session;
using Abp.Application.Services.Dto;

namespace BookManagementSystem.EBookFeedbacks
{
    public class EBookFeedbackAppService : AsyncCrudAppService<EBookFeedback, EBookFeedbackDto, int, PagedEBookFeedbackRequestDto, AddEBookFeedbackDto, EBookFeedbackDto>, IEBookFeedbackAppService
    {
        private readonly IEBookFeedbackManager _feedbackManager;

        public EBookFeedbackAppService(
            IRepository<EBookFeedback> repository,
            IEBookFeedbackManager feedbackManager) : base(repository)
        {
            _feedbackManager = feedbackManager;

        }

        public async Task<EBookFeedbackDto> CreateEBookFeedbackAsync(AddEBookFeedbackDto input)
        {
            CheckCreatePermission();

            var feedback = new EBookFeedback
            {
                FeedbackDescription = input.FeedbackDescription,
                EBookId = input.EBookId
            };
            feedback.CreationTime = Clock.Now;
            feedback.CreatorUserId = AbpSession.GetUserId();
            await _feedbackManager.CreateEBookFeedbackAsync(feedback);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new EBookFeedbackDto
            {
                FeedbackDescription = input.FeedbackDescription,
                EBookId = input.EBookId,
                CreationTime = Clock.Now,
                CreatedBy = AbpSession.GetUserId().ToString()
            };

        }

        public async Task<ListResultDto<EBookFeedbackDto>> GetEBookFeedbacksAsync(int id)
        {
            var feedbacks = await _feedbackManager.GetAllEBookFeedbacksAsync();
            var feedbackDetails = feedbacks.Where(fe => fe.EBookId == id);
            
            return new ListResultDto<EBookFeedbackDto>(ObjectMapper.Map<List<EBookFeedbackDto>>(feedbackDetails));
        }
    }
}
