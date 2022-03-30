using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Unsubscriber<TSale> : IDisposable
    {
        private List<IObserver<TSale>> _observers;
        private IObserver<TSale> _observer;

        public Unsubscriber(List<IObserver<TSale>> observers, IObserver<TSale> sale)
        {
            _observers = observers;
            _observer = sale;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
