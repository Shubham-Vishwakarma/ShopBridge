#nullable disable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuildRestApiNetCore.Models;
using BuildRestApiNetCore.Models.DTO;
using BuildRestApiNetCore.Services.Products;
using BuildRestApiNetCore.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace BuildRestApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _service.GetProductDTOs();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _service.GetProduct(id);
                return Ok(product);
            }
            catch(ProductNotFoundException)
            {
                return NotFound();
            }
        }


        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedProduct = await _service.UpdateProduct(product);
                return Ok(updatedProduct);
            }
            catch(ProductNotFoundException)
            {
                return NotFound();
            }  
        }


        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var createdProduct = await _service.CreateProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        // DELETE: api/Product/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _service.DeleteProduct(id);
                return Ok(new ResponseMessage("Delete Successfull"));
            }
            catch(ProductNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
