<%@ Page Title="" Language="C#" MasterPageFile="~/Etb/Etb.Master" AutoEventWireup="true" CodeBehind="etbFactura.aspx.cs" Inherits="EtbApp.Etb.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-default">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Informacion ETB</a>
            </div>
            <ul class="nav navbar-nav">
                <li class="active"><a href="etbFactura.aspx">Subir factura</a></li>
                <li><a href="reportes.aspx">Reportes</a></li>
            </ul>
        </div>
    </nav>
    <div class="container-fluid">
            <div class="row form-group">
                <div class="col-md-3">
                    <asp:FileUpload ID="cargaArchivo" runat="server" CssClass="" />
                </div>
                <div class="col-md-9 col-md-offset-">

                    <asp:Button ID="subirArchivo" runat="server" Text="Subir archivo" CssClass="btn btn-success " OnClick="subirArchivo_Click" />

                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="textoArchivo" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            
    </div>
</asp:Content>
