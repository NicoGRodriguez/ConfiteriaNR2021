<%@ Page Title="Gestionar Rubro" Language="C#" MasterPageFile="~/Html/HomeMaster.Master" AutoEventWireup="true" CodeBehind="GestionarRubro.aspx.cs" Inherits="ConfiteriaNR.Html.GestionarRubro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function mostrarModal() {
            $('#AgregarModal').modal('show');
        }
        function mostrarModal2() {
            $('#ModalEliminar').modal('show');
        }
        function mostrarModal3() {
            $('#EditarModal').modal('show');
        }
    </script>
    <asp:Label Text="Gestion de rubro" runat="server" class="text-lef mb-4 h2" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-group">
                <asp:Label Text="Agregar nuevo rubro" runat="server" CssClass="h5" />
                <br />
                <asp:Button class="form-control btn btn-primary rounded submit px-3 mt-1 col-2" ID="btnAgregarRubro" Text="Agregar" runat="server" OnClientClick="mostrarModal()" OnClick="btnAgregarRubro_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="form-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Label Text="Rubros en el sistema" runat="server" CssClass="h5" />
                <div class="table table-bordered border-primary">
                    <asp:GridView ID="gvGestionarRubro" OnRowCommand="gvGestionarRubro_RowCommand" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="Id_Rubro" HeaderText="#" HeaderStyle-CssClass="table-primary" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre de Rubro" HeaderStyle-CssClass="table-primary" />
                            <asp:BoundField DataField="Fecha_Alta" HeaderText="Se agrego el dia" HeaderStyle-CssClass="table-primary" />
                            <asp:TemplateField HeaderStyle-CssClass="table-primary">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" runat="server" Text="Editar" OnClientClick="mostrarModal3();" CssClass="btn btn-outline-primary" CommandArgument='<%#Eval("Id_Rubro") %>' CommandName="Editar" />
                                    <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" OnClientClick="mostrarModal2();" CssClass="btn btn-outline-primary" CommandArgument='<%#Eval("Id_Rubro") %>' CommandName="Eliminar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />

    <!-- Modal 1  Agregar-->
    <div class="modal fade" id="AgregarModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Agrega Rubro" runat="server" class="modal-title" ID="staticBackdropLabel" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body form-group">
                    <asp:Label Text="Nombre de rubro" runat="server" CssClass="h5" />
                    <asp:TextBox MaxLength="4" ID="txtNombreRubroAgregar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Letras()" oninput="maxlengthNumber(this);" />
                    <asp:Label Text="Fecha de Alta" runat="server" CssClass="h5" />
                    <input id="InputFechaAlta" type="date" class="form-control" runat="server">
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAgregar" Text="Agregar" runat="server" type="button" class="btn btn-warning" data-bs-dismiss="modal" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal 3 Editar-->
    <div class="modal fade" id="EditarModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Editar Rubro" runat="server" class="modal-title" ID="Label2" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body form-group">
                            <div id="idDiv" visible="false" runat="server">
                                <asp:Label Text="Id" runat="server" CssClass="h5" />
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control rounded-left mt-1" Enabled="false" />
                            </div>
                            <asp:Label Text="Nombre de rubro" runat="server" CssClass="h5" />
                            <asp:TextBox ID="txtNombreRubroEditar" runat="server" CssClass="form-control rounded-left mt-1" OnKeyDown="Letras()" MaxLength="4" oninput="maxlengthNumber(this);"/>
                            <asp:Label Text="Fecha de Alta" runat="server" CssClass="h5" />
                            <asp:TextBox ID="txtFechaAlta" runat="server" CssClass="form-control rounded-left mt-1" />
                            <asp:Label Text="Fecha de Baja" runat="server" CssClass="h5" />
                            <asp:TextBox ID="txtFechaBaja" runat="server" CssClass="form-control rounded-left mt-1" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer">
                    <asp:Button ID="btnDarBaja" Text="Dar de baja" runat="server" type="button" class="btn btn-warning" data-bs-dismiss="modal" OnClick="btnDarBaja_Click" />
                    <asp:Button ID="btnNo" Text="No" runat="server" type="button" class="btn btn-secondary" data-bs-dismiss="modal" OnClick="btnNo_Click" />
                    <asp:Button ID="btnSi" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="btnSi_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal 2 Eliminar-->
    <div class="modal fade" id="ModalEliminar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
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
