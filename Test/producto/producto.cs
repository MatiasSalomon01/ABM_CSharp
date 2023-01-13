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
            this.Text = "Usuario: " + user;

        }

        private void crear_producto_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            btn_crear.BackColor = Color.FromArgb(187, 255, 159);
            btn_visualizar.BackColor = Color.FromArgb(187, 255, 159);
            btn_eliminar.BackColor = Color.FromArgb(187, 255, 159);
            btn_actualizar.BackColor = Color.FromArgb(187, 255, 159);

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
    }
}
