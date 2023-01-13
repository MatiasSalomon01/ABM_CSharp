namespace Test
{
    partial class producto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button10 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_visualizar = new System.Windows.Forms.Button();
            this.btn_crear = new System.Windows.Forms.Button();
            this.panel_seleccion = new System.Windows.Forms.Panel();
            this.userControl41 = new Test.eliminar_producto();
            this.userControl31 = new Test.actualizar_producto();
            this.userControl21 = new Test.visualizar_producto();
            this.userControl11 = new Test.crear_producto();
            this.crear_producto1 = new Test.crear_producto();
            this.visualizar_producto1 = new Test.visualizar_producto();
            this.actualizar_producto1 = new Test.actualizar_producto();
            this.eliminar_producto1 = new Test.eliminar_producto();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(12, 12);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 28);
            this.button10.TabIndex = 10;
            this.button10.Text = "Atras";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btn_eliminar);
            this.panel1.Controls.Add(this.btn_actualizar);
            this.panel1.Controls.Add(this.btn_visualizar);
            this.panel1.Controls.Add(this.btn_crear);
            this.panel1.Location = new System.Drawing.Point(12, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 427);
            this.panel1.TabIndex = 12;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Location = new System.Drawing.Point(0, 220);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(168, 52);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.button4_Click);
            this.btn_eliminar.MouseEnter += new System.EventHandler(this.btn_eliminar_MouseEnter);
            this.btn_eliminar.MouseLeave += new System.EventHandler(this.btn_eliminar_MouseLeave);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.Location = new System.Drawing.Point(0, 147);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(168, 52);
            this.btn_actualizar.TabIndex = 2;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.button3_Click);
            this.btn_actualizar.MouseEnter += new System.EventHandler(this.btn_actualizar_MouseEnter);
            this.btn_actualizar.MouseLeave += new System.EventHandler(this.btn_actualizar_MouseLeave);
            // 
            // btn_visualizar
            // 
            this.btn_visualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_visualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_visualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_visualizar.Location = new System.Drawing.Point(0, 74);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Size = new System.Drawing.Size(168, 52);
            this.btn_visualizar.TabIndex = 1;
            this.btn_visualizar.Text = "Visualizar";
            this.btn_visualizar.UseVisualStyleBackColor = true;
            this.btn_visualizar.Click += new System.EventHandler(this.button2_Click_1);
            this.btn_visualizar.MouseEnter += new System.EventHandler(this.btn_visualizar_MouseEnter);
            this.btn_visualizar.MouseLeave += new System.EventHandler(this.btn_visualizar_MouseLeave);
            // 
            // btn_crear
            // 
            this.btn_crear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_crear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear.Location = new System.Drawing.Point(0, 0);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(168, 52);
            this.btn_crear.TabIndex = 0;
            this.btn_crear.Text = "Crear";
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.button1_Click_1);
            this.btn_crear.MouseEnter += new System.EventHandler(this.btn_crear_MouseEnter);
            this.btn_crear.MouseLeave += new System.EventHandler(this.btn_crear_MouseLeave);
            // 
            // panel_seleccion
            // 
            this.panel_seleccion.BackColor = System.Drawing.Color.Transparent;
            this.panel_seleccion.ForeColor = System.Drawing.Color.Transparent;
            this.panel_seleccion.Location = new System.Drawing.Point(-4, 81);
            this.panel_seleccion.Name = "panel_seleccion";
            this.panel_seleccion.Size = new System.Drawing.Size(10, 52);
            this.panel_seleccion.TabIndex = 15;
            // 
            // userControl41
            // 
            this.userControl41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.userControl41.Location = new System.Drawing.Point(216, 1);
            this.userControl41.Name = "userControl41";
            this.userControl41.Size = new System.Drawing.Size(635, 491);
            this.userControl41.TabIndex = 14;
            // 
            // userControl31
            // 
            this.userControl31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.userControl31.Location = new System.Drawing.Point(224, 9);
            this.userControl31.Name = "userControl31";
            this.userControl31.Size = new System.Drawing.Size(635, 564);
            this.userControl31.TabIndex = 13;
            // 
            // userControl21
            // 
            this.userControl21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.userControl21.Location = new System.Drawing.Point(216, 1);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(635, 477);
            this.userControl21.TabIndex = 4;
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.userControl11.Location = new System.Drawing.Point(216, 1);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(635, 477);
            this.userControl11.TabIndex = 11;
            // 
            // crear_producto1
            // 
            this.crear_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.crear_producto1.Location = new System.Drawing.Point(216, 12);
            this.crear_producto1.Name = "crear_producto1";
            this.crear_producto1.Size = new System.Drawing.Size(635, 477);
            this.crear_producto1.TabIndex = 16;
            // 
            // visualizar_producto1
            // 
            this.visualizar_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.visualizar_producto1.Location = new System.Drawing.Point(216, 12);
            this.visualizar_producto1.Name = "visualizar_producto1";
            this.visualizar_producto1.Size = new System.Drawing.Size(635, 477);
            this.visualizar_producto1.TabIndex = 17;
            // 
            // actualizar_producto1
            // 
            this.actualizar_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.actualizar_producto1.Location = new System.Drawing.Point(216, 12);
            this.actualizar_producto1.Name = "actualizar_producto1";
            this.actualizar_producto1.Size = new System.Drawing.Size(635, 562);
            this.actualizar_producto1.TabIndex = 18;
            // 
            // eliminar_producto1
            // 
            this.eliminar_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.eliminar_producto1.Location = new System.Drawing.Point(216, 12);
            this.eliminar_producto1.Name = "eliminar_producto1";
            this.eliminar_producto1.Size = new System.Drawing.Size(635, 477);
            this.eliminar_producto1.TabIndex = 19;
            // 
            // producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 576);
            this.Controls.Add(this.eliminar_producto1);
            this.Controls.Add(this.actualizar_producto1);
            this.Controls.Add(this.visualizar_producto1);
            this.Controls.Add(this.crear_producto1);
            this.Controls.Add(this.panel_seleccion);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.Name = "producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "producto";
            this.Load += new System.EventHandler(this.crear_producto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.crear_producto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button10;
        private crear_producto userControl11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_visualizar;
        private visualizar_producto userControl21;
        private actualizar_producto userControl31;
        private eliminar_producto userControl41;
        private System.Windows.Forms.Panel panel_seleccion;
        private crear_producto crear_producto1;
        private visualizar_producto visualizar_producto1;
        private actualizar_producto actualizar_producto1;
        private eliminar_producto eliminar_producto1;
    }
}