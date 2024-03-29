﻿using CanteenManagement.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement.Models
{
    public class CartItem
    {
        
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }


}
