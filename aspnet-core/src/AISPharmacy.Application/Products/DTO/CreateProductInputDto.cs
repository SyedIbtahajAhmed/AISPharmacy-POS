﻿using Abp.AutoMapper;
using AISPharmacy.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Products.DTO
{
    [AutoMap(typeof(Product))]
    public class CreateProductInputDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int? CompanyId { get; set; }

        public int? GenericId { get; set; }

    }
}
