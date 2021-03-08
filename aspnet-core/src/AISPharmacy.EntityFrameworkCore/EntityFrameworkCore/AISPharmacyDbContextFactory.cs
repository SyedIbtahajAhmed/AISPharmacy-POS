using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AISPharmacy.Configuration;
using AISPharmacy.Web;

namespace AISPharmacy.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AISPharmacyDbContextFactory : IDesignTimeDbContextFactory<AISPharmacyDbContext>
    {
        public AISPharmacyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AISPharmacyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AISPharmacyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AISPharmacyConsts.ConnectionStringName));

            return new AISPharmacyDbContext(builder.Options);
        }
    }
}
