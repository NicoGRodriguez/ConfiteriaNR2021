<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Html/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="ConfiteriaNR.Html.Consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:Label Text="Reportes" runat="server" class="text-lef mb-4 h2" />
        <asp:Label ID="lblFecha" Text="Elija una fecha" runat="server" CssClass="h4" />
        <br />
        <div class="col-md-7 col-lg-8">
            <input id="InputFecha" type="date" class="form-control" runat="server">
            <asp:Button ID="btnNuevaBusqueda" Text="Nueva busqueda" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-3" OnClick="btnNuevaBusqueda_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-7 col-lg-4">
            <asp:Label Text="Ventas diarias" runat="server" class="text-lef mb-4 h4" />
            <asp:Button ID="btnCargarVentasDia" Text="Cargar ventas del dia" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-3" OnClick="btnCargarVentasDia_Click" />
        </div>
        <div class="col-md-7 col-lg-4">
            <asp:Label Text="Ventas de Mozos" runat="server" class="text-lef mb-4 h4" />
            <asp:Button ID="btnCargarVentaMozo" Text="Cargar ventas de mozos" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-3" OnClick="btnCargarVentaMozo_Click" />
        </div>
    </div>
    <br />
    <br />
    <div id="Imprimir">
        <div class="row" runat="server" visible="false" id="tablaVentasDia">
            <asp:GridView runat="server" ID="gvCargarVentasDia" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="Articulo" HeaderText="Articulo" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="Importe" HeaderText="Importe" HeaderStyle-CssClass="table-primary" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="row" runat="server" visible="false" id="tablaVentasMozo">
            <asp:GridView runat="server" ID="gvCargarVentaMozo" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="Mozo" HeaderText="Mozo" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="CantidadArticulo" HeaderText="Cant.Articulos" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="ImporteTotal" HeaderText="Importe Total" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="Comision" HeaderText="Comision" HeaderStyle-CssClass="table-primary" />
                    <asp:BoundField DataField="Pagar" HeaderText="A pagar" HeaderStyle-CssClass="table-primary" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row" runat="server" visible="false" id="btnImprimir">
        <input id="btnImprimirInput" type="button" name="Imprimir" value="Imprimir" class="form-control btn btn-primary rounded submit px-3 mt-3" onclick="printDiv('Imprimir')" />
    </div>
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
             window.location.href = "Consulta.aspx"
             // Clean up print section for future use
             var oldElem = document.getElementById("printSection");
             if (oldElem != null) { oldElem.parentNode.removeChild(oldElem); }
             //oldElem.remove() not supported by IE
             return true;
         }
     </script>

</asp:Content>
