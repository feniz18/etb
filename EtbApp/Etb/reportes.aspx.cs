using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EtbApp.modelo.DataSet1;

namespace EtbApp.Etb
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        ETBDataTable dt_PUC = new ETBDataTable();
        public DataTable dtReporte = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["conEtb"].ConnectionString;
                String q1 = "SELECT REFERENCIA_PAGO, CUENTA_CONTRATO, FECHA_PAGO, FECHA_LIMITE, VALOR_A_PAGAR,CONCAT('(415)77071815000017(8020)', REFERENCIA_PAGO,'(3900)',VALOR_A_PAGAR,'(96)',FECHA_LIMITE) AS CODIGO_BARRAS  FROM dbo.ETB";
                SqlDataAdapter da = new SqlDataAdapter(q1, con);
                da.Fill(this.dtReporte);
                ds.Tables.Add(this.dtReporte);
                con.Close();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/reporte/Report1.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                foreach (var item in ds.Tables)
                {
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ETB", item));
                }

                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ds.Tables[1]));
                ReportViewer1.DocumentMapCollapsed = true;
                ReportViewer1.LocalReport.Refresh();


                //DataTable dt = new DataTable();
                //DataTable dt2 = new DataTable();

                //SqlConnection con = new SqlConnection();

                //con.ConnectionString = ConfigurationManager.ConnectionStrings["conEtb"].ConnectionString;


                //string query1 = "SELECT * FROM ETB";

                //SqlCommand cmd1 = new SqlCommand(query1, con);
                //con.Open();
                //SqlDataAdapter da = new SqlDataAdapter(cmd1);
                //da.Fill(dt);
                //con.Close();

                //dt2.Columns.Add("REFERENCIA_PAGO", Type.GetType("System.String"));
                //dt2.Columns.Add("CUENTA_CONTRATO", Type.GetType("System.String"));
                //dt2.Columns.Add("FECHA_PAGO", Type.GetType("System.String"));
                //dt2.Columns.Add("FECHA_LIMITE", Type.GetType("System.String"));
                //dt2.Columns.Add("VALOR_A_PAGAR", Type.GetType("System.String"));
                //dt2.Columns.Add("VER_REPORTE");

                //DataRow agrega ;

                //foreach (DataRow row in dt.Rows)
                //{
                //    agrega = dt2.NewRow();
                //    agrega["REFERENCIA_PAGO"] = row[0].ToString();
                //    agrega["CUENTA_CONTRATO"] = row[1].ToString();
                //    agrega["FECHA_PAGO"] = row[2].ToString();
                //    agrega["FECHA_LIMITE"] = row[3].ToString();
                //    agrega["VALOR_A_PAGAR"] = row[4].ToString();
                //    agrega["VER_REPORTE"] = "< asp:Button ID = '" + row[0].ToString() + "' runat = 'server' Text = 'Button' />'";
                //    dt2.Rows.Add(agrega);

                //}
                //tabla.DataSource = dt2;           
                //tabla.DataBind();


            }
        }
    }
}