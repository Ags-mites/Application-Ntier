﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class Empleados
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public decimal sueldo { get; set; }
    }
}
