using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtbApp.Etb
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["conEtb"].ConnectionString;


            string query1 = "SELECT * FROM ETB";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            con.Close();

            dt2.Columns.Add("REFERENCIA_PAGO", Type.GetType("System.String"));
            dt2.Columns.Add("CUENTA_CONTRATO", Type.GetType("System.String"));
            dt2.Columns.Add("FECHA_PAGO", Type.GetType("System.String"));
            dt2.Columns.Add("FECHA_LIMITE", Type.GetType("System.String"));
            dt2.Columns.Add("VALOR_A_PAGAR", Type.GetType("System.String"));
            dt2.Columns.Add("VER_REPORTE");

            DataRow agrega ;

            foreach (DataRow row in dt.Rows)
            {
                agrega = dt2.NewRow();
                agrega["REFERENCIA_PAGO"] = row[0].ToString();
                agrega["CUENTA_CONTRATO"] = row[1].ToString();
                agrega["FECHA_PAGO"] = row[2].ToString();
                agrega["FECHA_LIMITE"] = row[3].ToString();
                agrega["VALOR_A_PAGAR"] = row[4].ToString();
                agrega["VER_REPORTE"] = "< asp:Button ID = '" + row[0].ToString() + "' runat = 'server' Text = 'Button' />'";
                dt2.Rows.Add(agrega);

            }
            tabla.DataSource = dt2;           
            tabla.DataBind();


        }
    }
}