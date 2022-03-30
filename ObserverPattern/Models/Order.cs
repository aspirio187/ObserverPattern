using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    /// <summary>
    /// Enumeration of all available car brands
    /// </summary>
    public enum Brands
    {
        Mercedes,
        BMW,
        Toyota,
        Renault,
        Ferrari
    }

    /// <summary>
    /// Describes an order with the brand, the price and the quantity
    /// </summary>
    public class Order
    {
        public Brands Car { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
