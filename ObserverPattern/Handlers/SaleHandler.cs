using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class SaleHandler : IObservable<Order>
    {
        /// <summary>
        /// Collection of subscribed observers of type <see cref="IObservable{T}"/> where <c>T</c> is type <see cref="Order"/>
        /// </summary>
        public List<IObserver<Order>> Observers { get; private set; }

        /// <summary>
        /// Collection of registered orders
        /// </summary>
        public List<Order> Orders { get; private set; }

        /// <summary>
        /// Create an instance of the handler
        /// </summary>
        public SaleHandler()
        {
            Observers = new List<IObserver<Order>>();
            Orders = new List<Order>();
        }

        /// <summary>
        /// Registered a <see cref="IObserver{T}"/> with <c>T</c> being of type <see cref="Order"/> to the collection of observers and
        /// execute <see cref="IObserver{T}.OnNext(T)"/> method for each sales in <see cref="Orders"/>
        /// <see cref="Observers"/>
        /// </summary>
        /// <param name="observer">The observer to add in the collection</param>
        /// <returns>A <see cref="Unsubscriber{TSale}"/> object of type <see cref="Order"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IDisposable Subscribe(IObserver<Order> observer)
        {
            if (observer is null) throw new ArgumentNullException(nameof(observer));

            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);

                foreach (Order order in Orders)
                {
                    observer.OnNext(order);
                }
            }

            return new Unsubscriber<Order>(Observers, observer);
        }

        /// <summary>
        /// Register an order in the <see cref="Orders"/> collection and call <see cref="IObserver{T}.OnNext(T)"/> for each observer
        /// in <see cref="Observers"/> collection
        /// </summary>
        /// <param name="order"></param>
        public void MakeOrder(Order order)
        {
            Orders.Add(order);
            foreach (var observer in Observers)
            {
                observer.OnNext(order);
            }
        }

        /// <summary>
        /// Execute <see cref="IObserver{T}.OnCompleted"/> for each observer in <see cref="Observers"/> collection before cleaning the
        /// collection
        /// </summary>
        public void StoreClosed()
        {
            foreach (var observer in Observers)
            {
                observer.OnCompleted();
            }

            Observers.Clear();
        }
    }
}
