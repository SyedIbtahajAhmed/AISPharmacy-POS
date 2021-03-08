using Abp.AutoMapper;
using AISPharmacy.Models.MedicineGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.MedicineGenerics.DTO
{
    [AutoMap(typeof(MedicineGeneric))]
    public class DeleteGenericInputDto
    {
        public int Id { get; set; }
    }
}
