using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDemo.Models
{
    public interface IObservador
    {
        void Update(ISuscriptor suscriptor);
    }
}
