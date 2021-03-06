using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildRestApiNetCore.Models;

namespace BuildRestApiNetCore.Services.Orders
{
    public interface IOrderService : IService
    {
        Task<IEnumerable<Order>> GetOrders(int customerId);
        Task<IEnumerable<OrderDTO>> GetOrderDTOs(int customerId);
        Task<Order> GetOrder(int id);
        Task<Order> CreateOrder(OrderPost order);
        Task<Order> UpdateOrder(Order order);
        Task DeleteOrder(int id);
        Task DeleteOrder(Order order);
    }
}