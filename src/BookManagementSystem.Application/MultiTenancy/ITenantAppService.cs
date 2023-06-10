using Abp.Application.Services;
using BookManagementSystem.MultiTenancy.Dto;

namespace BookManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

