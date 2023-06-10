using System.Threading.Tasks;
using Abp.Application.Services;
using BookManagementSystem.Sessions.Dto;

namespace BookManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
