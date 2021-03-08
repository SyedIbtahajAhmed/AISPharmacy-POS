using System.Threading.Tasks;
using Abp.Application.Services;
using AISPharmacy.Sessions.Dto;

namespace AISPharmacy.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
