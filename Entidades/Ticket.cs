using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ticket
    {
        public int Id_Ticket { get; set; }
        public int Id_Mozo { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public DateTime? Fecha_Baja { get; set; }
    }
}
