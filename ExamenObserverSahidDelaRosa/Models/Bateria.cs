using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenObserverSahidDelaRosa.Models
{
    public class Bateria : ISuscriptor
    {
        private bool conectado;
        private bool cargando;
        private int carga;
        private int tiempo;
        private List<IObservador> observadores = new List<IObservador>();

       public bool EstadoBateria
        {
            get { return conectado; }
            set {
                bool estado_anterior = conectado;
                conectado = value;
                if(value != estado_anterior)
                {
                    Notificar();
                }
            }
        }
        public bool ActividadBateria
        {
            get { return cargando; }
            set
            {
                bool estado_anterior = cargando;
                cargando = value;
                if (value != estado_anterior)
                {
                    Notificar();
                }
            }
        }
        public int PorcentajeCarga
        {
            get { return carga; }
            set
            {
                if (conectado)
                {
                    Notificar();
                    carga = value;
                }
                if(carga >= 100)
                {
                    cargando = false;
                    carga = 100;
                    
                }
            }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
        public Bateria()
        {
            conectado = false;
            cargando = false;
            carga = 0;
            tiempo = (100 - carga) / 6;
        }

        public void Notificar()
        {
            foreach (var item in observadores)
            {
                item.Update(this);
            }
        }

        public void DesSuscribir(IObservador observador)
        {
            observadores.Remove(observador);
        }

        public void Suscribir(IObservador observador)
        {
            observadores.Add(observador);
        }
    }
}
