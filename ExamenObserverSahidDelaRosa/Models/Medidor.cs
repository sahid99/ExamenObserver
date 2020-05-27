using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenObserverSahidDelaRosa.Models
{
    public class Medidor : IObservador
    {
        public void Update(ISuscriptor suscriptor)
        {
            var bateria = (Bateria)suscriptor;
            string estado;
            string coneccion;
            string tiempo;
            if (bateria.ActividadBateria)
            {
                estado = "cargando";
                tiempo = $"{bateria.Tiempo} segundos para terminar de cargarse";
            }
            else
            {
                estado = "sin cargar";
                tiempo = $"{bateria.Tiempo} segundos para descargarse";
            }
            if (bateria.EstadoBateria)
            {
                coneccion = "esta conectada";
            }
            else
            {
                coneccion = "no está conectada";
            }
     
            Console.WriteLine($"La batería tiene {bateria.PorcentajeCarga}% de carga. Se encuentra {estado} y {coneccion}, {tiempo}");
        }
    }
}
