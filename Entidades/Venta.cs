using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleTickets
    {
        public int Id_DetalleTick { get; set; }
        public int Id_Articulo { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnit { get; set; }
    }
}
