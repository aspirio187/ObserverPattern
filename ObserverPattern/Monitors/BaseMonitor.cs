using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class BaseMonitor : IObserver<Order>
    {
        /// <summary>
        /// The name of the monitor
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Object of type <see cref="IDisposable"/> assigned in <see cref="Subscribe(SaleHandler)"/> and used to unsubscribe from
        /// <see cref="SaleHandler"/>
        /// </summary>
        public virtual IDisposable? _cancellation { get; protected set; }

        /// <summary>
        /// Create an instance of <see cref="BaseMonitor"/> object by giving it a name
        /// </summary>
        /// <param name="name">The department's name</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public BaseMonitor(string name)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (name.Length <= 0) throw new ArgumentException($"{nameof(name)} cannot be an empty string!");

            Name = name;
        }

        /// <summary>
        /// Subscribe to the given <see cref="SaleHandler"/> in parameter
        /// </summary>
        /// <param name="saleHandler">A <see cref="SaleHandler"/> object</param>
        public virtual void Subscribe(SaleHandler handler)
        {
            _cancellation = handler.Subscribe(this);
        }

        /// <summary>
        /// Unsubscribe from handler and set the number of orders to 0
        /// </summary>
        public virtual void Unsubscribe()
        {
            if (_cancellation is null)
                throw new NullReferenceException($"The monitor must subscribe to a handler before trying to unsubscribe!");

            _cancellation.Dispose();
        }

        /// <summary>
        /// Called to complete <see cref="SaleHandler"/>'s job. Dispose from the <see cref="SaleHandler"/>'s list of observers
        /// </summary>
        public virtual void OnCompleted()
        {

        }

        /// <summary>
        /// Called when an error occur and displays an error message
        /// </summary>
        /// <param name="error"></param>
        public virtual void OnError(Exception error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Called when a order is made, register the quantity of <see cref="Car"/> object in <paramref name="value"/> and displays
        /// the order
        /// </summary>
        /// <param name="value">The order to take in account</param>
        public virtual void OnNext(Order value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
        }
    }
}
