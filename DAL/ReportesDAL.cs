using Entidades;
using Entidades.Dto;
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
    public class ReportesDAL
    {
        public static List<DetalleTicketDTO> TraerVentasDia(DateTime m)
        {
            List<DetalleTicketDTO> lst = new List<DetalleTicketDTO>();
            DetalleTicketDTO Det = new DetalleTicketDTO();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ReporteVentaDiaria", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", m);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Det = CargarDetalleTicket(dr);
                            lst.Add(Det);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return lst;
            }
        }
        private static DetalleTicketDTO CargarDetalleTicket(SqlDataReader dr)
        {
            DetalleTicketDTO obj = new DetalleTicketDTO();
            obj.Articulo = int.Parse(dr["Articulo"].ToString());
            obj.Cantidad = int.Parse(dr["Cantidad"].ToString());
            obj.Importe = int.Parse(dr["Importe"].ToString());
            obj.Descripcion = dr["Descripcion"].ToString();
            return obj;
        }
        private static TicketDTO CargarTicket(SqlDataReader dr)
        {
            TicketDTO tic = new TicketDTO();
            tic.Mozo = dr["Mozo"].ToString();
            tic.CantidadArticulo = int.Parse(dr["CantidadArticulo"].ToString());
            tic.ImporteTotal = int.Parse(dr["ImporteTotal"].ToString());
            tic.Comision = int.Parse(dr["Comision"].ToString());
            tic.Pagar = int.Parse(dr["Pagar"].ToString());
            return tic;
        }
        public static List<TicketDTO> TraerVentasDiaMozo(DateTime m)
        {
            List<TicketDTO> lst = new List<TicketDTO>();
            TicketDTO tic = new TicketDTO();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ReporteVentaPorMozo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", m);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tic = CargarTicket(dr);
                            lst.Add(tic);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return lst;
            }
        }


    }
}
