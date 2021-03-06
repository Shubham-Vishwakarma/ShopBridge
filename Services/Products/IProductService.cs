using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildRestApiNetCore.Models;
using BuildRestApiNetCore.Models.DTO;

namespace BuildRestApiNetCore.Services.Products
{
    public interface IProductService : IService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProductDTOs();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task DeleteProduct(Product product);
    }
}