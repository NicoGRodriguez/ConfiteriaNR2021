using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MozoDAL
    {
        public static Mozo RegistrarMozo(Mozo m)
        {
            Mozo usu = new Mozo();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CrearMozo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
                    cmd.Parameters.AddWithValue("@Documento", m.Documento);
                    cmd.Parameters.AddWithValue("@Fecha_Alta", m.Fecha_Alta);
                    cmd.Parameters.AddWithValue("@Comision", m.Comision);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return usu;
        }
        public static bool EditarMozo(Mozo m)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarMozo", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
                    cmd.Parameters.AddWithValue("@Documento", m.Documento);
                    cmd.Parameters.AddWithValue("@Comision", m.Comision);
                    cmd.Connection = con;
                    exito = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return exito;
        }
        private static Mozo CargarMozo(SqlDataReader dr)
        {

            Mozo obj = new Mozo();
            obj.Id_Mozo = int.Parse(dr["Id_Mozo"].ToString());
            obj.Nombre = dr["Nombre"].ToString();
            obj.Apellido = dr["Apellido"].ToString();
            obj.Documento = int.Parse(dr["Documento"].ToString());
            obj.Comision = int.Parse(dr["Comision"].ToString());
            obj.Fecha_Alta = DateTime.Parse(dr["Fecha_Alta"].ToString());
            if (dr["Fecha_Baja"].ToString() != "" )
            {
                obj.Fecha_Baja = DateTime.Parse(dr["Fecha_Baja"].ToString());
            }
            else
            {
                obj.Fecha_Baja = null;
            }
            

            return obj;
        }
        public static Mozo TraerMozo(int m)
        {
            Mozo moz = new Mozo();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TraerMozo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Documento", m);


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            moz = CargarMozo(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return moz;
            }
        }
        public static bool BajaMozo(Mozo m)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BajaMozo", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Documento", m.Documento);
                    cmd.Parameters.AddWithValue("Fecha_Baja", m.Fecha_Baja);
                    cmd.Connection = con;
                    exito = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return exito;
        }
        public static DataTable ObtenerMozo()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                DataTable tabla = new DataTable();
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Mozo", con);
                    cmd.CommandType = CommandType.Text;
                    tabla.Load(cmd.ExecuteReader());
                    return tabla;

                }
                catch (Exception e)
                {
                    //Conexion.BeginTransaction();
                    throw new Exception("Ha ocurrido un error " + e);
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}
