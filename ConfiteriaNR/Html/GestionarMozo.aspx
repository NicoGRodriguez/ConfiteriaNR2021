<%@ Page Title="Gestion de Mozo" Language="C#" MasterPageFile="~/Html/HomeMaster.Master" AutoEventWireup="true" CodeBehind="GestionarMozo.aspx.cs" Inherits="ConfiteriaNR.Html.GestionarMozo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div>
                <div class="row">
                    <asp:Label Text="Gestion de Mozos" runat="server" class="text-lef mb-4 h2" />
                    <div class="col-md-7 col-lg-4">
                        <div id="Formulario_Login" class="login-form" runat="server">
                            <div class="form-group">
                                <asp:Label Text="Buscar Mozo por DNI" CssClass="h5" runat="server" />
                                <asp:TextBox ID="txtBuscarMozo" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Numeros()" MaxLength="8" oninput="maxlengthNumber(this);"/>
                                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-3" OnClick="btnBuscar_Click" />
                                <asp:Button ID="btnNuevaBusqueda" Visible="false" Text="Realizar una Busqueda" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-3" OnClick="btnNuevaBusqueda_Click" required="" />
                            </div>
                            <div class="form-group">
                                <asp:Label Text="Agregar nuevo Mozo" CssClass="h5" runat="server" />
                                <asp:Button ID="btnNuevoMozo" Text="Nuevo" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-1" OnClick="btnNuevoMozo_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-lg-5">
                        <div visible="false" runat="server" id="DatosMozo">
                            <div class="form-group">
                                <asp:Label ID="lblNombre" Text="Nombre" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtNombreMozo" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Letras()" MaxLength="6" oninput="maxlengthNumber(this);"/>
                                <asp:Label ID="lblApellido" Text="Apellido" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtApellidoMozo" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Letras()"/>
                                <asp:Label ID="lblComision" Text="Comision" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtComision" MaxLength="2" oninput="maxlengthNumber(this);" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Numeros()"/>
                            </div>
                        </div>
                        <div visible="false" runat="server" id="Fechas">
                            <div class="form-group">
                                <asp:Label ID="lblFechaAlta" Text="Fecha de Alta" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtFechaAlta" runat="server" CssClass="form-control rounded-left mt-1"/>
                                <asp:Label ID="lblFechaBaja" Text="Fecha de Baja" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtFechaBaja" runat="server" CssClass="form-control rounded-left mt-1" />
                            </div>
                        </div>
                        <div visible="false" runat="server" id="NuevoMozo">
                            <div class="form-group">
                                <asp:Label ID="lblDocumento" Text="Documento" runat="server" CssClass="h5" />
                                <asp:TextBox MaxLength="8" oninput="maxlengthNumber(this);" ID="txtDocumentoMozo" runat="server" CssClass="form-control rounded-left mt-1" />
                                <asp:Button ID="btnAgregarMozo" Text="Agregar mozo" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-1" OnClick="btnAgregarMozo_Click" />
                            </div>
                        </div>
                        <div visible="false" runat="server" id="BotonDarBaja">
                            <div class="form-group">
                                <asp:Button ID="btnModificar" Text="Modificar" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-1" OnClick="btnModificar_Click" />
                                <asp:Button ID="btnDarDeBaja" Text="Dar de baja a mozo" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-1" OnClick="btnDarDeBaja_Click" />
                            </div>
                        </div>
                        <div visible="false" runat="server" id="BotonGuardarCambios">
                            <div class="form-group">
                                <asp:Button ID="btnGuardarCambios" Text="Guardar Cambios" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-1" OnClick="btnGuardarCambios_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
