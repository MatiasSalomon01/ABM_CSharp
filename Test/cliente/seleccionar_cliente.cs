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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test
{
    public partial class seleccionar_cliente : Form
    {
        OracleConnection oracle;
        public seleccionar_cliente()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var indexRow = e.RowIndex;
                var row = dataGridView1.Rows[indexRow];

                var nombre = row.Cells[1].Value.ToString();
                var apellido = row.Cells[2].Value.ToString();

                var num = Convert.ToInt16(row.Cells[0].Value.ToString()); 
            }
            catch{}
        }

        private void seleccionar_cliente_Load(object sender, EventArgs e)
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
    }
}
