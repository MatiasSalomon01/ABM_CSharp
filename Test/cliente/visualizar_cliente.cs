using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class visualizar_cliente : Form
    {
        string user;
        OracleConnection oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");

        public visualizar_cliente()
        {
            InitializeComponent();
        }

        public visualizar_cliente(string u)
        {
            user = u;
            InitializeComponent();
            this.Text = "Usuario: " + user;
            get_data();
        }

        private void get_data()
        {
            oracle.Open();


            OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_cliente", oracle);
            query.CommandType= CommandType.StoredProcedure;
            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            var ad = new OracleDataAdapter();
            ad.SelectCommand= query;

            var tabla = new DataTable();
            ad.Fill(tabla); 
            dataGridView1.DataSource = tabla;

            oracle.Close(); 
        }

        private void visualizar_cliente_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var manejo_de_datos = new manejo_de_datos(user);
                manejo_de_datos.Visible = true;
            }
        }

        private void visualizar_cliente_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_datos = new manejo_de_datos(user);
            manejo_de_datos.Visible = true;
        }
    }
}
