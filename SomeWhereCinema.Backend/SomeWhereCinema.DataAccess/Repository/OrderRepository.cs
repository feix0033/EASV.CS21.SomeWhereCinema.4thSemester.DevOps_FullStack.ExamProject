using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Converter;
using SomeWhereCinema.DataAccess.DbContext;

namespace SomeWhereCinema.DataAccess.Repository;

public class OrderRepository : IOrderRepository
{
    private DBContext _dbContext;

    public OrderRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    private void createDb()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    public List<Order> findAll()
    {
        var orders = new List<Order>();
        var orderEntities = _dbContext.OrderTable.ToList();
        foreach (var orderEntity in orderEntities)
        {
            orders.Add(OrderConverter.Converter(orderEntity));
        }

        return orders;
    }

    public Order CreateOrder(Order order)
    {
        var orderEntity = _dbContext.OrderTable.Add(OrderConverter.Converter(order)).Entity;
        _dbContext.SaveChanges();
        return OrderConverter.Converter(orderEntity);
    }

    public Order ReadOrder(Order order)
    {
        var orderEntity = _dbContext.OrderTable
            .FirstOrDefault(o => o.Id == order.Id);
        
        if (orderEntity != null)
        {
            return OrderConverter.Converter(orderEntity);
        }

        return new Order() { Id = 0 };
    }

    public Order UpdateOrder(Order order)
    {
            var orderEntity = _dbContext.OrderTable.Update(OrderConverter.Converter(order)).Entity;
            _dbContext.SaveChanges();
            return OrderConverter.Converter(orderEntity);
    }

    public Order DeleteOrder(Order order)
    {
        var orderEntity = _dbContext.OrderTable.Remove(OrderConverter.Converter(order)).Entity;
            _dbContext.SaveChanges();
            return OrderConverter.Converter(orderEntity);
    }
}