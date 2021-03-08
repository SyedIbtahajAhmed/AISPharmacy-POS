using Abp.Application.Services;
using AISPharmacy.Models.Products;
using AISPharmacy.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy.Products
{
    public interface IProductAppService : IApplicationService
    {
        List<GetProductOutputDto> ListAllProducts(string keyword);
        GetProductOutputDto GetProductById(int productId);
        Task Create(CreateProductInputDto product);
        void Update(UpdateProductInputDto product);
        void Delete(DeleteProductInputDto productId);
    }
}
