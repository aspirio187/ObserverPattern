using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    internal class AccountingMonitor : BaseMonitor
    {
        /// <summary>
        /// Sum of all the money spent
        /// </summary>
        public decimal SpentMoney { get; private set; } = 0;

        /// <summary>
        /// Create an instance of <see cref="AccountingMonitor"/> by giving it a name
        /// </summary>
        /// <param name="name">The department's name</param>
        public AccountingMonitor(string name)
            : base(name)
        {

        }

        /// <summary>
        /// Unsubscribe from <see cref="SaleHandler"/> and set <see cref="SpentMoney"/> to 0
        /// </summary>
        public override void Unsubscribe()
        {
            base.Unsubscribe();

            SpentMoney = 0;
        }

        /// <summary>
        /// Called when no more order are registered and set <see cref="SpentMoney"/> to 0
        /// </summary>
        public override void OnCompleted()
        {
            SpentMoney = 0;
        }

        /// <summary>
        /// Called when an order arrives. Adds the 
        /// </summary>
        /// <param name="value"></param>
        public override void OnNext(Order value)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            SpentMoney += (value.Price * value.Quantity);

            Console.WriteLine($"Deparment {Name} : Order Registered");
            Console.WriteLine($"Quantity\t-\tCar\t-\tPrice");
            Console.WriteLine($"{value.Quantity}\t-\t{value.Car}\t-\t{value.Price}");
            Console.WriteLine($"\tTotal spent money : {SpentMoney}$");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
