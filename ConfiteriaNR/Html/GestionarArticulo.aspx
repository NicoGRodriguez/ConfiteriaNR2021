<%@ Page Title="Gestionar Articulo" Language="C#" MasterPageFile="~/Html/HomeMaster.Master" AutoEventWireup="true" CodeBehind="GestionarArticulo.aspx.cs" Inherits="ConfiteriaNR.Html.GestionarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function mostrarModal() {
            $('#Agregar_Modal').modal('show');
        }
        function mostrarModal3() {
            $('#Editar_Modal').modal('show');
        }
        function mostrarModal2() {
            $('#EliminarModal').modal('show');
        }
    </script>
    <asp:Label Text="Gestion de Articulos" runat="server" class="text-lef mb-4 h2" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6 col-lg-3">
                    <div id="Formulario_Login" class="login-form" runat="server">
                        <div class="form-group">
                            <asp:Label Text="Agregar nuevo Articulo" CssClass="h5" runat="server" />
                            <asp:Button ID="btnNuevoArticulo" Text="Nuevo" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-1" OnClick="btnNuevoArticulo_Click" OnClientClick="mostrarModal();" CommandArgument='<%#Eval("Id_Articulo") %>' />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col-md-auto col-lg-auto">
        <div class="form-responsive ">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label Text="Articulos en el sistema" runat="server" CssClass="h5" />
                    <div class="table table-bordered border-primary">
                        <asp:GridView ID="gvGestionarArticulo" OnRowCommand="gvGestionarArticulo_RowCommand" runat="server" AutoGenerateColumns="False" CssClass="table">
                            <Columns>
                                <asp:BoundField DataField="Id_Articulo" HeaderText="#" HeaderStyle-CssClass="table-primary" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="table-primary" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" HeaderStyle-CssClass="table-primary" />
                                <asp:BoundField DataField="Stock" HeaderText="Stock" HeaderStyle-CssClass="table-primary" />
                                <asp:BoundField DataField="Id_Rubro" HeaderText="Rubro" HeaderStyle-CssClass="table-primary" />
                                <asp:TemplateField HeaderStyle-CssClass="table-primary">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditar" runat="server" Text="Editar" OnClientClick="mostrarModal3();" CssClass="btn btn-outline-primary" CommandArgument='<%#Eval("Id_Articulo") %>' CommandName="Editar" />
                                        <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" OnClientClick="mostrarModal2();" CssClass="btn btn-outline-primary" CommandArgument='<%#Eval("Id_Articulo") %>' CommandName="Eliminar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    

    <!-- Modal 1 Editar-->
    <div class="modal fade" id="Editar_Modal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Editar" runat="server" class="modal-title" ID="staticBackdropLabel" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body form-group">
                            <div id="idDiv" visible="false" runat="server">
                                <asp:Label Text="Id" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtIdEditar" runat="server" CssClass="form-control rounded-left mt-1" Enabled="false" />
                            </div>
                            <asp:Label Text="Nombre de articulo" runat="server" CssClass="h5" />
                            <asp:TextBox MaxLength="6" oninput="maxlengthNumber(this);" ID="txtNombreArticuloEditar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Letras()" />
                            <asp:Label Text="Stock" runat="server" CssClass="h5" />
                            <asp:TextBox MaxLength="3" oninput="maxlengthNumber(this);" ID="txtStockEditar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Numeros()" />
                            <asp:Label Text="Precio" runat="server" CssClass="h5" />
                            <asp:TextBox MaxLength="4" oninput="maxlengthNumber(this);" ID="txtPrecioEditar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Numeros()" />
                            <asp:Label Text="Rubro" runat="server" CssClass="h5" />
                            <asp:DropDownList ID="ddlRubroEditar" runat="server" CssClass="form-control rounded-left mt-1"></asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer">
                    <asp:Button ID="btnNoEditar" Text="No" runat="server" type="button" class="btn btn-secondary" OnClick="btnNoEditar_Click" />
                    <asp:Button ID="btnSiEditar" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="btnSiEditar_Click" />
                </div>

            </div>
        </div>
    </div>
    <!-- Modal 1 Agregar-->
    <div class="modal fade" id="Agregar_Modal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Agregar" runat="server" class="modal-title" ID="Label2" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body form-group">
                    <div id="IdDivA" visible="false" runat="server">
                        <asp:Label Text="Id" runat="server" CssClass="h5" />
                        <asp:TextBox ID="txtIdAgregar" runat="server" CssClass="form-control rounded-left mt-1" Enabled="false" />
                    </div>
                    <asp:Label Text="Nombre de articulo" runat="server" CssClass="h5" />
                    <asp:TextBox MaxLength="6" oninput="maxlengthNumber(this);" ID="txtNombreArticuloAgregar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Letras()" />
                    <asp:Label Text="Stock" runat="server" CssClass="h5" />
                    <asp:TextBox MaxLength="3" oninput="maxlengthNumber(this);" ID="txtStockAgregar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Numeros()" />
                    <asp:Label Text="Precio" runat="server" CssClass="h5" />
                    <asp:TextBox MaxLength="4" oninput="maxlengthNumber(this);" ID="txtPrecioAgregar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Numeros()" />
                    <asp:Label Text="Rubro" runat="server" CssClass="h5" />
                    <asp:DropDownList ID="ddlRubroAgregar" runat="server" CssClass="form-control rounded-left mt-1"></asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAgregar" Text="Agregar" runat="server" type="button" class="btn btn-warning" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal 2 Eliminar-->
    <div class="modal fade" id="EliminarModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Eliminar" runat="server" class="modal-title" ID="Label1" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body form-group">
                            <asp:Label ID="lblEliminar" Text="Desea eliminar este rubro?" runat="server" CssClass="h4" />
                            <br />
                            <asp:Label Text="ID:" runat="server" CssClass="h5" />
                            <asp:TextBox runat="server" ID="txtIdE" CssClass="form-control rounded-left mt-1" Enabled="false" />
                            <asp:Label Text="Nombre:" runat="server" CssClass="h5" />
                            <asp:TextBox runat="server" ID="txtNombreE" CssClass="form-control rounded-left mt-1" Enabled="false" />
                            <asp:Label Text="Precio:" runat="server" CssClass="h5" />
                            <asp:TextBox runat="server" ID="txtPrecioE" CssClass="form-control rounded-left mt-1" Enabled="false" />
                            <asp:Label Text="Stock:" runat="server" CssClass="h5" />
                            <asp:TextBox runat="server" ID="txtStockE" CssClass="form-control rounded-left mt-1" Enabled="false" />
                            <asp:Label Text="Rubro" runat="server" CssClass="h5" />
                            <asp:DropDownList ID="ddlRubroEliminar" runat="server" Enabled="false" CssClass="form-control rounded-left mt-1"></asp:DropDownList>
                        </div>
                        <div class="modal-footer">
                            <div id="EliminarBtnModal" runat="server">
                                <asp:Button ID="btnNoEliminar" Text="No" runat="server" type="button" class="btn btn-secondary" data-bs-dismiss="modal" OnClick="btnNoEliminar_Click" />
                                <asp:Button ID="btnSiEliminar" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="btnSiEliminar_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
