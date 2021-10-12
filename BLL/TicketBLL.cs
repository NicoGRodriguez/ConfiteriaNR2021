using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketBLL
    {
        public static List<Articulo> ListaArticulo()
        {
            return DAL.ArticuloDAL.ListaArticulo();
        }
        public static DataTable ObtenerArticulos()
        {
            return DAL.TicketDAL.ObtenerArticulos();
        }
        public static DataTable ObtenerMozo()
        {
            return DAL.MozoDAL.ObtenerMozo();
        }
        public static int CrearTicket(Ticket m)
        {
            return DAL.TicketDAL.CrearTicket(m);
        }
        public static DetalleTicket CrearDetalleTicket(DetalleTicket m)
        {
            return DAL.TicketDAL.CrearDetalleTicket(m);
        }
    }
}
