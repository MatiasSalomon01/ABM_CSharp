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
    public partial class eliminar_producto : UserControl
    {
        OracleConnection oracle;
        public eliminar_producto()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            btn_eliminar.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            var cb_data = cb_buscar.GetItemText(cb_buscar.SelectedIndex);
            if ("".Equals(txt_dato.Text))
            {
                MessageBox.Show("Error - Campo vacio");
            }
            else
            {
                var txt_data = Int32.Parse(txt_dato.Text);
                oracle.Open();
                OracleCommand query = new OracleCommand("pkg_abm_system.sp_exists_producto", oracle);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("num", OracleType.Int32).Value = txt_data;
                query.Parameters.Add("row_count", OracleType.Int32).Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();

                int row_count = Convert.ToInt32(query.Parameters["row_count"].Value);

                if (row_count > 0)
                {
                    if ("0".Equals(cb_data))
                    {
                        OracleCommand query1 = new OracleCommand("pkg_abm_system.sp_find_producto_by_id", oracle);
                        query1.CommandType = CommandType.StoredProcedure;

                        query1.Parameters.Add("data", OracleType.Int32).Value = txt_data;
                        query1.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;

                        var ad = new OracleDataAdapter();
                        ad.SelectCommand = query1;
                        var tabla = new DataTable();
                        ad.Fill(tabla);
                        dataGridView1.DataSource = tabla;

                        btn_eliminar.Enabled = true;
                    }
                    else if ("1".Equals(cb_data))
                    {
                        MessageBox.Show("Nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado, intente de nuevo");
                    txt_dato.Clear();
                    txt_dato.Focus();
                }
            }
            oracle.Close();
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro que quieres eliminar Producto " + txt_dato.Text + "?", "ATENCIÓN", MessageBoxButtons.YesNo);
            var id = Int32.Parse(txt_dato.Text);

            if (dialogResult == DialogResult.Yes)
            {
                var res = eliminar(id);
                MessageBox.Show(res);

                dataGridView1.DataSource = null;
                txt_dato.Clear();
                txt_dato.Focus();

            }
            else if (dialogResult == DialogResult.No)
            {
                txt_dato.Focus();
            }
        }
        private string eliminar(int id)
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_delete_producto_by_id", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("data", OracleType.Int32).Value = id;

            query.ExecuteNonQuery();

            oracle.Close();
            return "Producto eliminado con exito";
        }

        private void txt_dato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0".Equals(cb_buscar.GetItemText(cb_buscar.SelectedIndex)))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }*/
            }
        }
    }
}
