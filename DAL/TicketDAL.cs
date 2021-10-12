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
    public class TicketDAL
    {
        public static DataTable ObtenerArticulos()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                DataTable tabla = new DataTable();
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Articulo", con);
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
        public static DetalleTicket CrearDetalleTicket(DetalleTicket d)
        {
            DetalleTicket det = new DetalleTicket();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CrearDetalleTicket", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnit", d.PrecioUnit);
                    cmd.Parameters.AddWithValue("@Id_Articulo", d.Id_Articulo);
                    cmd.Parameters.AddWithValue("@Id_Ticket", d.Id_Ticket);

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
            return det;
        }
        public static int CrearTicket(Ticket d)
        {
            Ticket det = new Ticket();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CrearTicket", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Mozo", d.Id_Mozo);
                    cmd.Parameters.AddWithValue("@Fecha_Alta", DateTime.Now);
                    SqlParameter outputIdParam = new SqlParameter("@Id_Ticket", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    int id = (int)outputIdParam.Value;
                    return id;
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

        }


    }
}
