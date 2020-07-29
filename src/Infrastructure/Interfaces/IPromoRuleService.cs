using EShopOnPromotionEngineeRule.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopOnPromotionEngineeRule.API.Interfaces
{
    public interface IPromoRuleService
    {
        List<PromoOffer> GetPromoRules();
    }
}
