using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto
{
    public class TicketDTO
    {
        public string Mozo { get; set; }
        public int CantidadArticulo { get; set; }
        public float ImporteTotal { get; set; }
        public int Comision { get; set; }
        public float Pagar { get; set; }
    }
}
