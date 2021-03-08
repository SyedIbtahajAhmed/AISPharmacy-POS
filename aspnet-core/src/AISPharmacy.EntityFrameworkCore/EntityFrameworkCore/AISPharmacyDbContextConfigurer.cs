using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AISPharmacy.EntityFrameworkCore
{
    public static class AISPharmacyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AISPharmacyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AISPharmacyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
