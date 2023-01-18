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
    public partial class visualizar_producto : UserControl
    {
        
        OracleConnection oracle;
        public visualizar_producto()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
        }
        public void get_data()
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_producto", oracle);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            var ad = new OracleDataAdapter();
            ad.SelectCommand = query;

            var tabla = new DataTable();
            ad.Fill(tabla);
            dataGridView1.DataSource = tabla;

            oracle.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            //button1.BackColor = Color.FromArgb(149, 229, 115);
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //button1.BackColor = Color.FromArgb(187, 255, 159);
        }
    }
}
