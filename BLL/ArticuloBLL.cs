using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ArticuloBLL
    {
        public static Articulo TraerArticulo(string m)
        {
            return DAL.ArticuloDAL.TraerArticulo(m);
        }
        public static List<Articulo> ListaArticulo()
        {
            return DAL.ArticuloDAL.ListaArticulo();
        }
        public static List<Rubro> ListaRubro()
        {
            return DAL.RubroDAL.ListaRubro();
        }
        public static Articulo BuscarArticulo(int m)
        {
            return DAL.ArticuloDAL.BuscarArticulo(m);
        }
        public static bool EditarArticulo(Articulo m)
        {
            return DAL.ArticuloDAL.EditarArticulo(m);
        }
        public static Articulo RegistrarArticulo(Articulo m)
        {
            return DAL.ArticuloDAL.RegistrarArticulo(m);
        }
        public static Articulo EliminarArticulo(Articulo m)
        {
            return DAL.ArticuloDAL.EliminarArticulo(m);
        }
        public static Double TraerPrecioArticulo(int m)
        {
            return DAL.ArticuloDAL.TraerPrecio(m);
        }

    }
}
