using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfiteriaNR.Html
{
    public partial class GestionarRubro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvGestionarRub(RubroBLL.ListaRubro());
            }

        }
        private void gvGestionarRub(List<Rubro> Rubros)
        {
            gvGestionarRubro.DataSource = Rubros;
            gvGestionarRubro.DataBind();
        }
        public void LimpiarCampos()
        {
            txtId = null;
            txtNombreRubroEditar.Text = "";
            txtFechaAlta.Text = "";
            txtFechaBaja.Text = "";
        }


        protected void gvGestionarRubro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["Id_Rubro"] = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("Editar"))
            {
                Rubro r = RubroBLL.BuscarRubro(int.Parse(ViewState["Id_Rubro"].ToString()));
                txtId.Text = r.Id_Rubro.ToString();
                txtNombreRubroEditar.Text = r.Nombre;
                txtFechaAlta.Text = r.Fecha_Alta.ToString();
                if (r.Fecha_Baja != null)
                {
                    txtFechaBaja.Text = r.Fecha_Baja.ToString();
                }
                else
                {
                    txtFechaBaja.Text = "Producto vigente";
                }
                txtFechaAlta.Enabled = false;
                txtFechaBaja.Enabled = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se Cargo correctarmente ');", true);

            }
            if (e.CommandName.Equals("Eliminar"))
            {
                Rubro r = RubroBLL.BuscarRubro(int.Parse(ViewState["Id_Rubro"].ToString()));
                txtIdE.Text = r.Id_Rubro.ToString();
                txtNombreE.Text = r.Nombre;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se Cargo correctarmente ');", true);
            }

        }


        protected void btnSi_Click(object sender, EventArgs e)
        {
            Rubro r = new Rubro();
            if (txtNombreRubroEditar.Text!="")
            {            
                r.Id_Rubro = Convert.ToInt32(txtId.Text);
                r.Nombre = txtNombreRubroEditar.Text;
                r.Fecha_Alta = Convert.ToDateTime(txtFechaAlta.Text);
                if (txtFechaBaja.Text == null)
                {
                    r.Fecha_Baja = Convert.ToDateTime(txtFechaBaja.Text);
                }
                else
                {
                    r.Fecha_Baja = null;
                }

                RubroBLL.EditarRubro(r);
                LimpiarCampos();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se edito correctarmente ');", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "myModal", "alertOk('Se edito correctarmente ');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertWrong('Debe agregar un nombre');", true);
            }
            


        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No se Edito');", true);
        }

        protected void btnDarBaja_Click(object sender, EventArgs e)
        {

            Rubro rub = new Rubro();
            rub.Id_Rubro = Convert.ToInt32(txtId.Text);
            rub.Fecha_Baja = DateTime.Now;
            BLL.RubroBLL.BajaRubro(rub);
            LimpiarCampos();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se dio de baja correctarmente ');", true);

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Rubro rub = new Rubro();
            if (txtNombreRubroAgregar.Text != "")
            {
                
                rub.Nombre = txtNombreRubroAgregar.Text;
                if (InputFechaAlta.Value == "")
                {
                    rub.Fecha_Alta = DateTime.Now;
                }
                else
                {
                    rub.Fecha_Alta = Convert.ToDateTime(InputFechaAlta.Value);
                }

                BLL.RubroBLL.RegistrarRubro(rub);
                LimpiarCampos();               
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertOk('Se agrego correctarmente ');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertWrong('No se pudo agregar');", true);
            }


        }

        protected void btnAgregarRubro_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            btnAgregar.Visible = true;
            idDiv.Visible = false;
        }

        protected void btnNoEliminar_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No se Elimino');", true);
        }

        protected void btnSiEliminar_Click(object sender, EventArgs e)
        {

            Rubro rubro = new Rubro();
            rubro.Id_Rubro = int.Parse(txtIdE.Text);
            BLL.RubroBLL.EliminarRubro(rubro);
            if (BLL.RubroBLL.EliminarRubro(rubro) != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se agrego correctarmente ');", true);
                LimpiarCampos();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No se Elimino');", true);
            }
        }
    }
}