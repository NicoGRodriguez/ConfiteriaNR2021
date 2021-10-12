using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfiteriaNR.Html
{
    public partial class CrearVenta : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboArticulo();
                CargarMozo();
                ViewState["Flag"] = false;
            }
        }
        public void CargarComboArticulo()
        {
            DataTable table = TicketBLL.ObtenerArticulos();
            cboArticulos.DataSource = table;
            cboArticulos.DataTextField = table.Columns[1].ColumnName;
            cboArticulos.DataValueField = table.Columns[0].ColumnName;
            cboArticulos.DataBind();
            cboArticulos.Items.Insert(0, new ListItem("Seleccione un Articulo..."));
        }
        public void CargarMozo()
        {
            DataTable table = BLL.TicketBLL.ObtenerMozo();
            cboMozo.DataSource = table;
            cboMozo.DataTextField = table.Columns[1].ColumnName;
            cboMozo.DataValueField = table.Columns[0].ColumnName;
            cboMozo.DataBind();
            cboMozo.Items.Insert(0, new ListItem("Seleccione un Mozo..."));
        }
        protected void btnConfirmarAgregarProducto_Click(object sender, EventArgs e)
        {
            if ((bool)ViewState["Flag"])
            {
                Session["datos"] = null;
            }

            if (txtCantidad.Text != "")
            {
                double totalSuma = 0;
                DataTable dt;
                if (Session["datos"] != null)
                {
                    dt = Session["datos"] as DataTable;
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add("Articulo");
                    dt.Columns.Add("Cantidad");
                    dt.Columns.Add("Precio Unitario");
                    dt.Columns.Add("Importe");
                }
                DataRow rowe = dt.NewRow();

                double importe = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(ViewState["precio"]);
                rowe["Articulo"] = cboArticulos.SelectedItem.Text;
                rowe["Cantidad"] = txtCantidad.Text;
                rowe["Precio Unitario"] = ViewState["precio"];
                rowe["Importe"] = importe;

                dt.Rows.Add(rowe);

                gvCarrito.DataSource = dt;
                gvCarrito.DataBind();
                Session["datos"] = dt;

                foreach (GridViewRow x in gvCarrito.Rows)
                {
                    totalSuma += Convert.ToDouble(x.Cells[3].Text);
                }


                lblTotal.Visible = true;
                lblTotal.Text = "Total: $" + totalSuma.ToString();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('Datos incompletos y/o mal ingresados');", true);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarTicket.aspx");
        }

        protected void cboArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id_Articulo = Convert.ToInt32(cboArticulos.Text);
            ViewState["precio"] = ArticuloBLL.TraerPrecioArticulo(Id_Articulo);
        }

        protected void btnLimpiarFac_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            gvCarrito.DataSource = dt;
            gvCarrito.DataBind();
            lblTotal.Text = null;
            ViewState["Flag"] = true;
        }
        public void LimpiarCampos()
        {

        }


        protected void btnConfirmarFactura_Click(object sender, EventArgs e)
        {
            if (cboArticulos.SelectedIndex != 0)
            {
                Ticket tic = new Ticket();
                tic.Id_Mozo = int.Parse(cboMozo.SelectedValue);
                int Id_Ticket = BLL.TicketBLL.CrearTicket(tic);
                List<Articulo> lstArticulos = BLL.TicketBLL.ListaArticulo();
                if (Id_Ticket != 0)
                {
                    foreach (GridViewRow row in gvCarrito.Rows)
                    {
                        DetalleTicket deta = new DetalleTicket();
                        var nombreArticulo = row.Cells[0].Text;
                        deta.Id_Articulo = Convert.ToInt32(lstArticulos.Where(n => n.Nombre == nombreArticulo).First().Id_Articulo);
                        deta.Cantidad = Convert.ToInt32(row.Cells[1].Text);
                        deta.PrecioUnit = Convert.ToInt32(row.Cells[2].Text);
                        deta.Id_Ticket = Id_Ticket;
                        BLL.TicketBLL.CrearDetalleTicket(deta);
                    }
                }
                btnImprimirFactura.Visible = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se facturo correctarmente');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('Datos incompletos y/o mal ingresados');", true);
            }
        }


        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            Double Total = 0;
            if (cboMozo.SelectedIndex != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "mostrarModal2();", true);
                lblMozoModal.Text = "Mozo: " + cboMozo.SelectedItem.Text;
                foreach (GridViewRow x in gvCarrito.Rows)
                {
                    Total += Convert.ToDouble(x.Cells[3].Text);
                }
                TotalModal.Visible = true;
                TotalModal.Text = "Total: $" + Total.ToString();
                gvModalFac.DataSource = Session["datos"];
                gvModalFac.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "alertWrong('Debe elegir un mozo');", true);
            }


        }

    }
}