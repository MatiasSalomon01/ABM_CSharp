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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(producto));
            this.button10 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_proveedor = new System.Windows.Forms.Panel();
            this.btn_eliminar_proveedor = new System.Windows.Forms.Button();
            this.btn_crear_proveedor = new System.Windows.Forms.Button();
            this.btn_proveedor = new System.Windows.Forms.Button();
            this.panel_categoria = new System.Windows.Forms.Panel();
            this.btn_eliminar_categoria = new System.Windows.Forms.Button();
            this.btn_crear_categoria = new System.Windows.Forms.Button();
            this.btn_categoria = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_visualizar = new System.Windows.Forms.Button();
            this.btn_crear = new System.Windows.Forms.Button();
            this.panel_seleccion = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.crear_categoria1 = new Test.crear_categoria();
            this.eliminar_producto1 = new Test.eliminar_producto();
            this.actualizar_producto1 = new Test.actualizar_producto();
            this.visualizar_producto1 = new Test.visualizar_producto();
            this.crear_producto1 = new Test.crear_producto();
            this.userControl41 = new Test.eliminar_producto();
            this.userControl31 = new Test.actualizar_producto();
            this.userControl21 = new Test.visualizar_producto();
            this.userControl11 = new Test.crear_producto();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.eliminar_categoria2 = new Test.eliminar_categoria();
            this.panel1.SuspendLayout();
            this.panel_proveedor.SuspendLayout();
            this.panel_categoria.SuspendLayout();
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
            this.panel1.Controls.Add(this.panel_proveedor);
            this.panel1.Controls.Add(this.panel_categoria);
            this.panel1.Controls.Add(this.btn_eliminar);
            this.panel1.Controls.Add(this.btn_actualizar);
            this.panel1.Controls.Add(this.btn_visualizar);
            this.panel1.Controls.Add(this.btn_crear);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 565);
            this.panel1.TabIndex = 12;
            // 
            // panel_proveedor
            // 
            this.panel_proveedor.Controls.Add(this.btn_eliminar_proveedor);
            this.panel_proveedor.Controls.Add(this.btn_crear_proveedor);
            this.panel_proveedor.Controls.Add(this.btn_proveedor);
            this.panel_proveedor.Location = new System.Drawing.Point(0, 367);
            this.panel_proveedor.MaximumSize = new System.Drawing.Size(168, 122);
            this.panel_proveedor.MinimumSize = new System.Drawing.Size(168, 52);
            this.panel_proveedor.Name = "panel_proveedor";
            this.panel_proveedor.Size = new System.Drawing.Size(168, 52);
            this.panel_proveedor.TabIndex = 5;
            // 
            // btn_eliminar_proveedor
            // 
            this.btn_eliminar_proveedor.BackColor = System.Drawing.SystemColors.Control;
            this.btn_eliminar_proveedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_eliminar_proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar_proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar_proveedor.Location = new System.Drawing.Point(0, 85);
            this.btn_eliminar_proveedor.Name = "btn_eliminar_proveedor";
            this.btn_eliminar_proveedor.Size = new System.Drawing.Size(168, 34);
            this.btn_eliminar_proveedor.TabIndex = 2;
            this.btn_eliminar_proveedor.Text = "Eliminar";
            this.btn_eliminar_proveedor.UseVisualStyleBackColor = false;
            // 
            // btn_crear_proveedor
            // 
            this.btn_crear_proveedor.BackColor = System.Drawing.SystemColors.Control;
            this.btn_crear_proveedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_crear_proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crear_proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear_proveedor.Location = new System.Drawing.Point(0, 51);
            this.btn_crear_proveedor.Name = "btn_crear_proveedor";
            this.btn_crear_proveedor.Size = new System.Drawing.Size(168, 34);
            this.btn_crear_proveedor.TabIndex = 1;
            this.btn_crear_proveedor.Text = "Crear";
            this.btn_crear_proveedor.UseVisualStyleBackColor = false;
            // 
            // btn_proveedor
            // 
            this.btn_proveedor.BackColor = System.Drawing.SystemColors.Control;
            this.btn_proveedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proveedor.Location = new System.Drawing.Point(0, 0);
            this.btn_proveedor.MinimumSize = new System.Drawing.Size(168, 52);
            this.btn_proveedor.Name = "btn_proveedor";
            this.btn_proveedor.Size = new System.Drawing.Size(168, 52);
            this.btn_proveedor.TabIndex = 0;
            this.btn_proveedor.Text = "Proveedor";
            this.btn_proveedor.UseVisualStyleBackColor = false;
            this.btn_proveedor.Click += new System.EventHandler(this.btn_proveedor_Click);
            // 
            // panel_categoria
            // 
            this.panel_categoria.Controls.Add(this.btn_eliminar_categoria);
            this.panel_categoria.Controls.Add(this.btn_crear_categoria);
            this.panel_categoria.Controls.Add(this.btn_categoria);
            this.panel_categoria.Location = new System.Drawing.Point(0, 294);
            this.panel_categoria.MaximumSize = new System.Drawing.Size(168, 122);
            this.panel_categoria.MinimumSize = new System.Drawing.Size(168, 52);
            this.panel_categoria.Name = "panel_categoria";
            this.panel_categoria.Size = new System.Drawing.Size(168, 52);
            this.panel_categoria.TabIndex = 4;
            // 
            // btn_eliminar_categoria
            // 
            this.btn_eliminar_categoria.BackColor = System.Drawing.SystemColors.Control;
            this.btn_eliminar_categoria.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_eliminar_categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar_categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar_categoria.Location = new System.Drawing.Point(0, 85);
            this.btn_eliminar_categoria.Name = "btn_eliminar_categoria";
            this.btn_eliminar_categoria.Size = new System.Drawing.Size(168, 34);
            this.btn_eliminar_categoria.TabIndex = 2;
            this.btn_eliminar_categoria.Text = "Eliminar";
            this.btn_eliminar_categoria.UseVisualStyleBackColor = false;
            this.btn_eliminar_categoria.Click += new System.EventHandler(this.btn_eliminar_categoria_Click);
            // 
            // btn_crear_categoria
            // 
            this.btn_crear_categoria.BackColor = System.Drawing.SystemColors.Control;
            this.btn_crear_categoria.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_crear_categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crear_categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear_categoria.Location = new System.Drawing.Point(0, 51);
            this.btn_crear_categoria.Name = "btn_crear_categoria";
            this.btn_crear_categoria.Size = new System.Drawing.Size(168, 34);
            this.btn_crear_categoria.TabIndex = 1;
            this.btn_crear_categoria.Text = "Crear";
            this.btn_crear_categoria.UseVisualStyleBackColor = false;
            this.btn_crear_categoria.Click += new System.EventHandler(this.btn_crear_categoria_Click);
            // 
            // btn_categoria
            // 
            this.btn_categoria.BackColor = System.Drawing.SystemColors.Control;
            this.btn_categoria.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_categoria.Location = new System.Drawing.Point(0, 0);
            this.btn_categoria.MinimumSize = new System.Drawing.Size(168, 52);
            this.btn_categoria.Name = "btn_categoria";
            this.btn_categoria.Size = new System.Drawing.Size(168, 52);
            this.btn_categoria.TabIndex = 0;
            this.btn_categoria.Text = "Categoria";
            this.btn_categoria.UseVisualStyleBackColor = false;
            this.btn_categoria.Click += new System.EventHandler(this.btn_categoria_Click);
            this.btn_categoria.MouseEnter += new System.EventHandler(this.btn_categoria_MouseEnter);
            this.btn_categoria.MouseLeave += new System.EventHandler(this.btn_categoria_MouseLeave);
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
            this.panel_seleccion.Location = new System.Drawing.Point(-4, 66);
            this.panel_seleccion.Name = "panel_seleccion";
            this.panel_seleccion.Size = new System.Drawing.Size(10, 52);
            this.panel_seleccion.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // crear_categoria1
            // 
            this.crear_categoria1.Location = new System.Drawing.Point(224, 20);
            this.crear_categoria1.Name = "crear_categoria1";
            this.crear_categoria1.Size = new System.Drawing.Size(635, 477);
            this.crear_categoria1.TabIndex = 20;
            // 
            // eliminar_producto1
            // 
            this.eliminar_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.eliminar_producto1.Location = new System.Drawing.Point(216, 12);
            this.eliminar_producto1.Name = "eliminar_producto1";
            this.eliminar_producto1.Size = new System.Drawing.Size(635, 477);
            this.eliminar_producto1.TabIndex = 19;
            // 
            // actualizar_producto1
            // 
            this.actualizar_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.actualizar_producto1.Location = new System.Drawing.Point(216, 12);
            this.actualizar_producto1.Name = "actualizar_producto1";
            this.actualizar_producto1.Size = new System.Drawing.Size(635, 562);
            this.actualizar_producto1.TabIndex = 18;
            // 
            // visualizar_producto1
            // 
            this.visualizar_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.visualizar_producto1.Location = new System.Drawing.Point(216, 12);
            this.visualizar_producto1.Name = "visualizar_producto1";
            this.visualizar_producto1.Size = new System.Drawing.Size(635, 477);
            this.visualizar_producto1.TabIndex = 17;
            // 
            // crear_producto1
            // 
            this.crear_producto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.crear_producto1.Location = new System.Drawing.Point(216, 12);
            this.crear_producto1.Name = "crear_producto1";
            this.crear_producto1.Size = new System.Drawing.Size(635, 477);
            this.crear_producto1.TabIndex = 16;
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
            // timer2
            // 
            this.timer2.Interval = 15;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // eliminar_categoria2
            // 
            this.eliminar_categoria2.Location = new System.Drawing.Point(216, 20);
            this.eliminar_categoria2.Name = "eliminar_categoria2";
            this.eliminar_categoria2.Size = new System.Drawing.Size(635, 477);
            this.eliminar_categoria2.TabIndex = 21;
            // 
            // producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 643);
            this.Controls.Add(this.eliminar_categoria2);
            this.Controls.Add(this.crear_categoria1);
            this.Controls.Add(this.eliminar_producto1);
            this.Controls.Add(this.actualizar_producto1);
            this.Controls.Add(this.visualizar_producto1);
            this.Controls.Add(this.crear_producto1);
            this.Controls.Add(this.panel_seleccion);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "producto";
            this.Load += new System.EventHandler(this.crear_producto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.crear_producto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel_proveedor.ResumeLayout(false);
            this.panel_categoria.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel_categoria;
        private System.Windows.Forms.Button btn_crear_categoria;
        private System.Windows.Forms.Button btn_categoria;
        private System.Windows.Forms.Timer timer1;
        private crear_categoria crear_categoria1;
        private System.Windows.Forms.Button btn_eliminar_categoria;
        private System.Windows.Forms.Panel panel_proveedor;
        private System.Windows.Forms.Button btn_eliminar_proveedor;
        private System.Windows.Forms.Button btn_crear_proveedor;
        private System.Windows.Forms.Button btn_proveedor;
        private System.Windows.Forms.Timer timer2;
        private eliminar_categoria eliminar_categoria2;
    }
}