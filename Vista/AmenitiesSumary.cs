
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Models;
using ExcelJD = Microsoft.Office.Interop.Excel;

namespace Vista
{
    public partial class AmenitiesSumary : Form
    {
        public AmenitiesSumary()
        {
            InitializeComponent();
        }

        private void AmenitiesSumary_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿desea salir?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public int GetRow(String stringSearch)
        {
            for (int i = 0; i < DTServiciosCabinType.RowCount; i++)
            {
                if (DTServiciosCabinType.Rows[i].Cells[0].Value.ToString() == stringSearch)
                {
                    return i;
                }
            }
            return 0;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            using (Session5Entities model = new Session5Entities())
            {
                int.TryParse(txtBoooking.Text.Trim(), out int ID);
                var lista = model.servicesCabinType(ID);
                DTServiciosCabinType.ColumnCount = 0;
                DTServiciosCabinType.Columns.Add("TypeCabin", "Tipo Cabina");
                foreach (var item in model.CabinTypes.ToList())
                {
                    DTServiciosCabinType.Rows.Add(new string[] { item.Name });
                }
                foreach (var item in model.Amenities.ToList())
                {
                    DTServiciosCabinType.Columns.Add(item.Service, item.Service);
                }
                for (int i = 1; i < DTServiciosCabinType.ColumnCount; i++)
                {
                    for (int j = 0; j < DTServiciosCabinType.RowCount; j++)
                    {
                        DTServiciosCabinType.Rows[j].Cells[i].Value = 0.ToString();
                    }
                }
                foreach (var item in lista)
                {
                    DTServiciosCabinType.Rows[GetRow(item.Name)].Cells[item.Service].Value = item.cantidad;

                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFile.FileName;
                var wordApp = new ExcelJD.Application();
                wordApp.DisplayAlerts = false;
                //wordApp.Visible = true;
                var libro = wordApp.Workbooks.Add();
                ExcelJD.Worksheet worksheet = (ExcelJD.Worksheet)libro.Sheets[1];
                worksheet.Name = "Juan Diego";
            
                ExcelJD.Style estilo = libro.Styles.Add("CeldaFull");
                estilo.Font.Color = Color.Green;
                estilo.Font.Bold = true;
                estilo.Borders.Color = Color.Green;
                estilo.Borders[ExcelJD.XlBordersIndex.xlDiagonalDown].LineStyle = ExcelJD.XlLineStyle.xlLineStyleNone;
                estilo.Borders[ExcelJD.XlBordersIndex.xlDiagonalUp].LineStyle = ExcelJD.XlLineStyle.xlLineStyleNone;
                estilo.Font.Name = "Century Gothic";
                estilo.HorizontalAlignment = ExcelJD.XlHAlign.xlHAlignCenter;

                estilo.Font.Color = Color.Black;
                estilo.Font.Bold = false;
                estilo.Borders.Color = Color.Black;
                estilo.IncludeAlignment = true;
                estilo.HorizontalAlignment = ExcelJD.XlHAlign.xlHAlignCenter;
                estilo.Borders[ExcelJD.XlBordersIndex.xlDiagonalDown].LineStyle = ExcelJD.XlLineStyle.xlLineStyleNone;
                estilo.Borders[ExcelJD.XlBordersIndex.xlDiagonalUp].LineStyle = ExcelJD.XlLineStyle.xlLineStyleNone;

                worksheet.Range[$"C2:E{DTServiciosCabinType.ColumnCount + 1}"].Style = estilo;

                ExcelJD.Style estilo2 = libro.Styles.Add("CeldaFull2");
                estilo2.Font.Color = Color.Green;
                estilo2.Font.Bold = true;
                estilo2.Borders.Color = Color.Black;
                estilo2.Borders[ExcelJD.XlBordersIndex.xlDiagonalDown].LineStyle = ExcelJD.XlLineStyle.xlLineStyleNone;
                estilo2.Borders[ExcelJD.XlBordersIndex.xlDiagonalUp].LineStyle = ExcelJD.XlLineStyle.xlLineStyleNone;
                estilo2.Font.Name = "Century Gothic";
                estilo2.HorizontalAlignment = ExcelJD.XlHAlign.xlHAlignCenter;
                worksheet.Range["B2:E2"].Style = estilo2;
                worksheet.Range[$"B2:B{DTServiciosCabinType.ColumnCount + 1}"].Style = estilo2;

                int col = 3, row = 2;
                for (int i = 0; i < DTServiciosCabinType.RowCount; i++)
                {

                    worksheet.Cells[row, col] = DTServiciosCabinType.Rows[i].Cells[0].Value.ToString();
                    col++;
                }

                col = 2; row = 3;
                for (int i = 1; i < DTServiciosCabinType.ColumnCount; i++)
                {

                    worksheet.Cells[row, col] = DTServiciosCabinType.Columns[i].Name;
                    row++;
                }
                col = 3; row = 3;
                for (int i = 1; i < DTServiciosCabinType.ColumnCount; i++)
                {
                    col = 3;
                    for (int j = 0; j < DTServiciosCabinType.RowCount; j++)
                    {
                        worksheet.Cells[row, col] = DTServiciosCabinType.Rows[j].Cells[i].Value.ToString();
                        col++;
                    }
                    row++;
                }
                worksheet.Columns.AutoFit();


                libro.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, ruta);
                wordApp.Quit();
                System.Diagnostics.Process.Start(saveFile.FileName);
                MessageBox.Show("Se ha guardado correctamente");
            }

        }
    }
}

