using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulo
    {
        public int Id_Articulo { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int? Stock { get; set; }
        public int Id_Rubro { get; set; }

    }
}
