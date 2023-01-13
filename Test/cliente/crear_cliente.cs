﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class crear_cliente : Form
    {
        string user;
        OracleConnection oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");

        public crear_cliente()
        {
            InitializeComponent();
        }
        public crear_cliente(string u)
        {
            user = u;
            InitializeComponent();
            this.Text = "Usuario: " + user;
        }

        private void crear_cliente_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
        }

        private void crear_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                var manejo_de_datos = new manejo_de_datos(user);
                manejo_de_datos.Visible = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            oracle.Open();

            string nom = txt_nom.Text;
            string ape = txt_ape.Text;
            string direcc = txt_direcc.Text;
            string fecha_nac = txt_nacimiento.Text;
            string tel = txt_tel.Text;
            string email = txt_email.Text;


            if ((nom != "") && (ape != "") && (direcc != "") && (fecha_nac != "") && (tel != "") && (email != ""))
            {
                OracleCommand query = new OracleCommand("pkg_cliente.sp_create_cliente", oracle);
                query.Parameters.Add("nom", DbType.String).Value = nom;
                query.Parameters.Add("ape", DbType.String).Value = ape;
                query.Parameters.Add("direcc", DbType.String).Value = direcc;
                query.Parameters.Add("fecha_nac", DbType.String).Value = fecha_nac;
                query.Parameters.Add("tel", DbType.String).Value = tel;
                query.Parameters.Add("email", DbType.String).Value = email;

                query.CommandType = CommandType.StoredProcedure;

                query.ExecuteNonQuery();
                MessageBox.Show("Creación Exitosa!!");
            }
            else
            {
                MessageBox.Show("Error - Campos incompletos");
            }

            txt_nom.Clear();
            txt_ape.Clear();
            txt_direcc.Clear();
            txt_nacimiento.Clear();
            txt_tel.Clear();
            txt_email.Clear();

            oracle.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            var manejo_de_datos = new manejo_de_datos(user);
            manejo_de_datos.Visible = true;
        }
    }
}
