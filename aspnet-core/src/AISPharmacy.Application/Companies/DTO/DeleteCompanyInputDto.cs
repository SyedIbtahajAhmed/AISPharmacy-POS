using Abp.AutoMapper;
using AISPharmacy.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Companies.DTO
{
    [AutoMap(typeof(Company))]
    public class DeleteCompanyInputDto
    {
        public int Id { get; set; }
    }
}
