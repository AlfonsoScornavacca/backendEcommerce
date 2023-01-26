using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using DataAccess.Abstractions;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> Create(CreateOrder order)
        {
            var entity = new Order
            {
                Customer = order.Customer,
                Date = order.Date,
                Items = order.Items.Select(x => Map(x)).ToList(),
            };
            return Map(await _orderRepository.Create(entity));
        }

        public async Task<ICollection<OrderResponse>> GetAll(OrderRequest request)
        {
            var orders = await _orderRepository.GetAll(request.PageSize, request.PageNumber);
            return orders
                .Select(order => Map(order))
                .ToList();
        }

        public async Task<OrderResponse> GetById(int orderId) =>
            Map(await _orderRepository.GetById(orderId));


        public async Task<OrderResponse> Update(int id, CreateOrder order)
        {
            var entity = new Order
            {
                Customer = order.Customer,
                Date = order.Date,
                Items = order.Items.Select(x => Map(x)).ToList(),
            };
            return Map(await _orderRepository.Update(entity));
        }
        #region Private
        private OrderResponse? Map(Order order) =>
            order != null
            ? new()
            {
                Id = order.Id,
                Customer = order.Customer,
                Date = order.Date,
                Items = order.Items.Select(x => Map(x)).ToList()
            } : null;
        private OrderItemResponse? Map(OrderItem item) =>
            item != null?
            new()
            {
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
            }:null;
        private OrderItem? Map(CreateOrderItem item) =>
            item != null ?
            new()
            {
                ProductId = item.ProductId,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
            } : null;

        #endregion
    }
}
