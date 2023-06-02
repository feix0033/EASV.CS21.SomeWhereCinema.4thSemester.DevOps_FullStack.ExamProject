using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Core.IService;

public interface IOrderService
{
    List<Order> GetAllOrder();
    Order CreateOrder(Order order);
    Order ReadOrder(Order order);
    Order UpdateOrder(Order order);
    Order DeleteOrder(Order order);

}