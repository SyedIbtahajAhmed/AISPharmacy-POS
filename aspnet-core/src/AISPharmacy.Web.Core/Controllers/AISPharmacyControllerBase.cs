using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AISPharmacy.Controllers
{
    public abstract class AISPharmacyControllerBase: AbpController
    {
        protected AISPharmacyControllerBase()
        {
            LocalizationSourceName = AISPharmacyConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
