using EShopOnPromotionEngineeRule.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopOnPromotionEngineeRule.API.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetProductsFromStore();
        ProductDto AddProductToStore(ProductDto newProduct);
        
    }
}
