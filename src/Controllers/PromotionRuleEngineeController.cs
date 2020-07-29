using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopOnPromotionEngineeRule.API.Dtos;
using EShopOnPromotionEngineeRule.API.DTOs;
using EShopOnPromotionEngineeRule.API.Interfaces;
using EShopOnPromotionEngineeRule.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopOnPromotionEngineeRule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionRuleEngineeController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPromoRuleService _promoRuleService;
        private readonly ICartService _cartService;
        private readonly ICheckoutService _checkoutService;

        public PromotionRuleEngineeController(IProductService productService, 
            IPromoRuleService promoRuleService, ICartService cartService, ICheckoutService checkoutService)
        {
            _productService = productService;
            _promoRuleService = promoRuleService;
            _cartService = cartService;
            _checkoutService = checkoutService;
        }

        /// <summary>
        /// Get available product items.
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/items")]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _productService.GetProductsFromStore();
            return products;
        }

        /// <summary>
        /// Get active promo offers
        /// </summary>
        /// <returns></returns>
        [HttpGet("ActiveOffers")]
        public ActionResult<IEnumerable<PromoOffer>> GetActivePromoOffers()
        {
            var promoRules = _promoRuleService.GetPromoRules()
                .Where(p => p.ValidTill > DateTime.Today)
                .ToList();
            return promoRules;
        }

        /// <summary>
        /// Get cart items
        /// </summary>
        /// <returns></returns>
        [HttpGet("basket/items")]
        public ActionResult<IEnumerable<CartItemDto>> GetCartItems()
        {
            var cartItems = _cartService.GetCartItems();
            return cartItems;
        }

        /// <summary>
        /// Proceed to check out cart items
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost("checkout")]
        public ActionResult<CartDto> ProceedToCheckOut(CartDto cart)
        {
            var defaultCartItems = _cartService.GetCartItems();
            var cartDto = new CartDto
            {
                CartId = Guid.NewGuid().ToString(),
                CartItems = cart.CartItems != null && cart.CartItems.Count() > 0 && cart.CartItems.FirstOrDefault().Quantity > 0 ? cart.CartItems : defaultCartItems
            };
            var result = _checkoutService.Checkout(cartDto);
            return result;
        }
    }
}