using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.EBookFeedbacks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBookFeedbacks
{
    public interface IEBookFeedbackAppService : IAsyncCrudAppService<EBookFeedbackDto, int, PagedEBookFeedbackRequestDto, AddEBookFeedbackDto, EBookFeedbackDto>
    {
        Task<ListResultDto<EBookFeedbackDto>> GetEBookFeedbacksAsync(int id);
        Task<EBookFeedbackDto> CreateEBookFeedbackAsync(AddEBookFeedbackDto input);
    }
}
