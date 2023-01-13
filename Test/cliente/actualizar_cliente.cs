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
    public partial class actualizar_cliente : Form
    {
        string user;
        int num;
        OracleConnection oracle;

        public actualizar_cliente()
        {
            InitializeComponent();

        }
        public actualizar_cliente(string u)
        {
            user = u;
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            this.Text = "Usuario: " + user;
            get_data();
        }

        private void actualizar_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var manejo_de_Datos = new manejo_de_datos(user);
                manejo_de_Datos.Visible = true;
            }
        }

        private void actualizar_cliente_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_Datos = new manejo_de_datos(user);
            manejo_de_Datos.Visible = true;
        }
        private void get_data()
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_cliente", oracle);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            var ad = new OracleDataAdapter();
            ad.SelectCommand = query;

            var tabla = new DataTable();
            ad.Fill(tabla);
            dataGridView1.DataSource = tabla;

            oracle.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var indexRow = e.RowIndex;
                var row = dataGridView1.Rows[indexRow];

                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();

                num = Convert.ToInt16(row.Cells[0].Value.ToString());
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_update_cliente_by_id", oracle);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("num", OracleType.Int16).Value = num;
            query.Parameters.Add("nom", OracleType.VarChar).Value = textBox1.Text;
            query.Parameters.Add("ape", OracleType.VarChar).Value = textBox2.Text;
            query.Parameters.Add("direcc", OracleType.VarChar).Value = textBox3.Text;
            query.Parameters.Add("fecha_nac", OracleType.VarChar).Value = textBox4.Text;
            query.Parameters.Add("tel", OracleType.VarChar).Value = textBox5.Text;
            query.Parameters.Add("mail", OracleType.VarChar).Value = textBox6.Text;
            query.Parameters.Add("respuesta", OracleType.VarChar).Value = 0;
            query.Parameters["respuesta"].Direction = ParameterDirection.Output;

            query.ExecuteNonQuery();
            MessageBox.Show("Cliente Actualizado con exito");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            oracle.Close();

            get_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
