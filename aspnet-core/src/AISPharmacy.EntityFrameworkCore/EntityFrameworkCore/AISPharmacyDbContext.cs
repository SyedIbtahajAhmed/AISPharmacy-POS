using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AISPharmacy.Authorization.Roles;
using AISPharmacy.Authorization.Users;
using AISPharmacy.MultiTenancy;
using AISPharmacy.Models.Products;
using AISPharmacy.Models.Companies;
using AISPharmacy.Models.MedicineGenerics;

namespace AISPharmacy.EntityFrameworkCore
{
    public class AISPharmacyDbContext : AbpZeroDbContext<Tenant, Role, User, AISPharmacyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<MedicineGeneric> MedicineGenerics { get; set; }

        public AISPharmacyDbContext(DbContextOptions<AISPharmacyDbContext> options)
            : base(options)
        {
        }
    }
}
