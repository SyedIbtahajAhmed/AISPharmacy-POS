using Abp.Domain.Services;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.Companies.CompanyManager
{
    public interface ICompanyManager: IDomainService
    {
        IEnumerable<Company> GetAllCompanies(string keyword);

        Company GetCompany(int companyId);

        IEnumerable<Product> GetProductsOfCompany(int companyId, string keyword);

        Task<Company> Create(Company company);

        void Update(Company company);

        void Delete(int companyId);
    }
}
