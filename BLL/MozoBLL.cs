using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MozoBLL
    {
        public static Mozo RegistrarMozo(Mozo m)
        {
            return DAL.MozoDAL.RegistrarMozo(m);
        }
        public static Mozo TraerMozo(int m)
        {
            return DAL.MozoDAL.TraerMozo(m);
        }
        public static bool EditarMozo(Mozo m)
        {
            return DAL.MozoDAL.EditarMozo(m);
        }
        public static bool BajaMozo(Mozo m)
        {
            return DAL.MozoDAL.BajaMozo(m);
        }
    }
}
