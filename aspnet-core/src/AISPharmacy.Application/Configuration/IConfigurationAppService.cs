using System.Threading.Tasks;
using AISPharmacy.Configuration.Dto;

namespace AISPharmacy.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
