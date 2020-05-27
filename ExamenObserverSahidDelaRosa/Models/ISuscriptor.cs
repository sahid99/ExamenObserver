using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenObserverSahidDelaRosa.Models
{
    public interface ISuscriptor
    {
        void Suscribir(IObservador observador);
        void DesSuscribir(IObservador observador);
        void Notificar();
    }
}
