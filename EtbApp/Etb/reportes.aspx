﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Etb/Etb.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="EtbApp.Etb.Formulario_web12" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col-md-12 {
            width: 553px;
        }
    </style>
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

<button type="button" class="btn btn-warning
    
    
    
    
    btn-lg" data-toggle="modal" data-target="#miModal">
	Abrir modal
</button>
            <div class="row">
                <div class="col-md-12" style = "overflow: visible;" >

                     
                   
                    
                </div>

            </div>           
    </div>


    <div class="modal fade" id="miModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
	    <div class="modal-dialog  modal-lg" role="document">
		    <div class="modal-content">
			    <div class="modal-header">
				    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
					    <span aria-hidden="true">&times;</span>
				    </button>
				    <h4 class="modal-title" id="myModalLabel">Esto es un modal</h4>
			    </div>
			    <div class="modal-body">
				    
                    <%-- inicio modal --%>


                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:ObjectDataSource ID="ObjectDataSource1"  runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="EtbApp.modelo.DataSet1TableAdapters.ETBTableAdapter">
                        <InsertParameters>
                            <asp:Parameter Name="REFERENCIA_PAGO" Type="String" />
                            <asp:Parameter Name="CUENTA_CONTRATO" Type="String" />
                            <asp:Parameter Name="FECHA_PAGO" Type="DateTime" />
                            <asp:Parameter Name="FECHA_LIMITE" Type="DateTime" />
                            <asp:Parameter Name="VALOR_A_PAGAR" Type="Int64" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    
                     <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Font-Names="Arial" Font-Size="8pt"
                        Width="778px" ShowCredentialPrompts="False" ShowParameterPrompts="False"
                        SizeToReportContent="True"  Height="241px" BackColor=""  ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                         <LocalReport ReportPath="reporte\Report1.rdlc">
                             <DataSources>
                                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                             </DataSources>
                         </LocalReport>
        
                   </rsweb:ReportViewer>

                    <%-- fin modal --%>

			    </div>
		    </div>
	    </div>
    </div>
</asp:Content>
