using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDemo.Models
{
    public class Producto : ISuscriptor
    {
        private string nombre;
        private float precioBase;
        private float precioActual;
        private List<IObservador> observadores = new List<IObservador>();

        public string Nombre
        {
            get { return nombre; }
        }

        public float Descuento
        {
            get
            {
                return ((precioBase - precioActual) * 100) / precioBase;
            }
        }

        public float PrecioActual
        {
            get
            {
                return precioActual;
            }
        }

        public float Precio
        {
            get { return precioActual; }
            set
            {
                precioActual = value;
                if (value<=precioBase)
                {
                    Notificar();
                }
            }
        }

        public Producto(string nombre, float preciobase)
        {
            this.nombre = nombre;
            this.precioBase = preciobase;
            this.precioActual = preciobase;
        }

        public void Notificar()
        {
            foreach(var item in observadores)
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
