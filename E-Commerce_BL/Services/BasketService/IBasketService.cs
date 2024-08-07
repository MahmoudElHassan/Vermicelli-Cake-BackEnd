﻿using E_Commerce_DAL;

namespace E_Commerce_BL;

public interface IBasketService
{
    Task<CustomerBasket> GetBasketAsync(string basketId);
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string basketId);
}
