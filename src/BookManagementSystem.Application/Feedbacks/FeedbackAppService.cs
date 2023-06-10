using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Feedbacks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks
{
    //[AbpAuthorize(PermissionNames.Feedbacks)]
    public class FeedbackAppService : AsyncCrudAppService<Feedback, FeedbackDto, int, PagedFeedbackRequestDto, AddFeedbackDto, FeedbackDto>, IFeedbackAppService
    {
        private readonly IFeedbackManager _feedbackManager;

        public FeedbackAppService(
            IRepository<Feedback> repository,
            IFeedbackManager feedbackManager) : base(repository)
        {
            _feedbackManager = feedbackManager;

        }

        public async Task<FeedbackDto> CreateFeedbackAsync(AddFeedbackDto input)
        {
            CheckCreatePermission();

            var feedback = new Feedback()
            {
                FeedbackDescription = input.FeedbackDescription,
                BookId = input.BookId
            };
            feedback.CreationTime = Clock.Now;
            feedback.CreatorUserId = AbpSession.GetUserId();
            await _feedbackManager.CreateFeedbackAsync(feedback);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new FeedbackDto()
            {
                FeedbackDescription = input.FeedbackDescription,
                BookId = input.BookId,
                CreationTime = Clock.Now,
                CreatedBy = AbpSession.GetUserId().ToString()
            };

        }

        public async Task<ListResultDto<FeedbackDto>> GetBookFeedbacksAsync(int id)
        {
            var feedbacks = await _feedbackManager.GetAllFeedbacksAsync();
            var feedbackDetails = feedbacks.Where(fe => fe.BookId == id);

            return new ListResultDto<FeedbackDto>(ObjectMapper.Map<List<FeedbackDto>>(feedbackDetails));
        }

    }
}
