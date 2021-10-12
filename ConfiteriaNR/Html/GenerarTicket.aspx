<%@ Page Title="Generar Ticket" Language="C#" MasterPageFile="~/Html/HomeMaster.Master" AutoEventWireup="true" CodeBehind="GenerarTicket.aspx.cs" Inherits="ConfiteriaNR.Html.CrearVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="Generar Ticket" runat="server" class="text-lef mb-4 h2" />
    <div class="container">
        <asp:UpdatePanel ID="updtPan" runat="server">
            <ContentTemplate>
                <div class="row mt-4" id="tablaGV">
                    <div class="col-md">
                        <div class="table table-striped">
                            <asp:GridView ID="gvCarrito" runat="server" CssClass="table table-bordered table-hover  mt-5">
                                <HeaderStyle CssClass="table-primary" />
                            </asp:GridView>
                            <asp:Table ID="tblCarro" runat="server" Width="82px">
                            </asp:Table>
                            <div  CssClass="text-left">
                            <asp:Label Visible="false" ID="lblTotal" Text="" runat="server" />
                                </div>
                            <div runat="server" visible="false" id="btnImprimirFactura">
                                <input id="btnImprimirInput" type="button" name="Imprimir" value="Imprimir" class="form-control btn btn-primary rounded submit px-3 mt-3" onclick="printDiv('Modal_Imp')" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-md">
                        <div class="form-group row">
                            <div class="col-auto">
                                <asp:Label Text="Elegir mozo" runat="server" CssClass="h6 px-3 mt-3" />
                                <asp:DropDownList ID="cboMozo" runat="server" CssClass="form-control rounded-left px-3 mt-2" AutoPostBack="true"></asp:DropDownList>
                                <br />
                                <asp:LinkButton ID="btnAgregar" runat="server" Text="Agregar articulo" OnClientClick="mostrarModal();" CssClass="btn btn-primary rounded submit px-3 mt-1" />
                                <asp:LinkButton type="button" ID="btnFacturar" runat="server" Text="Terminar facturacion" OnClick="btnFacturar_Click" CssClass="btn btn-primary rounded submit px-3 mt-1" />
                                <asp:Button ID="btnLimpiarFac" Text="Limpiar facturacion" runat="server" CssClass="btn btn-primary rounded submit px-3 mt-1" OnClick="btnLimpiarFac_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- ModalProducto(Agregar) -->
    <div class="modal fade" id="ModalProducto" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Agregar articulo" runat="server" class="modal-title h4" ID="Label1" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <asp:Label Text="Articulo" runat="server" CssClass="h6" />
                                    <asp:DropDownList ID="cboArticulos" runat="server" CssClass="form-control rounded-left mt-1" OnSelectedIndexChanged="cboArticulos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:Label Text="Cantidad" runat="server" CssClass="h6" />
                                    <asp:TextBox MaxLength="2" oninput="maxlengthNumber(this);" type="number" ID="txtCantidad" runat="server" class="form-control" min="1" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarAgregarProducto" class="btn btn-outline-primary" Text="Agregar a la factura" runat="server" OnClick="btnConfirmarAgregarProducto_Click" />
                    <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" type="button" class="btn btn-outline-primary" data-bs-dismiss="modal" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- ModalFinFactura -->
    <div class="modal fade" id="ModalFinFactura" tabindex="-1" role="dialog">
        <div class="modal-dialog" style="max-width: 600px" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label Text="Facturacion Overnight" runat="server" class="h2 text-center" ID="staticBackdropLabel" />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body row" id="Modal_Imp">
                    <asp:Label Text="Av.SiempreVida 123" CssClass="h6 text-left pe-2" runat="server" />
                    <asp:Label Text="Cuit: 11-111111-12" CssClass="h6 text-left pe-2" runat="server" />
                    <asp:Label Text="Ing.B. 250831013" CssClass="h6 text-left pe-2" runat="server" />
                    <asp:Label Text="IVA RES. INSC. A CON FIN." CssClass="h6 text-left pe-2" runat="server" />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Label Text="Mozo: " ID="lblMozoModal" CssClass="h6 text-left pe-2" runat="server" />
                            <asp:Label ID="lblFechaModal" CssClass="h6 text-left pe-2" runat="server" />
                            <div class="col-md">
                                <div class="table table-striped">
                                    <asp:GridView ID="gvModalFac" runat="server" CssClass="table table-bordered table-hover  mt-5">
                                        <HeaderStyle CssClass="table-primary" />
                                    </asp:GridView>
                                    <asp:Table ID="Table1" runat="server" Width="82px">
                                    </asp:Table>
                                </div>
                            </div>
                            <asp:Label ID="TotalModal" Text="" runat="server" />
                        </ContentTemplate>                     
                    </asp:UpdatePanel>
                    
                </div>
                <div class="modal-footer">
                    <asp:Button type="button" Text="Confirmar Factura" ID="btnConfirmarFactura" runat="server" class="btn btn-outline-primary" OnClick="btnConfirmarFactura_Click" />
                    <asp:Button type="button" ID="btnConfirmarDescartarFactura" class="btn btn-outline-primary" Text="Cerrar" runat="server" data-bs-dismiss="modal" aria-label="Close" />
                </div>
            </div>
        </div>
    </div>
    <script>
        function mostrarModal() {
            $('#ModalProducto').modal('show');
        }
        function mostrarModal2() {
            $('#ModalFinFactura').modal('show');
        }
        function mostrarModal3() {
            $('#ModalConfirmarBorrar').modal('show');
        }
    </script>
    <script>
        function printDiv(div) {
            // Create and insert new print section
            var elem = document.getElementById(div);
            var domClone = elem.cloneNode(true);
            var $printSection = document.createElement("div");
            $printSection.id = "printSection";
            $printSection.appendChild(domClone);
            document.body.insertBefore($printSection, document.body.firstChild);
            var master = document.getElementById("form1");
            master.remove();
            window.print();
            window.location.href = "GenerarTicket.aspx"
            // Clean up print section for future use
            var oldElem = document.getElementById("printSection");
            if (oldElem != null) { oldElem.parentNode.removeChild(oldElem); }
            //oldElem.remove() not supported by IE
            return true;
        }
    </script>

</asp:Content>
