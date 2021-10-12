using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class DetalleTicketDTO
    {
        public int Articulo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
    }
}
