using EShopOnPromotionEngineeRule.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopOnPromotionEngineeRule.API.Interfaces
{
    public interface ICartService
    {
        List<CartItemDto> GetCartItems();

        CartDto AddItemToCart(Guid cartId, CartItemDto cartItem);
    }
}
