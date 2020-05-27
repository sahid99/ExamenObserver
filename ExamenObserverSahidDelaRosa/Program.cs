using System;
using System.Timers;
using ExamenObserverSahidDelaRosa.Models;

namespace ExamenObserverSahidDelaRosa
{
    class Program
    {
        private static Timer aTimer;
        public static Bateria bateria = new Bateria();
        static void Main(string[] args)
        {
            
            Medidor medidor = new Medidor();
            bateria.EstadoBateria = true; //Conectado
            bateria.ActividadBateria = true;
            bateria.Suscribir(medidor);

            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
            while (true) { }
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            
            bateria.PorcentajeCarga += 10;
        }
    }
}
