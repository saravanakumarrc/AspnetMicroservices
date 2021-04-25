using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class ShoppingCartRepository: IShoppingCartRepository
    {
        private readonly IDistributedCache _distributedCache;

        public ShoppingCartRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task DeleteShoppingCart(string userName)
        {
            await _distributedCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetShoppingCart(string userName)
        {
            var shoppingCart = await _distributedCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(shoppingCart)) return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(shoppingCart);
        }

        public async Task<ShoppingCart> UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            await _distributedCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));

            return await GetShoppingCart(shoppingCart.UserName);
        }
    }
}
