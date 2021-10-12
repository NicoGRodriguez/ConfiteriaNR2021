using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class usuarioDAL
    {
        public static Usuario Ingresar(string Usuario, string Contraseña)
        {
            Contraseña = Encrypt.EncriptarPassword(Contraseña, "Pass");
            Usuario usu = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Contrasenia", Contraseña);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usu = CargarUsuario(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return usu;
        }

        private static Usuario CargarUsuario(SqlDataReader dr)
        {

            Usuario obj = new Usuario();
            obj.Id = int.Parse(dr["Id"].ToString());
            obj.Usuarios = dr["Usuario"].ToString();
            obj.Contraseña = dr["Contrasenia"].ToString();
            obj.TipoAdm = bool.Parse(dr["TipoAdm"].ToString());

            return obj;
        }
    }
}
