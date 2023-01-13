using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class crear_usuario : Form
    {
        OracleConnection oracle;
        public crear_usuario()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");

        }

        private void guardar_Click(object sender, EventArgs e)
        {

        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var login = new login();
                login.Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guardar_Click_1(object sender, EventArgs e)
        {
            oracle.Open();

            string nom = txt_nom.Text;
            string ape = txt_ape.Text;
            string direcc = txt_direcc.Text;
            string fecha_nac = txt_nacimiento.Text;
            string tel = txt_tel.Text;
            string email = txt_email.Text;
            string usu = txt_usu.Text;
            string contra = txt_contra.Text.ToString();


            if ((nom != "") && (ape != "")&&(direcc != "") && (fecha_nac != "")&&(tel != "") && (email != "")&&(usu != "") && (contra != ""))
            {
                /*OracleCommand query = new OracleCommand("insert into usuario (name, passwrd) values ('" + usu + "', '" + contra + "')", oracle);

                query.ExecuteNonQuery();*/

                OracleCommand query = new OracleCommand("pkg_cliente.sp_create_user", oracle);
                query.Parameters.Add("nom", DbType.String).Value = nom;
                query.Parameters.Add("ape", DbType.String).Value = ape;
                query.Parameters.Add("direcc", DbType.String).Value = direcc;
                query.Parameters.Add("fecha_nac", DbType.String).Value = fecha_nac;
                query.Parameters.Add("tel", DbType.String).Value = tel;
                query.Parameters.Add("email", DbType.String).Value = email;
                query.Parameters.Add("user_name", DbType.String).Value = usu;
                query.Parameters.Add("user_pass", DbType.String).Value = contra;

                query.CommandType = CommandType.StoredProcedure;

                query.ExecuteNonQuery();
                MessageBox.Show("Creación Exitosa!!");
            }
            else
            {
                MessageBox.Show("Error - Usuario o Contraseña incompleta");
            }

            txt_nom.Clear();
            txt_ape.Clear();
            txt_direcc.Clear();
            txt_nacimiento.Clear();
            txt_tel.Clear();
            txt_email.Clear();
            txt_usu.Clear();
            txt_contra.Clear();

            oracle.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new login();
            login.Visible = true;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
        }
    }
}
