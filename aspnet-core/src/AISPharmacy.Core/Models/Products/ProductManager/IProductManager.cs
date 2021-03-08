using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.Products.ProductManager
{
    public  interface IProductManager : IDomainService
    {
        List<Product> GetAllProducts(string keyword);

        Product GetProduct(int productId);
        Task<Product> CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
