using Abp.Application.Services;
using AISPharmacy.Companies.DTO;
using AISPharmacy.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Companies
{
    public interface ICompanyAppService: IApplicationService
    {
        List<GetCompanyOutputDto> GetAllCompanies(string keyword);

        GetCompanyOutputDto GetCompanyById(int companyId);

        List<GetProductOutputDto> GetProductsOfCompany(int companyId, string keyword);

        Task Create(CreateCompanyInputDto company);

        void Update(UpdateCompanyInputDto company);

        void Delete(DeleteCompanyInputDto company);
    }
}
