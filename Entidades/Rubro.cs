using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rubro
    {
        public int Id_Rubro { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public DateTime? Fecha_Baja { get; set; }
    }
}
