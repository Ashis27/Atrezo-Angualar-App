using EShopOnPromotionEngineeRule.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopOnPromotionEngineeRule.API.Interfaces
{
    public interface ICheckoutService
    {
        CartDto Checkout(CartDto cart);
    }
}
