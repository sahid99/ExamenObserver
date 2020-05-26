using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ObserverDemo.Models
{
    public class Correo : IObservador
    {
        private List<string> _mails;
        private SmtpClient smtp;
        const string subjectCorreo = "Promo UP";
        const string mailFrom = "jvicius@gmail.com";
        const string password = "123456";

        public Correo(List<string> mails)
        {
            this._mails = mails;
            smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailFrom, password)
            };            
        }

        public void Update(ISuscriptor suscriptor)
        {
            foreach(var mail in _mails)
            {
                var producto = (Producto)suscriptor;
                var mensaje = $"{mail}: {producto.Nombre} Laptop disponible en ${producto.PrecioActual}; Descuento: {producto.Descuento}";

                var mailenviar = new MailMessage(mailFrom, mail, subjectCorreo,mensaje);
                Console.WriteLine($"Enviando Email a:{mail}");
                try
                {
                    smtp.Send(mailenviar);
                }
                catch
                {

                }

            }
        }
    }
}
