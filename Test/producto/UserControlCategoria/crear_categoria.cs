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
    public partial class crear_categoria : UserControl
    {
        string iva = "";
        OracleConnection oracle;
        public crear_categoria()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(149, 229, 115);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text != string.Empty && iva != string.Empty)
            {
                oracle.Open();
                OracleCommand query = new OracleCommand("pkg_abm_system.sp_create_categoria", oracle);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("descrip", OracleType.VarChar).Value = txt_descripcion.Text;
                query.Parameters.Add("iva_", OracleType.VarChar).Value = iva;
                query.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;

                var x = query.ExecuteReader();

                if (x.Read())
                {
                    MessageBox.Show(x.GetString(0), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                oracle.Close();
                txt_descripcion.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                MessageBox.Show("Error - Datos Incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crear_categoria_Load(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            iva = checkBox1.Text;
            checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            iva = checkBox2.Text;
            checkBox1.Checked = false;
        }
    }
}
