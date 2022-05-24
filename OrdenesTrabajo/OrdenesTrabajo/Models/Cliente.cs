using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesTrabajo.Models
{
    public class Cliente
    {
        public string typeDocument { get; set; }
        public string document { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public bool online { get; set; }
        public string id { get; set; }
    }
}
