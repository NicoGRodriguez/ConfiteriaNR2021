using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfiteriaNR.Html
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologeado"] != null && Session["TipoAdm"] != null)
            {
                bool TipoAdm = bool.Parse(Session["TipoAdm"].ToString());
                string usuariologeado = Session["usuariologeado"].ToString();
                Bienvenida.Text = "Bienvenido/a " + usuariologeado;

                if (TipoAdm)
                {
                    GestionarMozo.Visible = true;
                    GestionarRubro.Visible = true;
                    GestionarArticulo.Visible = true;
                    reportesHome.Visible = true;
                }
                else
                {
                    reportesHome.Visible = false;
                    GestionarMozo.Visible = false;
                    GestionarRubro.Visible = false;
                    GestionarArticulo.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}