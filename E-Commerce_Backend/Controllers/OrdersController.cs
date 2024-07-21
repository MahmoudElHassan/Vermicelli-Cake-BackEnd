using AutoMapper;
using E_Commerce_BL;
using E_Commerce_DAL;
using E_Commerce_DAL.OrderAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace E;

[Authorize]
public class OrdersController : BaseApiController
{
    private readonly IOrderService _orderManager;
    private readonly IMapper _mapper;
    private readonly WhatsAppSettings _settings;

    public OrdersController(IOrderService orderManager, IMapper mapper,
        IOptions<WhatsAppSettings> settings)
    {
        _mapper = mapper;
        _orderManager = orderManager;
        _settings = settings.Value;
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

    //[HttpDelete("{id}")]
    //public async Task<ActionResult<OrderToReturnDto>> DeleteOrderByIdForUser(int id)
    //{
    //    var email = User.RetrieveEmailFromPrincipal();

    //    var order = await _orderManager.GetOrderByIdAsync(id, email);

    //    if (order == null) return NotFound(new ApiResponse(404));

    //    return _mapper.Map<OrderToReturnDto>(order);
    //}

    [HttpGet("deliveryMethods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        return Ok(await _orderManager.GetDeliveryMethodsAsync());
    }

    [HttpPost("whatsapp-message")]
    public async Task<IActionResult> WhatsAppTest()
    {
        using HttpClient httpClient = new();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _settings.TokenWhatsApp);

        WhatsAppRequest body = new()
        {
            template = new Template
            {
                name = "new_order",
                language = new Language { code = "en" }
            }
        };

        HttpResponseMessage response = await
            httpClient.PostAsJsonAsync(new Uri(_settings.ApiUrlWhatsApp), body);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Something went wrong!!");

        return Ok(response);
    }
}