using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
    
{
    [Route("api/[controllers]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
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
        public async Task<ActionResult<OrderResponse>> Post([FromBody] CreateOrder order)=>
            await _orderService.Create(order);

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse>> Put(int id, [FromBody] CreateOrder order)=>
            await _orderService.Update(id, order);
    }
}
