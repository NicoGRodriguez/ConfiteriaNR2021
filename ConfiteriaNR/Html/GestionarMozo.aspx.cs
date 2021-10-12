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
    public partial class GestionarMozo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            if (txtBuscarMozo.Text != "")
            {
                Mozo u = MozoBLL.TraerMozo(int.Parse(txtBuscarMozo.Text));
                if (u != null)
                {
                    DatosMozo.Visible = true;
                    Fechas.Visible = true;
                    BotonDarBaja.Visible = true;
                    txtBuscarMozo.Text = Convert.ToString(u.Documento);
                    txtNombreMozo.Text = u.Nombre;
                    txtApellidoMozo.Text = u.Apellido;
                    txtComision.Text = Convert.ToString(u.Comision);
                    txtFechaAlta.Text = Convert.ToString(u.Fecha_Alta);
                    if (u.Fecha_Baja == null)
                    {
                        txtFechaBaja.Text = "Mozo Vigente";
                    }
                    else
                    {
                        txtFechaBaja.Text = Convert.ToString(u.Fecha_Baja);
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se Cargo correctarmente ');", true);
                    Desabilitar();
                    btnBuscar.Visible = false;
                    btnNuevaBusqueda.Visible = true;
                }            
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('No se encontro mozo');", true);
            }
        }
        public void Desabilitar()
        {
            txtBuscarMozo.Enabled = false;
            txtNombreMozo.Enabled = false;
            txtApellidoMozo.Enabled = false;
            txtComision.Enabled = false;
            txtFechaAlta.Enabled = false;
            txtFechaBaja.Enabled = false;
        }
        public void NoVisible()
        {
            btnNuevaBusqueda.Visible = false;
            DatosMozo.Visible = false;
            Fechas.Visible = false;
            BotonDarBaja.Visible = false;
            NuevoMozo.Visible = false;
            btnGuardarCambios.Visible = false;
        }
        public void HabilitarBusqueda()
        {
            txtBuscarMozo.Enabled = true;
            btnBuscar.Visible = true;
        }

        protected void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            HabilitarBusqueda();
            NoVisible();
        }

        protected void btnNuevoMozo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Fechas.Visible = false;
            BotonDarBaja.Visible = false;
            txtNombreMozo.Enabled = true;
            txtApellidoMozo.Enabled = true;
            txtComision.Enabled = true;
            txtBuscarMozo.Enabled = false;
            btnBuscar.Visible = false;
            DatosMozo.Visible = true;
            NuevoMozo.Visible = true;
            btnNuevaBusqueda.Visible = true;
        }
        public void LimpiarCampos()
        {
            txtNombreMozo.Text = "";
            txtApellidoMozo.Text = "";
            txtDocumentoMozo.Text = "";
            txtBuscarMozo.Text = "";
            txtFechaAlta.Text = "";
            txtFechaBaja.Text = "";
            txtComision.Text = "";

        }

        protected void btnAgregarMozo_Click(object sender, EventArgs e)
        {
            Mozo moz = new Mozo();
            if (txtNombreMozo.Text != "" && txtApellidoMozo.Text != "" && txtDocumentoMozo.Text.Length >= 7 && txtDocumentoMozo.Text.Length <= 9 && txtComision.Text.Length == 2)
            {
                moz.Nombre = txtNombreMozo.Text;
                moz.Apellido = txtApellidoMozo.Text;
                moz.Documento = Convert.ToInt32(txtDocumentoMozo.Text);
                moz.Comision = Convert.ToInt32(txtComision.Text);
                moz.Fecha_Alta = DateTime.Now;
                BLL.MozoBLL.RegistrarMozo(moz);             
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se agrego correctarmente ');", true);
                LimpiarCampos();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('Complete los datos y/o verique que esten bien ingresado');", true);

            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            BotonGuardarCambios.Visible = true;
            BotonDarBaja.Visible = false;
            txtNombreMozo.Enabled = true;
            txtApellidoMozo.Enabled = true;
            txtComision.Enabled = true;
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {

            Mozo moz = new Mozo();
            if (txtNombreMozo.Text != "" && txtApellidoMozo.Text != "" && (txtComision.Text.Length == 2 && txtComision.Text != ""))
            {
                moz.Documento = Convert.ToInt32(txtBuscarMozo.Text);
                moz.Nombre = txtNombreMozo.Text;
                moz.Apellido = txtApellidoMozo.Text;
                moz.Comision = Convert.ToInt32(txtComision.Text);
                BLL.MozoBLL.EditarMozo(moz);
                if (BLL.MozoBLL.EditarMozo(moz))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se guardo correctarmente los cambios');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertWrong('Complete los datos y/o verique que esten bien ingresado');", true);
            }
            
            LimpiarCampos();
            HabilitarBusqueda();
            NoVisible();

        }

        protected void btnDarDeBaja_Click(object sender, EventArgs e)
        {

            Mozo moz = new Mozo();
            moz.Documento = Convert.ToInt32(txtBuscarMozo.Text);
            moz.Fecha_Baja = DateTime.Now;

            BLL.MozoBLL.BajaMozo(moz);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "alertOk('Se dio de baja correctarmente ');", true);

            LimpiarCampos();
            HabilitarBusqueda();
            NoVisible();


        }
    }
}