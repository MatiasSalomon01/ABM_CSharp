using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class crear_cliente : Form
    {
        string user;
        OracleConnection oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");

        public crear_cliente()
        {
            InitializeComponent();
        }
        public crear_cliente(string u)
        {
            user = u;
            InitializeComponent();
            this.Text = "Usuario: " + user;
        }

        private void crear_cliente_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
        }

        private void crear_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var manejo_de_datos = new manejo_de_datos(user);
                manejo_de_datos.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oracle.Open();

            string ced = txt_cedula.Text;
            string nom = txt_nom.Text;
            string ape = txt_ape.Text;
            string direcc = txt_direcc.Text;
            string fecha_nac = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string tel = txt_tel.Text;
            string email = txt_email.Text;


            if ((ced != "") && (nom != "") && (ape != "") && (direcc != "") && (fecha_nac != "") && (tel != "") && (email != ""))
            {
                OracleCommand query1 = new OracleCommand("pkg_abm_system.sp_validate_email", oracle);
                query1.CommandType = CommandType.StoredProcedure;

                query1.Parameters.Add("email_", OracleType.VarChar).Value = email;
                query1.Parameters.Add("respuesta", OracleType.Int32).Direction = ParameterDirection.Output;

                query1.ExecuteNonQuery();

                int resp = Convert.ToInt32(query1.Parameters["respuesta"].Value);
                if (resp == 0)
                {
                    OracleCommand query = new OracleCommand("pkg_abm_system.sp_create_cliente", oracle);
                    query.Parameters.Add("ced", OracleType.Int32).Value = Convert.ToInt32(ced);
                    query.Parameters.Add("nom", DbType.String).Value = nom;
                    query.Parameters.Add("ape", DbType.String).Value = ape;
                    query.Parameters.Add("direcc", DbType.String).Value = direcc;
                    query.Parameters.Add("fecha_nac", DbType.String).Value = fecha_nac;
                    query.Parameters.Add("tel", DbType.String).Value = tel;
                    query.Parameters.Add("email", DbType.String).Value = email;

                    query.CommandType = CommandType.StoredProcedure;

                    query.ExecuteNonQuery();
                    MessageBox.Show("Creación Exitosa!!");

                    txt_cedula.Clear();
                    txt_nom.Clear();
                    txt_ape.Clear();
                    txt_direcc.Clear();
                    dateTimePicker1.ResetText();
                    txt_tel.Clear();
                    txt_email.Clear();
                }
                else
                {
                    MessageBox.Show("Formato de email inválido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error - Campos incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            oracle.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_datos = new manejo_de_datos(user);
            manejo_de_datos.Visible = true;
        }

        private void txt_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_cedula.Clear();
            txt_nom.Clear();
            txt_ape.Clear();
            txt_direcc.Clear();
            dateTimePicker1.ResetText();
            txt_tel.Clear();
            txt_email.Clear();
        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
