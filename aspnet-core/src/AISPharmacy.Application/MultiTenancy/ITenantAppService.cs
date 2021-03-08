using Abp.Application.Services;
using AISPharmacy.MultiTenancy.Dto;

namespace AISPharmacy.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

