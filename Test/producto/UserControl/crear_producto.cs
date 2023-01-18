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
                    string categoria = comboBox1.SelectedItem.ToString();
                    string proveedor = comboBox2.SelectedItem.ToString();

                    if ((nom != "") && (precio != "") && (stock != "") && (categoria != "") && (proveedor != ""))
                    {

                        OracleCommand query = new OracleCommand("pkg_abm_system.sp_create_producto", oracle);
                        query.Parameters.Add("nom", DbType.String).Value = nom;
                        query.Parameters.Add("precio", DbType.String).Value = precio;
                        query.Parameters.Add("stock", DbType.String).Value = stock;
                        query.Parameters.Add("id_cat", DbType.String).Value = categoria;
                        query.Parameters.Add("id_prov", DbType.String).Value = proveedor;

                        query.CommandType = CommandType.StoredProcedure;

                        query.ExecuteNonQuery();
                        MessageBox.Show("Creación Exitosa!!");
                    }
                    else
                    {
                        MessageBox.Show("Error - Usuario o Contraseña incompleta");
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                }
                catch (OracleException err)
                {
                    if (err.Code == 06502)
                    {
                    MessageBox.Show("Campos de Precio y Stock deben ser numericos");
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
