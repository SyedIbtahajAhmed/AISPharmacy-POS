using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AISPharmacy.Models.Companies;
using AISPharmacy.Models.MedicineGenerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.Products
{
    [AutoMap(typeof(Product))]
    [Table("ProductsTable")]
    public class Product : FullAuditedEntity
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public int? GenericId { get; set; }

        [ForeignKey("GenericId")]
        public virtual MedicineGeneric Generic { get; set; }
    }
}
