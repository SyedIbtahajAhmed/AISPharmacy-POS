using Abp.Application.Services;
using Abp.Authorization;
using AISPharmacy.Authorization;
using AISPharmacy.Companies.DTO;
using AISPharmacy.Models.Companies;
using AISPharmacy.Models.Companies.CompanyManager;
using AISPharmacy.Models.Products;
using AISPharmacy.Models.Products.ProductManager;
using AISPharmacy.Products;
using AISPharmacy.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Companies
{
    //[AbpAuthorize(PermissionNames.Pages_Companies)]

    public class CompanyAppService : ApplicationService, ICompanyAppService
    {

        private readonly ICompanyManager companyManager;

        public CompanyAppService(ICompanyManager _companyManager)
        {
            companyManager = _companyManager;
        }


        public async Task Create(CreateCompanyInputDto company)
        {
            Company newcompany = new Company();
            CustomMapper<CreateCompanyInputDto, Company>.Map(company, newcompany);
            await companyManager.Create(newcompany);
        }

        public void Delete(DeleteCompanyInputDto company)
        {
            Company foundCompany = new Company();
            CustomMapper<Company, DeleteCompanyInputDto>.Map(foundCompany, company);
            companyManager.Delete(foundCompany.Id);
        }

        public List<GetCompanyOutputDto> GetAllCompanies(string keyword)
        {
            var getAllCompanies = companyManager.GetAllCompanies(keyword).ToList();
            List<GetCompanyOutputDto> companies = new List<GetCompanyOutputDto>();
            for (var i = 0; i < getAllCompanies.Count; i++)
            {
                companies.Add(new GetCompanyOutputDto());
                CustomMapper<Company, GetCompanyOutputDto>.Map(getAllCompanies[i], companies[i]);
            }

            return companies;
        }

        public GetCompanyOutputDto GetCompanyById(int companyId)
        {
            var foundCompany = companyManager.GetCompany(companyId);
            GetCompanyOutputDto company = new GetCompanyOutputDto();

            CustomMapper<Company, GetCompanyOutputDto>.Map(foundCompany, company);
            return company;
        }

        public List<GetProductOutputDto> GetProductsOfCompany(int companyId, string keyword)
        {
            var getAllProducts = companyManager.GetProductsOfCompany(companyId, keyword).ToList();
            List<GetProductOutputDto> productsFiltered = new List<GetProductOutputDto>();
            for (var i = 0; i < getAllProducts.Count; i++)
            {
                productsFiltered.Add(new GetProductOutputDto());
                CustomMapper<Product, GetProductOutputDto>.Map(getAllProducts[i], productsFiltered[i]);
            }

            return productsFiltered;
        }

        public void Update(UpdateCompanyInputDto company)
        {
            Company updateCompany = new Company();
            CustomMapper<UpdateCompanyInputDto, Company>.Map(company, updateCompany);
            companyManager.Update(updateCompany);
        }
    }
}
