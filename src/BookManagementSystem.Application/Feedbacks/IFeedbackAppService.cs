using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.Feedbacks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks
{
    public interface IFeedbackAppService : IAsyncCrudAppService<FeedbackDto, int, PagedFeedbackRequestDto, AddFeedbackDto, FeedbackDto>
    {
        Task<ListResultDto<FeedbackDto>> GetBookFeedbacksAsync(int id);
        Task<FeedbackDto> CreateFeedbackAsync(AddFeedbackDto input);

    }
}
