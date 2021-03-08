using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AISPharmacy.Configuration;

namespace AISPharmacy.Web.Host.Startup
{
    [DependsOn(
       typeof(AISPharmacyWebCoreModule))]
    public class AISPharmacyWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AISPharmacyWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AISPharmacyWebHostModule).GetAssembly());
        }
    }
}
