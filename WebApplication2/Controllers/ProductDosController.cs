using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDosController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductDosController(IProductService productService)
        {
            _productService = productService;
        }


         [HttpGet]
         public async Task<ActionResult<ICollection<ProductResponse>>> Get([FromQuery] ProductRequest request) =>
             Ok(await _productService.GetAll(request));


         [HttpGet("{id}")]
         public async Task<ActionResult<ProductResponse>> Get(int id) =>
             await _productService.GetById(id);

         [HttpPost]
         public async Task<ActionResult<ProductResponse>> Post([FromBody] CreateProduct product) =>
             await _productService.Create(product);

         [HttpPut("{id}")]
         public async Task<ProductResponse> Put(int id, [FromBody] CreateProduct product) =>
             await _productService.Update(id, product);

        // DELETE api/<ProductDosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
