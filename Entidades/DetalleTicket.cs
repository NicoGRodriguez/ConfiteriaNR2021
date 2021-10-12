using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleTicket
    {
        public int Id_DetalleTicket { get; set; }
        public int Id_Articulo { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnit { get; set; }
        public int Id_Ticket { get; set; }
    }
}
