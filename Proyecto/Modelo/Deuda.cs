using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelo
{
    public class Deuda
    {
        public int IdDeuda { get; set; }
        public int IdPeriodo { get; set; }
        public int NumeroPeriodo { get; set; }
        public string MontoDeuda { get; set; }
        public string EstadoDeuda { get; set; }
        public string FechaPago { get; set; }
    }
}
