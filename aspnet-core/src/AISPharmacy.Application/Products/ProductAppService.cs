    using Abp.Application.Services;
using Abp.Authorization;
using AISPharmacy.Authorization;
using AISPharmacy.Models.Products;
using AISPharmacy.Models.Products.ProductManager;
using AISPharmacy.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IProductManager productManager;

        public ProductAppService(IProductManager _productManager)
        {
            productManager = _productManager;
        }

        public async Task Create(CreateProductInputDto product)
        {
            Product output = new Product();
            CustomMapper<CreateProductInputDto, Product>.Map(product, output);
            await productManager.CreateProduct(output);
        }

        public void Delete(DeleteProductInputDto productId)
        {
            Product output = new Product();
            CustomMapper<DeleteProductInputDto, Product>.Map(productId, output);
            productManager.DeleteProduct(output.Id);
        }

        public List<GetProductOutputDto> ListAllProducts(string keyword)
        {
            var getAllProducts = productManager.GetAllProducts(keyword).ToList();
            List<GetProductOutputDto> output = new List<GetProductOutputDto>();
            for (var x = 0; x < getAllProducts.Count; x++) {
                output.Add(new GetProductOutputDto());
                CustomMapper<Product, GetProductOutputDto>.Map(getAllProducts[x], output[x]);
            }
            return output;
        }

        public GetProductOutputDto GetProductById(int productId)
        {
            var getProduct = productManager.GetProduct(productId);
            GetProductOutputDto output = new GetProductOutputDto();
            CustomMapper<Product, GetProductOutputDto>.Map(getProduct, output);
            return output;
        }

        public void Update(UpdateProductInputDto product)
        {
            Product output = new Product();
            CustomMapper<UpdateProductInputDto, Product>.Map(product, output);
            productManager.UpdateProduct(output);
        }
    }
}
