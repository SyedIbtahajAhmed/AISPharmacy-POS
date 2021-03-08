using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.MedicineGenerics
{
    [AutoMap(typeof(MedicineGeneric))]
    [Table("MedcineGenericsTable")]
    public class MedicineGeneric: FullAuditedEntity
    {
        public string Name { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]

        public virtual Product Product { get; set; }
    }
}
