using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportesBLL
    {
        public static List<DetalleTicketDTO> TraerVentasDia(DateTime m)
        {
            return DAL.ReportesDAL.TraerVentasDia(m);
        }

        public static List<TicketDTO> TraerVentasDiaMozo(DateTime m)
        {
            return DAL.ReportesDAL.TraerVentasDiaMozo(m);
        }

    }
}
