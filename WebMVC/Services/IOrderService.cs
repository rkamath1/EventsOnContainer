using WebMVC.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
    }
}
