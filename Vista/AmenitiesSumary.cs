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
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog1.FileName;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                var libro = excel.Workbooks.Add(true);
                var hoja = libro.Sheets.Add("Inicio");
                int col = 0, row = 0;
                for (int i = 0; i < DTServiciosCabinType.ColumnCount; i++)
                {
                    hoja.Cells[row, col] = DTServiciosCabinType.Columns[i].Name;
                }
                libro.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, ruta);

            }

        }
    }
}

