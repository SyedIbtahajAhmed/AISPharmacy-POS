using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Models.Products.ProductManager
{
    public class ProductManager : DomainService, IProductManager
    {
        public IRepository<Product> productrepository;

        public ProductManager(IRepository<Product> _repository)
        {
            productrepository = _repository;
        }

        //Creating Product
        public async Task<Product> CreateProduct(Product product)
        {
            var newProduct = productrepository.FirstOrDefault(x => x.Name.Trim().Replace(" ", "").ToLower() == product.Name.Trim().Replace(" ", "").ToLower());
            if (newProduct != null)
            {
                throw new UserFriendlyException("Product Already Exist!");
            }
            else
            {
                return await productrepository.InsertAsync(product);
            }
        }


        //Deleting Product
        public void DeleteProduct(int productId)
        {
            var product = productrepository.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                productrepository.Delete(product);
            }
            else
            {
                throw new UserFriendlyException("Cannot Find Product To Delete!");
            }
        }



        //Getting Products
        public List<Product> GetAllProducts(string keyword)
        {
            if (keyword == null)
            {
                var products = productrepository.GetAll().Include(x => x.Company)
                .ToList();

                return products;
            }
            else
            {
                var products = productrepository.GetAll().Include(x => x.Company)
                    .Where(x =>
                    (
                        x.Name.ToLower().Contains(keyword)
                    ))
                    .ToList();

                return products;
            }
        }

        public Product GetProduct(int productId)
        {
            var productFound = productrepository.GetAll().Where(x => x.Id == productId).Include(x => x.Company);
            if (productFound != null)
            {
                return productrepository.Get(productId);
            }
            else
            {
                throw new UserFriendlyException("No Product Found!");
            }
        }



        //Updating Product
        public void UpdateProduct(Product product)
        {
            var productFound = productrepository.FirstOrDefault(x => x.Id == product.Id);
            if (productFound == null)
            {
                throw new UserFriendlyException("Product Not Found For Updating.");
            }
            ObjectMapper.Map(product, productFound);
        }
    }
}
