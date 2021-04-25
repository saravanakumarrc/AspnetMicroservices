using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCart(string userName);
        Task<ShoppingCart> UpdateShoppingCart(ShoppingCart basket);
        Task DeleteShoppingCart(string userName);
    }
}
