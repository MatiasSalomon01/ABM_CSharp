using System;
using System.Collections;
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
    public partial class eliminar_cliente : Form
    {
        string user;
        OracleConnection oracle;

        public eliminar_cliente()
        {
            InitializeComponent();
        }
        public eliminar_cliente(string u)
        {
            user = u;
            InitializeComponent();
            this.Text = "Usuario: " + user;
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            btn_eliminar.Enabled = false;
        }

        private void eliminar_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var manejo_de_datos = new manejo_de_datos(user);
                manejo_de_datos.Visible = true;
            }
        }

        private void eliminar_cliente_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
            btn_eliminar.BackColor = Color.FromArgb(219, 255, 204);
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
                OracleCommand query = new OracleCommand("pkg_abm_system.sp_exists_cliente", oracle);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("num", OracleType.Int32).Value = txt_data;
                query.Parameters.Add("row_count", OracleType.Int32).Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();

                int row_count = Convert.ToInt32(query.Parameters["row_count"].Value);
                    
                if (row_count > 0)
                {
                    if ("0".Equals(cb_data))
                    {
                        OracleCommand query1 = new OracleCommand("pkg_abm_system.sp_find_cliente_by_id", oracle);
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
                    MessageBox.Show("Cliente no encontrado, intente de nuevo");
                    txt_dato.Clear();
                    txt_dato.Focus();
                }
            }
            oracle.Close();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro que quieres eliminar Cliente "+txt_dato.Text+"?", "ATENCIÓN", MessageBoxButtons.YesNo);
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

            OracleCommand query = new OracleCommand("pkg_abm_system.sp_delete_cliente_by_id", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("data", OracleType.Int32).Value = id;

            query.ExecuteNonQuery();

            oracle.Close();
            return "Cliente eliminado con exito";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_datos = new manejo_de_datos(user);
            manejo_de_datos.Visible = true;
        }

        private void txt_dato_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_MouseEnter_1(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(187, 255, 159);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }
    }
}
