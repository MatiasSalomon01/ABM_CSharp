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
    public partial class crear_proveedor : UserControl
    {
        OracleConnection oracle;

        public crear_proveedor()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
        }

        private void crear_proveedor_Load(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void btn_guardar_MouseEnter(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(149, 229, 115);
        }

        private void btn_guardar_MouseLeave(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != string.Empty && txt_direccion.Text != string.Empty && txt_telefono.Text != string.Empty)
            {
                oracle.Open();
                OracleCommand query = new OracleCommand("pkg_abm_system.sp_create_proveedor", oracle);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add("nom", OracleType.VarChar).Value = txt_nombre.Text;
                query.Parameters.Add("direcc", OracleType.VarChar).Value = txt_direccion.Text;
                query.Parameters.Add("tel", OracleType.VarChar).Value = txt_telefono.Text;
                query.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;

                var x = query.ExecuteReader();

                if (x.Read())
                {
                    MessageBox.Show(x.GetString(0), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                oracle.Close();

                txt_direccion.Clear();
                txt_telefono.Clear();
                txt_nombre.Clear();
            }
            else
            {
                MessageBox.Show("Error - Datos Incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
