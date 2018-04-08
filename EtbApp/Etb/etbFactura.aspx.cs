using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtbApp.Etb
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void subirArchivo_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/UploadedDocument/");
            if (cargaArchivo.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(cargaArchivo.FileName).ToLower();
                String[] allowedExtensions =
                    { ".xls"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {



                try
                {
                    cargaArchivo.PostedFile.SaveAs(path + cargaArchivo.FileName);
                    Import_To_Grid(path + cargaArchivo.FileName, ".xls", "YES");

                    textoArchivo.Text = "El archivo se cargo correctamente";
                }
                catch (Exception ex)
                {
                    textoArchivo.Text = "Ha ocurrido un error: " + ex.ToString();
                }
            }
        }

        private void Import_To_Grid(string FilePath, string Extension, string isHDR)

        {

            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }

            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[2]["TABLE_NAME"].ToString();
            connExcel.Close();


            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT *  From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();


            //Bind Data to GridView
            //GridView1.Caption = Path.GetFileName(FilePath);



            Session["dt"] = dt;


            SqlConnection con = new SqlConnection();

            dt = (DataTable)Session["dt"];



            con.ConnectionString = ConfigurationManager.ConnectionStrings["conEtb"].ConnectionString;
            String q1 = "Delete from ETB";
            SqlCommand Cmd2 = new SqlCommand(q1, con);
            con.Open();
            Cmd2.ExecuteNonQuery();
            con.Close();



            //Full_Copia("PUC", dt, "");


            foreach (DataRow item in dt.Rows)
            {
                string referencia_pago = item[0].ToString();
                string cuenta_contrato = item[1].ToString();
                DateTime fecha_pago = DateTime.Parse(item[2].ToString());
                DateTime fecha_limite = fechaCondias(fecha_pago, 2);
                int valor_pagar = Convert.ToInt32(item[3]);

                string query1 = "insert into ETB(REFERENCIA_PAGO,CUENTA_CONTRATO,FECHA_PAGO,FECHA_LIMITE,VALOR_A_PAGAR) values ('" + referencia_pago + "','" + cuenta_contrato + "','" + fecha_pago.ToString("yyyyMMdd") + "','" + fecha_limite.ToString("yyyyMMdd") + "'," + valor_pagar + ");";

                SqlCommand cmd1 = new SqlCommand(query1, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();


            }

        }

        void Full_Copia(string Destino, DataTable Dt_Destino, string conexion, string BD = "Convenios_Bancos")
        {



            Stopwatch sw = new Stopwatch();
            // Warning!!! Optional parameters not supported
            sw.Start();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(("user id=sa; password=123456;Initial Catalog=contabilidad;Connect Timeout=600000;Data Source=DESKTOP-EHROM10\\SQLEXPRESS"), SqlBulkCopyOptions.TableLock);
            bulkCopy.NotifyAfter = 5000;
            bulkCopy.BatchSize = 10000;
            bulkCopy.BulkCopyTimeout = 1000000;
            bulkCopy.DestinationTableName = Destino;
            bulkCopy.WriteToServer(Dt_Destino);
            sw.Stop();
        }

        public static DateTime fechaCondias(DateTime fecha, int dias)
        {
            int direction = dias < 0 ? -1 : 1;
            DateTime nuevaFecha = fecha;
            while (dias != 0)
            {
                nuevaFecha = nuevaFecha.AddDays(direction);
                if (nuevaFecha.DayOfWeek != DayOfWeek.Saturday &&
                    nuevaFecha.DayOfWeek != DayOfWeek.Sunday)
                {
                    dias -= direction;
                }
            }

            int diasFestivos = DiasFestivosBD(fecha,nuevaFecha);

            nuevaFecha = nuevaFecha.AddDays(diasFestivos);

            return nuevaFecha;
        }

        public static int DiasFestivosBD(DateTime inicio, DateTime fin)
        {
            string fecha_inicio = inicio.ToString("yyyyMMdd");
            string fecha_fin = fin.ToString("yyyyMMdd");
            int dias = 0;

            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["conEtb"].ConnectionString;


            string query1 = "SELECT COUNT(FECHA_LIMITE) FROM ETB WHERE FECHA_LIMITE >= '" + fecha_inicio + "' AND FECHA_LIMITE < '" + fecha_fin + "';";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            con.Close();

            DataRow dia = dt.Rows[0];
            dias = Convert.ToInt32(dia[0]);

            return dias;

        }
    }
}