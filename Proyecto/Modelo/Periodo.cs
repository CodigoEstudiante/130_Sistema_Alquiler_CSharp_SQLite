using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelo
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }
        public int NumeroPeriodo { get; set; }
        public Alquiler oAlquiler { get; set; }
        public string FechaLimitePeriodo { get; set; }
        public string EstadoPeriodo { get; set; }
        public int ProximoPagar { get; set; }
        public decimal Monto { get; set; }
        public string FechaPago { get; set; }

    }
}
