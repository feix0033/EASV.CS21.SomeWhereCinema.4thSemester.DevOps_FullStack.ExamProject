using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.Converter;

public class OrderConverter
{
    public static Order Converter(OrderEntity orderEntity)
    {
        return new Order
        {
            Id = orderEntity.Id,
            UserId = orderEntity.UserId,
            ProjectionPlan = orderEntity.ProjectionPlan,
            SitNumber = orderEntity.SitNumber
        };
    }

    public static OrderEntity Converter(Order order)
    {
        return new OrderEntity
        {
            Id = order.Id,
            UserId = order.UserId,
            ProjectionPlan = order.ProjectionPlan,
            SitNumber = order.SitNumber
        };
    }
}