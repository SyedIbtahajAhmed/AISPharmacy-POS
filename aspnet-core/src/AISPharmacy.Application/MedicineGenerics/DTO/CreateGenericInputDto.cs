using Abp.AutoMapper;
using AISPharmacy.Models.MedicineGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.MedicineGenerics.DTO { 

    [AutoMap(typeof(MedicineGeneric))]
    public class CreateGenericInputDto
    {
        public string Name { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public int? ProductId { get; set; }
    }
}
