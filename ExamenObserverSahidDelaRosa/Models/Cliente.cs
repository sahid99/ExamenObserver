using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDemo.Models
{
    public class Cliente : IObservador
    {
        private string nombre;

        public Cliente(string nombre)
        {
            this.nombre = nombre;
        }
        public void Update(ISuscriptor suscriptor)
        {
            var producto = (Producto)suscriptor;
            Console.WriteLine($"{this.nombre}: {producto.Nombre} Laptop disponible en ${producto.PrecioActual}; Descuento: {producto.Descuento}");
        }
    }
}
