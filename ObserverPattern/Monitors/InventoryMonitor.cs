using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    /// <summary>
    /// Inventory monitor the number of sales per day and stops once it reached 20 or more
    /// </summary>
    internal class InventoryMonitor : BaseMonitor
    {
        /// <summary>
        /// The actual number of orders made
        /// </summary>
        public int NumberOrders { get; private set; } = 0;

        /// <summary>
        /// Create an instance of <see cref="InventoryMonitor"/> object
        /// </summary>
        public InventoryMonitor(string name)
            : base(name)
        {

        }

        /// <summary>
        /// Unsubscribe from handler and set the number of orders to 0
        /// </summary>
        public override void Unsubscribe()
        {
            base.Unsubscribe();
            NumberOrders = 0;
        }

        /// <summary>
        /// Called to complete <see cref="SaleHandler"/>'s job and set the number of orders to 0
        /// </summary>
        public override void OnCompleted()
        {
            NumberOrders = 0;
        }

        /// <summary>
        /// Called when a order is made, register the quantity of <see cref="Car"/> object in <paramref name="value"/> and displays
        /// the order
        /// </summary>
        /// <param name="value">The order to take in account</param>
        public override void OnNext(Order value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            NumberOrders += value.Quantity;

            Console.WriteLine($"Deparment {Name} : Order Registered");
            Console.WriteLine($"{NumberOrders}/20\t-\t-\t{value.Car}\t-\t{value.Quantity}");

            if (NumberOrders > 20)
            {
                Console.WriteLine("The limit of order per day has been reached");
                Unsubscribe();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
