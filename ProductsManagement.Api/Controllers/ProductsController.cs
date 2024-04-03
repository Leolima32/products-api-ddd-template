using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Interfaces;
using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController(IProductsService service) : Controller
    {
        private readonly IProductsService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _service.GetAllProducts());
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetById(Guid productId) {
            var result = await _service.GetProductById(productId);

            if(result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InsertProductCommand command) {
            return Ok(await _service.InsertProduct(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateProductCommand command) {
            return Ok(await _service.UpdateProduct(command));
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> Delete(Guid productId) {
            var result = await _service.DeleteProduct(productId);

            if(!result)
              return NoContent();

            return Ok(result);
        }
    }
}