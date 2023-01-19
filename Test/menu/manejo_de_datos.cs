using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class manejo_de_datos : Form
    {
        string user;
        public manejo_de_datos()
        {
            InitializeComponent();
        }
        public manejo_de_datos(string u)
        {
            user = u;
            InitializeComponent();
            this.Text = "Usuario: " + user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var form3 = new menu(user);
                form3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var crear_cliente = new crear_cliente(user);
            crear_cliente.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var visualizar_cliente = new visualizar_cliente(user);
            visualizar_cliente.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var eliminar_cliente = new eliminar_cliente(user);
            eliminar_cliente.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            var form3 = new menu(user);
            form3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            var crear_producto = new producto(user);
            crear_producto.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            var actualizar_cliente = new actualizar_cliente(user);
            actualizar_cliente.Visible = true;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = Color.FromArgb(187, 255, 159);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.Transparent;
        }
    }
}
