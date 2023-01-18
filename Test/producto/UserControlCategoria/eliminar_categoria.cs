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
    public partial class eliminar_categoria : UserControl
    {
        OracleConnection oracle;
        public eliminar_categoria()
        {
            InitializeComponent(); 
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eliminar_categoria_Load(object sender, EventArgs e)
        {
            btn_eliminar.BackColor = Color.FromArgb(187, 255, 159);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
            get_data();
        }

        public void get_data()
        {
            oracle.Open();
            OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_categoria", oracle);

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

                txt_id_categoria.Text = row.Cells[0].Value.ToString();
                txt_descrip_categoria.Text = row.Cells[1].Value.ToString();
            }
            catch{}
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            oracle.Open();
            OracleCommand query = new OracleCommand("pkg_abm_system.sp_delete_categoria", oracle);

            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("id_", OracleType.Int32).Value = Convert.ToInt32(txt_id_categoria.Text);
            query.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;

            var x = query.ExecuteReader();

            if (x.Read())
            {
                MessageBox.Show(x.GetString(0));
            }

            oracle.Close();

            get_data();

        }
        public void limpiar_txt()
        {
            txt_id_categoria.Clear();
            txt_descrip_categoria.Clear();
        }
    }
}
