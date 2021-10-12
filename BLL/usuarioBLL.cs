using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL
{
    public class usuarioBLL
    {
        public static Usuario Ingresar(string Usuario, string Contraseña)
        {
            return DAL.usuarioDAL.Ingresar(Usuario, Contraseña);
        }
    }
}
