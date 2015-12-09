using System.Collections.Generic;
using WJStore.Domain.Entities;

namespace WJStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}