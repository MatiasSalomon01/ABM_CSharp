using iTextSharp.text.xml;
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
    public partial class producto : Form
    {
        string user;
        int panelY = 81;
        OracleConnection oracle;
        public producto()
        {
            InitializeComponent();
        }

        public producto(string u)
        {
            user = u;
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            this.Text = "Usuario: " + user;

        }

        private void crear_producto_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            //panel1.BackColor = Color.FromArgb(161, 234, 146);
            btn_crear.BackColor = Color.FromArgb(187, 255, 159);
            btn_visualizar.BackColor = Color.FromArgb(187, 255, 159);
            btn_eliminar.BackColor = Color.FromArgb(187, 255, 159);
            btn_actualizar.BackColor = Color.FromArgb(187, 255, 159);
            /*rellenar_categorias();
            rellenar_proveedores();*/

            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
        }


        private void crear_producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var manejo_de_Datos = new manejo_de_datos(user);
                manejo_de_Datos.Visible = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_Datos = new manejo_de_datos(user);
            manejo_de_Datos.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                oracle.Open();

                string nom = textBox1.Text;
                string precio = textBox2.Text;
                string stock = textBox3.Text;
                string categoria = comboBox1.SelectedItem.ToString();
                string proveedor = comboBox2.SelectedItem.ToString();

                if ((nom != "") && (precio != "") && (stock != "") && (categoria != "") && (proveedor != ""))
                {

                    OracleCommand query = new OracleCommand(" pkg_producto.sp_create_producto", oracle);
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
            catch
            {

            }

            oracle.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl21.Hide();
            userControl41.Hide();
            userControl11.Visible = true;
            panel_seleccion.Location = new Point(-4, 81);
            panel_seleccion.BackColor = Color.Green;
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl41.Hide();   
            userControl21.Visible = true;
            panel_seleccion.Location = new Point(-4, 155);
            panel_seleccion.BackColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl41.Hide();
            userControl31.Visible = true;
            panel_seleccion.Location = new Point(-4, 228);
            panel_seleccion.BackColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Visible = true;
            panel_seleccion.Location = new Point(-4, 301);
            panel_seleccion.BackColor = Color.Green;
        }

        private void btn_crear_MouseHover(object sender, EventArgs e)
        {
        }

        private void btn_crear_MouseLeave(object sender, EventArgs e)
        {
            btn_crear.BackColor = Color.FromArgb(187, 255, 159);

        }

        private void btn_crear_MouseEnter(object sender, EventArgs e)
        {
            btn_crear.BackColor = Color.FromArgb(149, 229, 115);
        }

        private void btn_visualizar_MouseEnter(object sender, EventArgs e)
        {
            btn_visualizar.BackColor = Color.FromArgb(149, 229, 115);
        }

        private void btn_visualizar_MouseLeave(object sender, EventArgs e)
        {
            btn_visualizar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void btn_actualizar_MouseEnter(object sender, EventArgs e)
        {
            btn_actualizar.BackColor = Color.FromArgb(149, 229, 115);
        }

        private void btn_actualizar_MouseLeave(object sender, EventArgs e)
        {
            btn_actualizar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void btn_eliminar_MouseLeave(object sender, EventArgs e)
        {
            btn_eliminar.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void btn_eliminar_MouseEnter(object sender, EventArgs e)
        {
            btn_eliminar.BackColor = Color.FromArgb(149, 229, 115);
        }

        private void btn_crear_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void btn_crear_MouseClick(object sender, MouseEventArgs e)
        {
            //btn_crear.BackColor = Color.FromArgb(149, 229, 115);
        }
        /*private void rellenar_categorias()
{
oracle.Open();

OracleCommand query = new OracleCommand("pkg_producto.sp_get_categorias", oracle);
query.CommandType = CommandType.StoredProcedure;

query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

DbDataReader dr = query.ExecuteReader();

while (dr.Read())
{
comboBox1.Items.Add(dr.GetString(0));
}

Console.WriteLine(query.Parameters["registros"].Value);
oracle.Close();
}

private void rellenar_proveedores()
{
oracle.Open();

OracleCommand query = new OracleCommand("pkg_producto.sp_get_proveedores", oracle);
query.CommandType = CommandType.StoredProcedure;

query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

DbDataReader dr = query.ExecuteReader();

while (dr.Read())
{
comboBox2.Items.Add(dr.GetString(0));
}

Console.WriteLine(query.Parameters["registros"].Value);
oracle.Close();
}*/


    }
}
