using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controllers")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
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

        [HttpPut("id")]
        public async Task<ActionResult<ProductResponse>> Put(int id, [FromBody] CreateProduct product) =>
            await _productService.Update(id, product);

    }

}
