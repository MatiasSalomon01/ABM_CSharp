﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace Test
{
    public partial class login : Form
    {
        private OracleConnection oracle;

        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            var status = conectarDb();
            if (status.Equals(true))
            {
                string usuario = textBox1.Text;
                string passwrd = textBox2.Text.ToString();

                var permiso = validar_user(usuario, passwrd);

                if (permiso == true)
                {
                    var form3 = new menu(usuario);
                    form3.Show();
                    this.Hide();
                }
                textBox1.ResetText();
                textBox2.ResetText();

                textBox1.Focus();
            }
        }

        private bool conectarDb()
        {
            Boolean status = true;
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            try{
                oracle.Open();
            }
            catch{
                status = false;
            }
            oracle.Close();
            return status;
        }

        private Boolean comparar_user(string usuario, string passwrd)
        {
            oracle.Open();

            string resp = null;

            OracleCommand query = new OracleCommand("select name passwrd from usuario where name = '"+ usuario+"' and passwrd = '"+passwrd+"'", oracle);
            OracleDataReader x = query.ExecuteReader();

            if(x.Read() == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Usuario o Contrasela no reconocido, porfavor intente de nuevo");
                return false;
            }
            oracle.Close();
        }

        private Boolean validar_user(string usuario, string passwrd)
        {
            oracle.Open();
            Boolean status = true;
            int num = 0;
            OracleCommand query = new OracleCommand("pkg_cliente.sp_validate_user", oracle);
            query.Parameters.Add("user_name", DbType.String).Value = usuario;
            query.Parameters.Add("user_pass", DbType.String).Value = passwrd;
            query.Parameters.Add("respuesta", DbType.Int16).Value = num;
            query.Parameters["respuesta"].Direction = ParameterDirection.Output;

            query.CommandType = CommandType.StoredProcedure;

            query.ExecuteNonQuery();

            if (0.Equals(query.Parameters["respuesta"].Value))
            {
                status = true;
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña no reconocido, porfavor intente de nuevo");
                status = false;
            }
            
            oracle.Close();
            return status;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var crear_usuario= new crear_usuario();
            crear_usuario.Show();
            this.Hide();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font.Name, label5.Font.SizeInPoints, FontStyle.Underline);
            label5.ForeColor = Color.Purple;

        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font.Name, label5.Font.SizeInPoints, FontStyle.Regular);
            label5.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}