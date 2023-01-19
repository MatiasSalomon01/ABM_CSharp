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
            if (txt_descripcion.Text != string.Empty)
            {
                oracle.Open();
                OracleCommand query = new OracleCommand("pkg_abm_system.sp_create_categoria", oracle);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("descrip", OracleType.VarChar).Value = txt_descripcion.Text;
                query.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;

                var x = query.ExecuteReader();

                if (x.Read())
                {
                    MessageBox.Show(x.GetString(0));
                }

                oracle.Close();
                txt_descripcion.Clear();
            }
            else
            {
                MessageBox.Show("Error - Datos Incompletos");
            }
        }

        private void crear_categoria_Load(object sender, EventArgs e)
        {
            btn_guardar.BackColor = Color.FromArgb(187, 255, 159);
        }
    }
}
