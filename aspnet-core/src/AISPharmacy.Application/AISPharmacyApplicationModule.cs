using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AISPharmacy.Authorization;

namespace AISPharmacy
{
    [DependsOn(
        typeof(AISPharmacyCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AISPharmacyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AISPharmacyAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AISPharmacyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
