using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
    public partial class actualizar_producto : UserControl
    {
        OracleConnection oracle;
        int num;
        
        public actualizar_producto()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            get_data();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
            rellenar_categorias();
            rellenar_proveedores();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var indexRow = e.RowIndex;
                var row = dataGridView1.Rows[indexRow];

                txt_nom.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                oracle.Open();
                OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_name_categoria", oracle);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add("id_", OracleType.Int16).Value = Convert.ToInt16(row.Cells[4].Value.ToString());
                query.Parameters.Add("nom", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleCommand query1 = new OracleCommand("pkg_abm_system.sp_get_name_proveedor", oracle);
                query1.CommandType = CommandType.StoredProcedure;
                query1.Parameters.Add("id_", OracleType.Int16).Value = Convert.ToInt16(row.Cells[5].Value.ToString());
                query1.Parameters.Add("nom", OracleType.Cursor).Direction = ParameterDirection.Output;

                var x = query.ExecuteReader();
                var y = query1.ExecuteReader();

                if (x.Read() && y.Read())
                {
                    comboBox1.Text = x.GetString(0);
                    comboBox2.Text = y.GetString(0);

                }
                oracle.Close();

                num = Convert.ToInt16(row.Cells[0].Value.ToString());
                button1.Enabled = true;
            }
            catch {}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                oracle.Open();

                OracleCommand query = new OracleCommand("pkg_abm_system.sp_update_producto_by_id", oracle);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add("num", OracleType.Int16).Value = num;
                query.Parameters.Add("nom", OracleType.VarChar).Value = txt_nom.Text;
                query.Parameters.Add("precio_", OracleType.Int32).Value = Convert.ToInt32(textBox2.Text);
                query.Parameters.Add("stock_", OracleType.Int32).Value = Convert.ToInt32(textBox3.Text);
                query.Parameters.Add("cat", OracleType.VarChar).Value = comboBox1.Text;
                query.Parameters.Add("prov", OracleType.VarChar).Value = comboBox2.Text;
                query.Parameters.Add("respuesta", OracleType.VarChar).Value = 0;
                query.Parameters["respuesta"].Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();
                MessageBox.Show("Producto Actualizado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                oracle.Close();

                get_data();
                limpiar_txt();
                rellenar_categorias();
                rellenar_proveedores();
            }
        }
        public void rellenar_categorias()
        {
            comboBox1.Items.Clear();

            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_categorias", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            DbDataReader dr = query.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
            }

            oracle.Close();
        }

        public void rellenar_proveedores()
        {
            comboBox2.Items.Clear();
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_get_proveedores", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            DbDataReader dr = query.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr.GetString(0));
            }
            oracle.Close();
        }

        public void limpiar_txt()
        {
            txt_nom.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            button1.Enabled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
