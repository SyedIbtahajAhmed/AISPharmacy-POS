using Abp.AutoMapper;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Products.DTO
{
    [AutoMap(typeof(Product))]
    public class DeleteProductInputDto
    {
        public int Id { get; set; }
    }
}
