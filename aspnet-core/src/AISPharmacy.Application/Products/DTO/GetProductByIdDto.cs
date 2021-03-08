using Abp.AutoMapper;
using AISPharmacy.Models.Companies;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Products.DTO
{
    [AutoMap(typeof(Product))]
    public class GetProductByIdDto
    {
        public int Id { get; set; }

    }
}
