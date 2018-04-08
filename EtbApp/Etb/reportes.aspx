<%@ Page Title="" Language="C#" MasterPageFile="~/Etb/Etb.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="EtbApp.Etb.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav class="navbar navbar-default">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Informacion ETB</a>
            </div>
            <ul class="nav navbar-nav">
                <li><a href="etbFactura.aspx">Subir factura</a></li>
                <li class="active"><a href="reportes.aspx">Reportes</a></li>
               
            </ul>
        </div>
    </nav>
    <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="tabla" runat="server" CssClass="table table-striped"></asp:GridView>
                </div>

            </div>           
    </div>
</asp:Content>
