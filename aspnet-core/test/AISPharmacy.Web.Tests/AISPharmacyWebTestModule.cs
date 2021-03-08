using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AISPharmacy.EntityFrameworkCore;
using AISPharmacy.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AISPharmacy.Web.Tests
{
    [DependsOn(
        typeof(AISPharmacyWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AISPharmacyWebTestModule : AbpModule
    {
        public AISPharmacyWebTestModule(AISPharmacyEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AISPharmacyWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AISPharmacyWebMvcModule).Assembly);
        }
    }
}