using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.DotNet7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase 
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [Route("GetAllOrder")]
    public List<Order> GetAll()
    {
        return _orderService.GetAllOrder();
    }

    [HttpPost]
    [Route("CreateOrder")]
    public Order CreateOrder(Order order)
    {
        return _orderService.CreateOrder(order);
    }

    [HttpPatch]
    [Route("ReadOrder")]
    public Order ReadOrder(Order order)
    {
        return _orderService.ReadOrder(order);
    }

    [HttpPut]
    [Route("UpdateOrder")]
    public Order UpdateOrder(Order order)
    {
        return _orderService.UpdateOrder(order);
    }

    [HttpDelete]
    [Route("DeleteOrder")]
    public Order DeleteOrder(Order order)
    {
        return _orderService.DeleteOrder(order);
    }
}