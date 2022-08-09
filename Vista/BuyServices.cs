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
using Vista.View;

namespace Vista
{
    public partial class BuyServices : Form
    {

        Tickets tickets = new Tickets();
        double total = 0;
        double totalPagar =0;
        double totalImpuesto = 0;
        public BuyServices()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AmenitiesSumary()
            {
                StartPosition = FormStartPosition.CenterScreen
            }.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿desea salir?","Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿desea guardar los cambios?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using(Session5Entities model =new Session5Entities())
                {
                    try
                    {
                        Tickets _tickets = model.Tickets.FirstOrDefault(x => x.ID == tickets.ID);
                        model.AmenitiesTickets.RemoveRange(_tickets.AmenitiesTickets.ToList());
                        model.SaveChanges();
                        foreach (var item in FLPServices.Controls)
                        {
                            CheckBox checkBox = item as CheckBox;
                            if (checkBox.Enabled && checkBox.Checked)
                            {
                                int.TryParse(checkBox.Tag.ToString(), out int IDA);
                                Amenities amenities = model.Amenities.FirstOrDefault(x => x.ID == IDA);
                                model.AmenitiesTickets.Add(new AmenitiesTickets
                                {

                                    AmenityID = IDA,
                                    Price = amenities.Price,
                                    TicketID = _tickets.ID
                                });
                            }
                        }
                        int resultado = model.SaveChanges();
                        MessageBox.Show($"se ha guardado correctamente con {resultado} servicios");
                        cmbFlight.SelectedIndex = 0;

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show($"No se ha podido guardar");
                    }
                }
            }
        }

        private void BuyServices_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoooking.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el booking references");
                    return;
                }
                using (Session5Entities model = new Session5Entities())
                {
                    List<Tickets> ticketsList = model.Tickets.Where(x => x.BookingReference.ToLower() == txtBoooking.Text.ToLower()).ToList();
                    if (ticketsList.Count == 0)
                    {
                        MessageBox.Show($"No existe esta referencia {txtBoooking.Text.ToUpper()}");
                    }
                    else
                    {

                        var list = ticketsList.Select(x => new ScheduleView() { ID = x.ID, Name = $"{x.Schedules.FlightNumber} {x.Schedules.Routes.Airports.IATACode}-{x.Schedules.Routes.Airports1.IATACode} {x.Schedules.Date} {x.Schedules.Time}" }).ToList();

                        list.Insert(0, new ScheduleView()
                        {
                            ID = 0,
                            Name = "Seleccione un vuelo"
                        });
                        cmbFlight.DataSource = list;
                        cmbFlight.DisplayMember = "Name";
                        cmbFlight.ValueMember = "ID";

                    }

                }
            }
            catch (Exception er)
            {

                MessageBox.Show($"Error en la conexion :) => {er.Message}");
            }
        }

        private void cmbFlight_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Session5Entities model = new Session5Entities())
            {

                int.TryParse(cmbFlight.SelectedValue.ToString(), out int ID);
                tickets = model.Tickets.FirstOrDefault(x => x.ID == ID);
                if (tickets != null)
                {
                    txtName.Text = $"{tickets.Firstname}  {tickets.Lastname}";
                    txtPassport.Text = tickets.PassportNumber;
                    txtCabinType.Text = tickets.CabinTypes.Name ;
                    List<Amenities> list = model.Amenities.ToList();
                    FLPServices.Controls.Clear();
                    foreach (var item in list)
                    {
                        CheckBox checkBox = new CheckBox();
                        if(tickets.CabinTypes.Amenities.Count(d=> d.ID == item.ID)>0) 
                        {
                            checkBox = new CheckBox()
                            {
                                Visible = true,
                                AutoSize = true,
                                Text = $"{item.Service}(Free)",
                                Enabled = false,
                                Margin = new Padding(20,10,20,0),
                                Checked = true,
                                Tag = item.ID
                                
                            };
                        }
                        else if (tickets.AmenitiesTickets.Count(d => d.AmenityID == item.ID) > 0)
                        {
                            total += (double)item.Price;
                            totalImpuesto += ((double)item.Price) * 0.05;
                            totalPagar = total + totalImpuesto;
                            checkBox = new CheckBox()
                            {
                                Visible = true,
                                AutoSize = true,
                                Text = $"{item.Service}(${Math.Round(item.Price,2)})",
                                Checked = true,
                                Tag = item.ID

                            };
                        }
                        else
                        {
                            checkBox = new CheckBox()
                            {
                                Visible = true,
                                AutoSize = true,
                                Text = $"{item.Service}(${Math.Round(item.Price, 2)})",
                                Tag = item.ID

                            };
                        }
                        checkBox.CheckedChanged += (d, ev) =>
                        {
                           
                            if (checkBox.Checked)
                            {
                                total += (double)item.Price;
                                totalImpuesto += ((double)item.Price) * 0.05;
                                totalPagar = total + totalImpuesto;
                            }else
                            {
                                total -= (double)item.Price;
                                totalImpuesto -= ((double)item.Price) * 0.05;
                                totalPagar = total + totalImpuesto;
                            }
                            txtTotal.Text = $"$ {total}";
                            txtTotalImpuesto.Text = $"$ {totalImpuesto}";
                            txtTotalPagar.Text= $"$ {totalPagar}";
                        };
                        FLPServices.Controls.Add(checkBox);
                    }
                    txtTotal.Text = $"$ {total}";
                    txtTotalImpuesto.Text = $"$ {totalImpuesto}";
                    txtTotalPagar.Text = $"$ {totalPagar}";
                } else
                {
                    Limpiar();
                }
            }
        }

        private void Limpiar()
        {
            txtName.Text = $"";
            txtPassport.Text = "";
            txtCabinType.Text = "";
            txtTotal.Text = "$ 0";
            txtTotalImpuesto.Text = "$ 0";
            txtTotalPagar.Text = "$ 0";
            txtBoooking.Text = "";
            FLPServices.Controls.Clear();
        }
    }
}
