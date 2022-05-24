﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesTrabajo.Models
{
    public class OrdenTrabajo
    {
        public string type { get; set; }
        public string idClient { get; set; }
        public string idUser { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string serial { get; set; }
        public string description { get; set; }
        public bool online { get; set; }
        public string id { get; set; }
    }
}
