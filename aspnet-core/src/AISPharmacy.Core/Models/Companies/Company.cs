using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.Companies
{
    [AutoMap(typeof(Company))]
    [Table("CompanyTable")]
    public class Company: FullAuditedEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public string Description { get; set; }

        public string Registration { get; set; }

    }
}
