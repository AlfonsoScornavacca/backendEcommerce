using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDosController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderDosController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<OrderResponse>>> Get([FromQuery] OrderRequest request) =>
            Ok(await _orderService.GetAll(request));


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> Get(int id) =>
    await _orderService.GetById(id);


        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post([FromBody] CreateOrder order) =>
     await _orderService.Create(order);


        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse>> Put(int id, [FromBody] CreateOrder order) =>
     await _orderService.Update(id, order);

        // DELETE api/<OrderDosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
