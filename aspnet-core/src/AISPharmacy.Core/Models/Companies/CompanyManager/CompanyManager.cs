using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using AISPharmacy.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.Companies.CompanyManager
{
    public class CompanyManager : DomainService, ICompanyManager
    {

        private readonly IRepository<Company, int> repository;

        private readonly IRepository<Product, int> productRepository;

        public CompanyManager(IRepository<Company> _repository, IRepository<Product> _repository2) 
        {
            this.repository = _repository;
            this.productRepository = _repository2;
        }


        //Creating Company
        public async Task<Company> Create(Company company)
        {
            var newCompany = repository.FirstOrDefault(x => x.Name.Trim().Replace(" ", "").ToLower() == company.Name.Trim().Replace(" ", "").ToLower());
            if (newCompany != null)
            {
                throw new UserFriendlyException("Company Already Exist");
            }
            else
            {
                return await repository.InsertAsync(company);
            }
        }

        public void Delete(int companyId)
        {
            var existentCompany = repository.FirstOrDefault(x => x.Id == companyId);
            if (existentCompany != null)
            {
                repository.Delete(existentCompany);
            }
            else
            {
                throw new UserFriendlyException("Company Does Not Exist!");
            }
        }

        public List<Company> GetAllCompanies(string keyword)
        {
            if (keyword == null)
            {
                var products = repository.GetAllList();

                return products;
            }
            else
            {
                var products = repository.GetAll()
                    .Where(x =>
                    (
                        x.Name.ToLower().Contains(keyword)
                    )).ToList();

                return products;
            }
        }

        public Company GetCompany(int companyId)
        {
            var company = repository.Get(companyId);
            if (company != null)
            {
                return company;
            }
            else
            {
                throw new UserFriendlyException("Company Does Not Exist");
            }

        }

        public List<Product> GetProductsOfCompany(int companyId, string keyword)
        {
            if (keyword == null)
            {
                List<Product> products = productRepository.GetAll()
                .Include(x => x.Company)
                .Where(x => x.CompanyId == companyId)
                .ToList();

                return products;
            }
            else
            {
                List<Product> products = productRepository.GetAll()
                    .Include(x => x.Company)
                    .Where(x => (x.CompanyId == companyId) && x.Name.ToLower().Contains(keyword))
                    .ToList();

                return products;
            }
        }

        public void Update(Company company)
        {
            var foundCompany = repository.FirstOrDefault(x => x.Id == company.Id);
            if (foundCompany != null)
            {
                ObjectMapper.Map(company, foundCompany);
            }
            else
            {
                throw new UserFriendlyException("Company Not Found!");
            }
        }
    }
}
