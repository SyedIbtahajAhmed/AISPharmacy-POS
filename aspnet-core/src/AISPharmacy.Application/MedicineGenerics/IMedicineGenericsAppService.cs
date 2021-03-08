using Abp.Application.Services;
using AISPharmacy.MedicineGenerics.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.MedicineGenerics
{
    public interface IMedicineGenericsAppService: IApplicationService
    {
        List<GetGenericOutputDto> GetAllGenerics(string keyword);

        GetGenericOutputDto GetGenericById(int genericId);

        Task Create(CreateGenericInputDto generic);

        void Update(UpdateGenericInputDto generic);

        void Delete(DeleteGenericInputDto generic);
    }
}
