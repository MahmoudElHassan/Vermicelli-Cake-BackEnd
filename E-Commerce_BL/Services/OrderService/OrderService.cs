using E_Commerce_DAL;
using E_Commerce_DAL.OrderAggregate;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace E_Commerce_BL;

public class OrderService : IOrderService
{
    private readonly IBasketService _basketManager;
    private readonly IUnitOfWork _unitOfWork;
    //private readonly WhatsAppSettings _settings;

    public OrderService(IBasketService basketRepo, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _basketManager = basketRepo;
        //_settings = settings.Value;
    }

    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
        // get basket from repo
        var basket = await _basketManager.GetBasketAsync(basketId);

        // get items from the product repo
        var items = new List<OrderItem>();
        foreach (var item in basket.Items)
        {
            var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
            var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureURL);
            var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
            items.Add(orderItem);
        }

        // get delivery method from repo
        var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

        // calc subtotal
        var subtotal = items.Sum(item => item.Price * item.Quantity);

        // check to see if order exists
        //var spec = new OrderByPaymentIntentIdSpecification(basket.PaymentIntentId);
        //var order = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);

        // create order
        var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod,
            subtotal, basket.PaymentIntentId);
        _unitOfWork.Repository<Order>().Add(order);

        //if (order.BuyerEmail != buyerEmail &&
        //    order.ShipToAddress != shippingAddress &&
        //    order.DeliveryMethod != deliveryMethod &&
        //    order.Subtotal != subtotal)
        //{
        //    order.ShipToAddress = shippingAddress;
        //    order.DeliveryMethod = deliveryMethod;
        //    order.Subtotal = subtotal;
        //    _unitOfWork.Repository<Order>().Update(order);
        //}
        //else
        //{
        //    // create order
        //    order = new Order(items, buyerEmail, shippingAddress, deliveryMethod,
        //        subtotal, basket.PaymentIntentId);
        //    _unitOfWork.Repository<Order>().Add(order);
        //}

        // save to db
        var result = await _unitOfWork.Complete();

        if (result <= 0) return null;

        // return order
        return order;
    }

    public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

        return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
    }


    public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);

        return await _unitOfWork.Repository<Order>().ListAsync(spec);
    }

    //public async Task<bool> SendMessage(Order order)
    //{
    //    try
    //    {
    //        using HttpClient httpClient = new();

    //        httpClient.DefaultRequestHeaders.Authorization =
    //            new AuthenticationHeaderValue("Bearer", _settings.TokenWhatsApp);


    //        WhatsAppRequest body = new()
    //        {
    //            template = new Template
    //            {
    //                name = "new_order_parms",
    //                language = new Language { code = "en_US" },
    //            }
    //        };

    //        HttpResponseMessage response =
    //            await httpClient.PostAsJsonAsync(new Uri(_settings.ApiUrlWhatsApp), body);

    //        return response.IsSuccessStatusCode;

    //    }
    //    catch (Exception ex)
    //    {

    //        throw new NotImplementedException(ex.Source + " " + ex.StackTrace + " " + ex.Message);
    //    }
    //}

    public string GetOrderItems(IList<OrderItem> orderItem)
    {
        string result = "";

        foreach (var item in orderItem)
        {
            result += item.ItemOrdered.ProductName + " = " + item.Quantity + ", ";
        }

        //for (int i = 0; i < orderItem.ToArray().Length - 1; i++)
        //{
        //    result += orderItem[i].ItemOrdered.ProductName + " = " + orderItem[i].Quantity + ", ";
        //}

        return result;
    }

}