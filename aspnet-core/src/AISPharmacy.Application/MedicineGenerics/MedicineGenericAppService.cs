using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AISPharmacy.Authorization;
using AISPharmacy.MedicineGenerics.DTO;
using AISPharmacy.Models.MedicineGenerics;
using AISPharmacy.Models.MedicineGenerics.MedicineGenericsManager;
using AISPharmacy.Models.Products;
using AISPharmacy.Products;
using AISPharmacy.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.MedicineGenerics
{
    [AbpAuthorize(PermissionNames.Pages_MedicineGenerics)]
    public class MedicineGenericAppService : ApplicationService, IMedicineGenericsAppService
    {

        private readonly IMedicineGenericsManager medicineGenericsManager;

        public MedicineGenericAppService(IMedicineGenericsManager genericManager)
        {
            this.medicineGenericsManager = genericManager;
        }

        public async Task Create(CreateGenericInputDto generic)
        {
            MedicineGeneric output = new MedicineGeneric();
            CustomMapper<CreateGenericInputDto, MedicineGeneric>.Map(generic, output);
            await this.medicineGenericsManager.Create(output);
        }

        public void Delete(DeleteGenericInputDto generic)
        {
            MedicineGeneric output = new MedicineGeneric();
            CustomMapper<DeleteGenericInputDto, MedicineGeneric>.Map(generic, output);
            this.medicineGenericsManager.Delete(output.Id);
        }

        public List<GetGenericOutputDto> GetAllGenerics(string keyword)
        {
            var allGenerics = this.medicineGenericsManager.GetAllMedicineGenerics(keyword).ToList();
            List<GetGenericOutputDto> output = new List<GetGenericOutputDto>();
            for (var i = 0; i < allGenerics.Count; i++)
            {
                output.Add(new GetGenericOutputDto());
                CustomMapper<MedicineGeneric, GetGenericOutputDto>.Map(allGenerics[i], output[i]);
            }
            return output;
        }

        public GetGenericOutputDto GetGenericById(int genericId)
        {
            var foundGeneric = this.medicineGenericsManager.GetMedicineGenerics(genericId);
            GetGenericOutputDto output = new GetGenericOutputDto();
            CustomMapper<MedicineGeneric, GetGenericOutputDto>.Map(foundGeneric, output);
            return output;
        }

        public void DeleteHard(DeleteGenericInputDto generic)
        {
            MedicineGeneric output = new MedicineGeneric();
            CustomMapper<DeleteGenericInputDto, MedicineGeneric>.Map(generic, output);
            this.medicineGenericsManager.DeleteHard(output.Id);
        }

        public void Update(UpdateGenericInputDto generic)
        {
            MedicineGeneric updateGeneric = new MedicineGeneric();
            CustomMapper<UpdateGenericInputDto, MedicineGeneric>.Map(generic, updateGeneric);
            this.medicineGenericsManager.Update(updateGeneric);
        }

        public List<GetProductOutputDto> GetProductsOfGeneric(int genericId, string keyword)
        {
            var allProducts = medicineGenericsManager.GetProductsOfGenerics(genericId, keyword);
            List<GetProductOutputDto> filteredProducts = new List<GetProductOutputDto>();

            for (var i = 0; i < allProducts.Count; i++)
            {
                filteredProducts.Add(new GetProductOutputDto());
                CustomMapper<Product, GetProductOutputDto>.Map(allProducts[i], filteredProducts[i]);
            }

            return filteredProducts;
        }
    }
}
