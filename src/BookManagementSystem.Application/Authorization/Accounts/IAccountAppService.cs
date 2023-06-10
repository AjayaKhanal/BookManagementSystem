using System.Threading.Tasks;
using Abp.Application.Services;
using BookManagementSystem.Authorization.Accounts.Dto;

namespace BookManagementSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
