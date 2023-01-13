﻿using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Data.Common;
using iTextSharp.text.pdf.parser;
using System.Xml.Linq;

namespace Test
{
    public partial class venta : Form
    {
        string user;
        int valor = 0;
        int suma = 0;
        int estado = 1;
        int c_valor_cl = 0;
        int c_valor_p = 0;
        
        //string path = "C:\\Users\\msalomon\\Documents\\Oracle\\Facturas";

        OracleConnection oracle;

        public venta()
        {
            InitializeComponent();
        }
        public venta(string u)
        {
            user = u;
            InitializeComponent();
            oracle = new OracleConnection("DATA SOURCE = CONEXION_CLIENT ; PASSWORD = 123 ; USER ID = SYSTEM;");
            this.Text = "Usuario: " + user;
            //panel3.Hide();

        }

        private void venta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listar_filas();
                this.Close();
                var menu = new menu(user);
                menu.Visible = true;
               
            }
        }

        private void venta_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(219, 255, 204);
            dataGridView1.BackgroundColor = Color.FromArgb(219, 255, 204);
            dataGridView2.BackgroundColor = Color.FromArgb(219, 255, 204);


            var dateTime = DateTime.Now;
            var shortDateValue = dateTime.ToShortDateString();
            txt_fecha.Text = shortDateValue;

            txt_emisor.Text = "CLT S.A";

            rellenar_forma_pago();
            panel3.BringToFront();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c_valor_cl += 1;
            valor = 0;
            panel3.Show();
            show_clientes();
            panel3.Location = new Point(24, 190);
            if (2.Equals(c_valor_cl))
            {
                panel3.Hide();
                c_valor_cl = 0;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void show_clientes()
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_cliente.sp_get_cliente", oracle);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            var ad = new OracleDataAdapter();
            ad.SelectCommand = query;

            var tabla = new DataTable();
            ad.Fill(tabla);
            dataGridView2.DataSource = tabla;

            oracle.Close();
        }
        private void show_productos()
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_producto.sp_get_producto", oracle);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            var ad = new OracleDataAdapter();
            ad.SelectCommand = query;

            var tabla = new DataTable();
            ad.Fill(tabla);
            dataGridView2.DataSource = tabla;

            oracle.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (0.Equals(valor))
                {
                    var indexRow = e.RowIndex;
                    var row = dataGridView2.Rows[indexRow];

                    txt_cliente_ruc.Text = row.Cells[0].Value.ToString();
                    txt_cliente_nombre.Text = row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString();
                    panel3.Hide();

                }
                else if (1.Equals(valor))
                {
                    var indexRow = e.RowIndex;
                    var row = dataGridView2.Rows[indexRow];

                    txt_id_producto.Text = row.Cells[0].Value.ToString();
                    panel3.Hide();
                }
            }
            catch
            {
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            c_valor_p += 1;
            valor = 1;
            panel3.Show();
            show_productos();
            panel3.Location = new Point(24, 245);
            if (2.Equals(c_valor_p))
            {
                panel3.Hide();
                c_valor_p = 0;
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            var id_cli = txt_cliente_ruc.Text;
            var id_pro = txt_id_producto.Text;
            var cantidad = txt_cantidad.Text;
            string forma_pago;
            if (cbPagos.SelectedItem == null)
            {
                MessageBox.Show("Error - Datos necesarios Incompletos");
            }
            else
            {
                forma_pago = cbPagos.SelectedItem.ToString();

                if (id_cli != string.Empty && id_pro != string.Empty && cantidad != string.Empty && forma_pago != string.Empty)
                {
                    var c = Convert.ToInt32(cantidad);
                    var id_produc = Convert.ToInt32(id_pro);

                    int msg = check_stock(id_produc, c);

                    if (0.Equals(msg))
                    {
                        oracle.Open();

                        OracleCommand query = new OracleCommand("pkg_facturacion.sp_create_detalle", oracle);
                        query.CommandType = CommandType.StoredProcedure;

                        query.Parameters.Add("id_pro", OracleType.Int32).Value = id_pro;
                        query.Parameters.Add("cantidad", OracleType.Int32).Value = cantidad;

                        try
                        {
                            query.ExecuteNonQuery();

                            oracle.Close();

                            rellenar_cabecera(forma_pago);
                            rellenar_detalle(c);

                            estado = 0;
                        }
                        catch (OracleException err)
                        {
                            if (err.Code == 20001)
                            {
                                MessageBox.Show("Cantidad excedida");
                            }
                            oracle.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Stock Insuficiente, quedan " + msg);
                    }
                }
                else
                {
                    MessageBox.Show("Error - Datos necesarios Incompletos");
                }
            }
            oracle.Close();
        }

        private void rellenar_detalle(int c)
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_facturacion.sp_get_last_detalle2", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("id_", OracleType.Int32).Direction = ParameterDirection.Output;
            query.Parameters.Add("pre", OracleType.Int32).Direction = ParameterDirection.Output;
            query.Parameters.Add("imp", OracleType.Int32).Direction = ParameterDirection.Output;

            query.ExecuteNonQuery();

            int monto = Int32.Parse(query.Parameters["imp"].Value.ToString());

            OracleCommand query1 = new OracleCommand("select nombre from producto where id_producto = '" + query.Parameters["id_"].Value + "'", oracle);

            var nom = query1.ExecuteReader();
            nom.Read();

            dataGridView1.Rows.Add(new object[] { query.Parameters["id_"].Value, nom.GetString(0), c, query.Parameters["pre"].Value, monto });

            suma += monto;
            txt_monto_final.Text = "Gs " + suma.ToString();

            oracle.Close();
        }

        private void rellenar_cabecera(string pago)
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_facturacion.sp_create_cabecera", oracle);
            OracleCommand query1 = new OracleCommand("pkg_facturacion.sp_get_id_pago_by_name", oracle);

            query.CommandType = CommandType.StoredProcedure;
            query1.CommandType = CommandType.StoredProcedure;

            query1.Parameters.Add("nom", OracleType.VarChar).Value = pago;
            query1.Parameters.Add("id_", OracleType.Int16).Direction = ParameterDirection.Output;

            query1.ExecuteNonQuery();

            query.Parameters.Add("nom_emisor", OracleType.VarChar).Value = txt_emisor.Text;
            query.Parameters.Add("fecha", OracleType.VarChar).Value = txt_fecha.Text;
            query.Parameters.Add("id_cliente", OracleType.Int16).Value = Int16.Parse(txt_cliente_ruc.Text);
            query.Parameters.Add("id_forma_pago", OracleType.Int16).Value = query1.Parameters["id_"].Value;

            query.ExecuteNonQuery();

            oracle.Close();
        }

        private void rellenar_forma_pago()
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_facturacion.sp_get_forma_pagos", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            DbDataReader dr = query.ExecuteReader();

            while (dr.Read())
            {
                cbPagos.Items.Add(dr.GetString(0));
            }
            oracle.Close();
        }

        private int check_stock(int id_produc, int cant)
        {
            oracle.Open();

            OracleCommand query = new OracleCommand("pkg_producto.sp_check_stock", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("id_", OracleType.Int16).Value = id_produc;
            query.Parameters.Add("cant", OracleType.Int16).Value = cant;
            query.Parameters.Add("msg", OracleType.Int16).Direction = ParameterDirection.Output;

            query.ExecuteNonQuery();

            int msg = Convert.ToInt16(query.Parameters["msg"].Value);

            oracle.Close();

            return msg;
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            if (0.Equals(estado))
            {
                var longDateValue = DateTime.Now.ToString("dd-MM-yyy-HH.mm.ss");

                SaveFileDialog save = new SaveFileDialog();
                string nombreArchivo = txt_cliente_ruc.Text + txt_cliente_nombre.Text + "_" + longDateValue + ".pdf";

                save.FileName = nombreArchivo;

                oracle.Open();
                OracleCommand query = new OracleCommand("pkg_facturacion.sp_get_factura_num", oracle);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("data", OracleType.VarChar).Value = nombreArchivo;
                query.Parameters.Add("boleto", OracleType.Int16).Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();


                string html_text = Properties.Resources.index.ToString();
                html_text = html_text.Replace("@CLIENTE", txt_cliente_nombre.Text);
                html_text = html_text.Replace("@DOCUMENTO", txt_cliente_ruc.Text);
                html_text = html_text.Replace("@FECHA", txt_fecha.Text);
                html_text = html_text.Replace("@NRO", query.Parameters["boleto"].Value.ToString());

                oracle.Close();

                string filas = string.Empty;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Column1"].Value?.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Column2"].Value?.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Column3"].Value?.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Column4"].Value?.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Column5"].Value?.ToString() + "</td>";
                    filas += "</tr>";
                }

                html_text = html_text.Replace("@FILAS", filas);
                html_text = html_text.Replace("@TOTAL", txt_monto_final.Text);


                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document facturapdf = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(facturapdf, stream);

                        facturapdf.Open();
                        facturapdf.Add(new Phrase());

                        using (StringReader sr = new StringReader(html_text))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, facturapdf, sr);
                        }

                        facturapdf.Close();
                        stream.Close();
                    }
                }
                try
                {
                    System.Diagnostics.Process.Start("C:\\Users\\msalomon\\Documents\\Oracle\\Facturas\\" + nombreArchivo);
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Datos Necesarios incompletos");
            }

        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void venta_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listar_filas();
            this.Close();
            var menu = new menu(user);
            menu.Show();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //DataGridViewRow row = dataGridView1.CurrentRow;
                //var fila_seleccionada = dataGridView1.CurrentRow.Index;

                if (dataGridView1.CurrentCell != null)
                {
                    var fila_seleccionada = dataGridView1.CurrentRow.Index;
                    var id_produc = dataGridView1.Rows[fila_seleccionada].Cells[0].Value?.ToString();
                    var cantidad = dataGridView1.Rows[fila_seleccionada].Cells[2].Value?.ToString();

                    var valor_importe = Convert.ToInt32(dataGridView1.Rows[fila_seleccionada].Cells[4].Value.ToString());

                    if (id_produc != string.Empty)
                    {
                        DialogResult dialogResult = MessageBox.Show("Seguro que quieres eliminar este Producto?", "ATENCIÓN", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            dataGridView1.Rows.RemoveAt(fila_seleccionada);

                            var res = reestablecer_stock(id_produc, cantidad);
                            MessageBox.Show(res);

                            suma = suma - valor_importe;
                            txt_monto_final.Text = "Gs " + suma.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string reestablecer_stock(string producto, string cantidad)
        {
            oracle.Open();
            OracleCommand query = new OracleCommand("pkg_producto.sp_add_stock", oracle);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("id_", OracleType.Int32).Value = Convert.ToInt32(producto);
            query.Parameters.Add("cantidad", OracleType.Int32).Value = Convert.ToInt32(cantidad);
            query.Parameters.Add("msg", OracleType.Cursor).Direction = ParameterDirection.Output;

            var msg = query.ExecuteReader();

            msg.Read();

            string res = msg.GetString(1).ToString();

            oracle.Close();
            return res;
        }


        private void listar_filas()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                /*var id_produc = dataGridView1.Rows[fila_seleccionada].Cells[0].Value?.ToString();
                var cantidad = dataGridView1.Rows[fila_seleccionada].Cells[2].Value?.ToString();*/
                reestablecer_stock(row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString());
            }
        }

        private void btn_eliminar_todo_Click(object sender, EventArgs e)
        {
            listar_filas();
            dataGridView1.Rows.Clear();
        }
    }
}