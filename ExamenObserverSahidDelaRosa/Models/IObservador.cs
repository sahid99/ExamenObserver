﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenObserverSahidDelaRosa.Models
{
    public interface IObservador
    {
        void Update(ISuscriptor suscriptor);
    }
}
