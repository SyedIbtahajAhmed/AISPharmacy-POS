using Abp.Domain.Services;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.MedicineGenerics.MedicineGenericsManager
{
    public interface IMedicineGenericsManager: IDomainService
    {
        List<MedicineGeneric> GetAllMedicineGenerics(string keyword);

        MedicineGeneric GetMedicineGenerics(int id);

        List<Product> GetProductsOfGenerics(int genericId, string keyword);

        Task<MedicineGeneric> Create(MedicineGeneric medicineGenerics);

        void Update(MedicineGeneric medicineGenerics);

        void Delete(int id);

        void DeleteHard (int id);
    }
}
