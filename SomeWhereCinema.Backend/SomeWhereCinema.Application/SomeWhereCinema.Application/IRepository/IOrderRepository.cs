using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.IRepository;

public interface IOrderRepository
{
    List<Order> findAll();
    Order CreateOrder(Order order);
    Order ReadOrder(Order order);
    Order UpdateOrder(Order order);
    Order DeleteOrder(Order order);
}