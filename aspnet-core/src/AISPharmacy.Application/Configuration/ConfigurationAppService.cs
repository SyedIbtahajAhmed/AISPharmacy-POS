using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AISPharmacy.Configuration.Dto;

namespace AISPharmacy.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AISPharmacyAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
