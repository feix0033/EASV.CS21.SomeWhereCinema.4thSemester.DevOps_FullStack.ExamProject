using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public List<Order> GetAllOrder()
    {
        return _orderRepository.findAll();
    }

    public Order CreateOrder(Order order)
    {
        return _orderRepository.CreateOrder(order);
    }

    public Order ReadOrder(Order order)
    {
        return _orderRepository.ReadOrder(order);
    }

    public Order UpdateOrder(Order order)
    {
        return _orderRepository.UpdateOrder(order);
    }

    public Order DeleteOrder(Order order)
    {
        return _orderRepository.DeleteOrder(order);
    }
}