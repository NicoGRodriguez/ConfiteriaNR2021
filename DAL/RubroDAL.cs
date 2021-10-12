using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class RubroDAL
    {
        public static List<Rubro> ListaRubro()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_MostrarRubro", con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<Rubro> rubro  = new List<Rubro>();
                        while (dr.Read())
                        {
                            rubro.Add(CargarRubro(dr));
                        }
                        con.Close();

                        return rubro;
                    }
                }
            }
        }
        private static Rubro CargarRubro(SqlDataReader dr)
        {

            Rubro Rub = new Rubro();
            Rub.Id_Rubro = int.Parse(dr["Id_Rubro"].ToString());
            Rub.Nombre = dr["Nombre"].ToString();
            Rub.Fecha_Alta =DateTime.Parse(dr["Fecha_Alta"].ToString());
            if (dr["Fecha_Baja"].ToString() != "")
            {
                Rub.Fecha_Baja = DateTime.Parse(dr["Fecha_Baja"].ToString());
            }
            else
            {
                Rub.Fecha_Baja = null;
            }

            return Rub;
        }
        public static Rubro BuscarRubro(int r)
        {
            Rubro rub = new Rubro();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TraerRubro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Rubro", r);


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            rub = CargarRubro(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return rub;
            }
        }
        public static bool EditarRubro(Rubro r)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarRubro", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Rubro", r.Id_Rubro);
                    cmd.Parameters.AddWithValue("@Nombre", r.Nombre);
                    cmd.Parameters.AddWithValue("@Fecha_Alta", r.Fecha_Alta);
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
        public static bool BajaRubro(Rubro r)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BajaRubro", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Rubro", r.Id_Rubro);
                    cmd.Parameters.AddWithValue("Fecha_Baja", r.Fecha_Baja);
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
        public static Rubro RegistrarRubro(Rubro m)
        {
            Rubro rub = new Rubro();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CrearRubro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                    cmd.Parameters.AddWithValue("@Fecha_Alta", m.Fecha_Alta);

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
            return rub;
        }
        public static Rubro EliminarRubro(Rubro r)
        {
            Rubro rub = new Rubro();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarRubro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Rubro", r.Id_Rubro);
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
            return rub;
        }
    }
}
