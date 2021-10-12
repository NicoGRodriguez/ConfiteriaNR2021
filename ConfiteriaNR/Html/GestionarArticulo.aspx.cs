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
    public partial class GestionarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvGestionarArt(ArticuloBLL.ListaArticulo());
                Cargarddl(ddlRubroAgregar);
                Cargarddl(ddlRubroEditar);
                Cargarddl(ddlRubroEliminar);
            }
        }
        private void gvGestionarArt(List<Articulo> Artic)
        {
            gvGestionarArticulo.DataSource = Artic;
            gvGestionarArticulo.DataBind();
        }
        public void LimpiarCamposAgregar()
        {
            txtIdAgregar.Text = "";
            txtNombreArticuloAgregar.Text = "";
            txtStockAgregar.Text = "";
            txtPrecioAgregar.Text = "";
        }
        public void LimpiarCamposEliminar()
        {
            txtIdE.Text = "";
            txtNombreE.Text = "";
            txtPrecioE.Text = "";
            txtStockE.Text = "";

        }
        public void Nuevo()
        {
            btnAgregar.Enabled = true;
            btnSiEditar.Enabled = false;
            btnNoEditar.Enabled = false;
            idDiv.Visible = false;
        }

        protected void gvGestionarArticulo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["Id_Articulo"] = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("Editar"))
            {
                idDiv.Visible = true;
                Articulo a = ArticuloBLL.BuscarArticulo(int.Parse(ViewState["Id_Articulo"].ToString()));
                txtIdEditar.Text = a.Id_Articulo.ToString();
                txtNombreArticuloEditar.Text = a.Nombre;
                txtPrecioEditar.Text = a.Precio.ToString();
                txtStockEditar.Text = a.Stock.ToString();
                ddlRubroEditar.Text = a.Id_Rubro.ToString();

            }
            if (e.CommandName.Equals("Eliminar"))
            {
                Articulo a = ArticuloBLL.BuscarArticulo(int.Parse(ViewState["Id_Articulo"].ToString()));
                txtIdE.Text = a.Id_Articulo.ToString();
                txtNombreE.Text = a.Nombre;
                txtPrecioE.Text = a.Precio.ToString();
                txtStockE.Text = a.Stock.ToString();
                Cargarddl(ddlRubroEliminar);
            }


        }
        private void Cargarddl(DropDownList Editar)
        {
            List<Rubro> Rub = BLL.ArticuloBLL.ListaRubro();
            for (int i = 0; i < Rub.Count; i++)
            {
                Editar.Items.Add(new ListItem(Rub[i].Nombre, Rub[i].Id_Rubro.ToString()));
            }

        }
        protected void btnSiEditar_Click(object sender, EventArgs e)
        {
            Articulo a = new Articulo();
            if (txtNombreArticuloEditar.Text != "" && (txtPrecioEditar.Text != "" && txtPrecioEditar.Text.Length < 4 && txtPrecioEditar.Text != "") && txtStockEditar.Text != "" && ddlRubroEditar.SelectedIndex != 0)
            {
                a.Id_Articulo = Convert.ToInt32(txtIdEditar.Text);
                a.Nombre = txtNombreArticuloEditar.Text;
                a.Precio = Convert.ToInt32(txtPrecioEditar.Text);
                a.Stock = Convert.ToInt32(txtStockEditar.Text);
                a.Id_Rubro = Convert.ToInt32(ddlRubroEditar.Text);
                ArticuloBLL.EditarArticulo(a);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertOk('Se edito correctarmente');", true);
                gvGestionarArt(ArticuloBLL.ListaArticulo());
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertWrong('Datos incompletos y/o mal ingresados');", true);
            }

        }
        protected void btnNoEditar_Click(object sender, EventArgs e)
        {
            LimpiarCamposAgregar();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No edito datos');", true);
        }
        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            LimpiarCamposAgregar();

        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Articulo art = new Articulo();
            if (txtNombreArticuloAgregar.Text != ""  && (txtPrecioAgregar.Text != "" && txtPrecioAgregar.Text.Length < 4 && txtPrecioAgregar.Text != "") && txtStockAgregar.Text != "" && ddlRubroAgregar.SelectedIndex != 0)
            {
                art.Nombre = txtNombreArticuloAgregar.Text;
                art.Precio = Convert.ToInt32(txtPrecioAgregar.Text);
                art.Stock = Convert.ToInt32(txtStockAgregar.Text);
                art.Id_Rubro = Convert.ToInt32(ddlRubroAgregar.SelectedValue);
                BLL.ArticuloBLL.RegistrarArticulo(art);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se agrego correctarmente ');", true);
                LimpiarCamposAgregar();
                gvGestionarArt(ArticuloBLL.ListaArticulo());
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('Datos incompletos y/o mal ingresados');", true);
            }

        }

        protected void btnNoEliminar_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No elimino datos');", true);
            gvGestionarArt(ArticuloBLL.ListaArticulo());
        }

        protected void btnSiEliminar_Click(object sender, EventArgs e)
        {

            Articulo art = new Articulo();
            if (txtIdE != null)
            {
                art.Id_Articulo = int.Parse(txtIdE.Text);
                BLL.ArticuloBLL.EliminarArticulo(art);
                LimpiarCamposEliminar();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se elimino correctarmente ');", true);
                gvGestionarArt(ArticuloBLL.ListaArticulo());
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No se puedo eliminar los datos');", true);
            }
        }
    }
}