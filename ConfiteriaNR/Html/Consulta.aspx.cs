using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfiteriaNR.Html
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InputFecha.Value = "";
                tablaVentasMozo.Visible = false;
            }
        }

        protected void btnCargarVentasDia_Click(object sender, EventArgs e)
        {
            tablaVentasDia.Visible = true;
            if (InputFecha.Value != "")
            {
                DateTime Fecha = DateTime.Parse(InputFecha.Value);
                List<DetalleTicketDTO> Det = BLL.ReportesBLL.TraerVentasDia(Fecha);
                if (BLL.ReportesBLL.TraerVentasDia(Fecha).Count > 0)
                {
                    gvCargarVentasDia.DataSource = Det;
                    gvCargarVentasDia.DataBind();
                    btnImprimir.Visible = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se Cargo correctarmente ');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No hay datos');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertWrong('Debe elegir una fecha');", true);
            }



        }

        protected void btnCargarVentaMozo_Click(object sender, EventArgs e)
        {
            tablaVentasMozo.Visible = true;
            if (InputFecha.Value != "")
            {
                DateTime Fecha = DateTime.Parse(InputFecha.Value);
                List<TicketDTO> Det = BLL.ReportesBLL.TraerVentasDiaMozo(Fecha);
                if (BLL.ReportesBLL.TraerVentasDiaMozo(Fecha).Count > 0)
                {
                    gvCargarVentaMozo.DataSource = Det;
                    gvCargarVentaMozo.DataBind();
                    btnImprimir.Visible = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se Cargo correctarmente ');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No hay datos');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertWrong('Debe elegir una fecha');", true);
            }
        }

        protected void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se limpio exitosamente la fecha');", true);
        }

        protected void btnImprimirCargar_Click(object sender, EventArgs e)
        {

        }
    }
}