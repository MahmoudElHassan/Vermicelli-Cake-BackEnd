using AutoMapper;
using E_Commerce_BL;
using E_Commerce_DAL;
using E_Commerce_DAL.OrderAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E;

[Authorize]
public class OrdersController : BaseApiController
{
    private readonly IOrderManager _orderManager;
    private readonly IMapper _mapper;
    public OrdersController(IOrderManager orderManager, IMapper mapper)
    {
        _mapper = mapper;
        _orderManager = orderManager;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
    {
        var email = HttpContext.User.RetrieveEmailFromPrincipal();

        var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

        var order = await _orderManager.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

        if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));

        return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
    {
        var email = User.RetrieveEmailFromPrincipal();

        var orders = await _orderManager.GetOrdersForUserAsync(email);

        return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
    {
        var email = User.RetrieveEmailFromPrincipal();

        var order = await _orderManager.GetOrderByIdAsync(id, email);

        if (order == null) return NotFound(new ApiResponse(404));

        return _mapper.Map<OrderToReturnDto>(order);
    }

    [HttpGet("deliveryMethods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        return Ok(await _orderManager.GetDeliveryMethodsAsync());
    }
}