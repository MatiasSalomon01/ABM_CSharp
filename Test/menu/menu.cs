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
    public partial class menu : Form
    {
        string user;
        public menu()
        {
            InitializeComponent();
        }
        public menu(string u)
        {
            user = u;
            InitializeComponent();
            //current_user.Text += " " + user;
            this.Text = "Usuario: "+user;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_datos = new manejo_de_datos(user);
            manejo_de_datos.Visible = true;
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var login = new login();
                login.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                this.Close();
                var login = new login();
                login.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var venta= new venta(user);
            venta.Visible = true;
        }
    }
}
