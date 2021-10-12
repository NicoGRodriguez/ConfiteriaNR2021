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
    public class ArticuloDAL
    {
        public static Articulo TraerArticulo(string m)
        {
            Articulo art = new Articulo();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TraerArticulo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", m);


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            art = CargarArticulo(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return art;
            }
        }
        private static Articulo CargarArticulo(SqlDataReader dr)
        {

            Articulo obj = new Articulo();
            obj.Id_Articulo = int.Parse(dr["Id_Articulo"].ToString());
            obj.Nombre = dr["Nombre"].ToString();
            obj.Precio = float.Parse(dr["Precio"].ToString());
            obj.Stock = int.Parse(dr["Stock"].ToString());
            obj.Id_Rubro = int.Parse(dr["Id_Rubro"].ToString());

            return obj;
        }
        public static List<Articulo> ListaArticulo()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_MostrarArticulo", con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<Articulo> Art = new List<Articulo>();
                        while (dr.Read())
                        {
                            Art.Add(CargarArticulo(dr));
                        }
                        con.Close();

                        return Art;
                    }
                }
            }
        }
        public static Articulo BuscarArticulo(int r)
        {
            Articulo art = new Articulo();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TraerArticulo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Articulo", r);


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            art = CargarArticulo(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return art;
            }
        }
        public static bool EditarArticulo(Articulo r)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarArticulo", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Articulo", r.Id_Articulo);
                    cmd.Parameters.AddWithValue("@Nombre", r.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", r.Precio);
                    cmd.Parameters.AddWithValue("@Stock", r.Stock);
                    cmd.Parameters.AddWithValue("@Id_Rubro", r.Id_Rubro);
                    cmd.Connection = con;
                    exito = cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return exito;
        }
        public static Articulo RegistrarArticulo(Articulo m)
        {
            Articulo rub = new Articulo();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CrearArticulo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", m.Precio);
                    cmd.Parameters.AddWithValue("@Stock", m.Stock);
                    cmd.Parameters.AddWithValue("@Id_Rubro", m.Id_Rubro);

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
        public static Articulo EliminarArticulo(Articulo a)
        {
            Articulo art = new Articulo();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarArticulo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Articulo", a.Id_Articulo);
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
            return art;
        }
        public static double TraerPrecio(int a)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                double precio = 0;
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ObtenterPrecioArticulo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Articulo", a);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr["precio"].ToString() != null)
                            {
                                precio = (double)dr["precio"];
                            }
                        }
                    }                     
                    con.Close();
                    return precio;

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
