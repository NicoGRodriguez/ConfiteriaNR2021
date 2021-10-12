using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfiteriaNR.Http
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TipoAdm"] = null;
            Session["usuariologueado"] = null;
        }
        private Usuario Iniciar(string Usuario, string Contraseña)
        {
            return usuarioBLL.Ingresar(Usuario, Contraseña);
        }
        protected void Ingresar_Click(object sender, EventArgs e)
        {
            Usuario resultado = Iniciar(txtUsuario.Text, txtContraseña.Text);
            if (resultado.Id != 0)
            {
                Session["TipoAdm"] = resultado.TipoAdm;
                Session["usuariologeado"] = txtUsuario.Text;
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                lblError.Text = "Datos mal ingresados!!";
            }
        }
    }
}