<%@ Page Title="" Language="C#" MasterPageFile="~/Etb/Etb.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="EtbApp.Etb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Informacion ETB</a>
            </div>
            <ul class="nav navbar-nav">
                <li><a href="etbFactura.aspx">Subir factura</a></li>
                <li><a href="reportes.aspx">Reportes</a></li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
