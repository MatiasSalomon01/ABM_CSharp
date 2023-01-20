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

namespace Test
{
    public partial class crear_producto : UserControl
    {
        OracleConnection oracle;
        public crear_producto()
        {
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            rellenar_categorias();
            rellenar_proveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    oracle.Open();

                    string nom = textBox1.Text;
                    string precio = textBox2.Text;
                    string stock = textBox3.Text;

                    if ((nom != "") && (precio != "") && (stock != "") && (comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null))
                    {

                        string categoria = comboBox1.SelectedItem.ToString();
                        string proveedor = comboBox2.SelectedItem.ToString();

                        OracleCommand query = new OracleCommand("pkg_abm_system.sp_create_producto", oracle);
                        query.Parameters.Add("nom", DbType.String).Value = nom;
                        query.Parameters.Add("precio", DbType.String).Value = precio;
                        query.Parameters.Add("stock", DbType.String).Value = stock;
                        query.Parameters.Add("id_cat", DbType.String).Value = categoria;
                        query.Parameters.Add("id_prov", DbType.String).Value = proveedor;

                        query.CommandType = CommandType.StoredProcedure;

                        query.ExecuteNonQuery();
                        MessageBox.Show("Creación Exitosa!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error - Datos incompletos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    comboBox1.SelectedItem = null;
                    comboBox2.SelectedItem = null;
                }
                catch (OracleException err)
                {
                    if (err.Code == 06502)
                    {
                    MessageBox.Show("Campos de Precio y Stock deben ser numericos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                oracle.Close();
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

    }
}
