using Abp.AutoMapper;
using AISPharmacy.Models.Companies;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Companies.DTO
{
    [AutoMap(typeof(Company))]
    public class GetCompanyOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public string Registration { get; set; }

    }
}
