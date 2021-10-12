using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RubroBLL
    {
        public static List<Rubro> ListaRubro()
        {
            return DAL.RubroDAL.ListaRubro();
        }
        public static Rubro BuscarRubro(int m)
        {
            return DAL.RubroDAL.BuscarRubro(m);
        }
        public static bool EditarRubro(Rubro m)
        {
            return DAL.RubroDAL.EditarRubro(m);
        }
        public static bool BajaRubro(Rubro m)
        {
            return DAL.RubroDAL.BajaRubro(m);
        }
        public static Rubro RegistrarRubro(Rubro m)
        {
            return DAL.RubroDAL.RegistrarRubro(m);
        }
        public static Rubro EliminarRubro(Rubro m)
        {
            return DAL.RubroDAL.EliminarRubro(m);
        }
    }
    
}
