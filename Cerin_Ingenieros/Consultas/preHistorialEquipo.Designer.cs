namespace Cerin_Ingenieros.Consultas
{
    partial class preHistorialEquipo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_dni_ruc = new System.Windows.Forms.Label();
            this.lb_nombre_razonSocial = new System.Windows.Forms.Label();
            this.lb_dni_cliente = new System.Windows.Forms.Label();
            this.lb_nombreCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_servicios = new System.Windows.Forms.DataGridView();
            this.txb_Observaciones = new System.Windows.Forms.TextBox();
            this.txb_Recomendaciones = new System.Windows.Forms.TextBox();
            this.dataGridView_Accesorios = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_serie = new System.Windows.Forms.Label();
            this.lb_categoria_equipo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_telefono = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lb_modelo = new System.Windows.Forms.Label();
            this.lb_marca = new System.Windows.Forms.Label();
            this.lb_estadoEquipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_nombreEmpleado = new System.Windows.Forms.Label();
            this.txb_serie_equipo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_buscar = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.btnLimpiar = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_servicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_telefono);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lb_dni_ruc);
            this.groupBox2.Controls.Add(this.lb_nombre_razonSocial);
            this.groupBox2.Controls.Add(this.lb_dni_cliente);
            this.groupBox2.Controls.Add(this.lb_nombreCliente);
            this.groupBox2.Location = new System.Drawing.Point(46, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 130);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Cliente";
            // 
            // lb_dni_ruc
            // 
            this.lb_dni_ruc.AutoSize = true;
            this.lb_dni_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dni_ruc.Location = new System.Drawing.Point(115, 57);
            this.lb_dni_ruc.Name = "lb_dni_ruc";
            this.lb_dni_ruc.Size = new System.Drawing.Size(89, 20);
            this.lb_dni_ruc.TabIndex = 61;
            this.lb_dni_ruc.Text = "DNI o RUC";
            // 
            // lb_nombre_razonSocial
            // 
            this.lb_nombre_razonSocial.AutoSize = true;
            this.lb_nombre_razonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombre_razonSocial.Location = new System.Drawing.Point(115, 16);
            this.lb_nombre_razonSocial.Name = "lb_nombre_razonSocial";
            this.lb_nombre_razonSocial.Size = new System.Drawing.Size(166, 20);
            this.lb_nombre_razonSocial.TabIndex = 60;
            this.lb_nombre_razonSocial.Text = "Cliente o Rasón social";
            // 
            // lb_dni_cliente
            // 
            this.lb_dni_cliente.AutoSize = true;
            this.lb_dni_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dni_cliente.Location = new System.Drawing.Point(6, 57);
            this.lb_dni_cliente.Name = "lb_dni_cliente";
            this.lb_dni_cliente.Size = new System.Drawing.Size(41, 20);
            this.lb_dni_cliente.TabIndex = 58;
            this.lb_dni_cliente.Text = "DNI:";
            // 
            // lb_nombreCliente
            // 
            this.lb_nombreCliente.AutoSize = true;
            this.lb_nombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombreCliente.Location = new System.Drawing.Point(6, 16);
            this.lb_nombreCliente.Name = "lb_nombreCliente";
            this.lb_nombreCliente.Size = new System.Drawing.Size(77, 20);
            this.lb_nombreCliente.TabIndex = 56;
            this.lb_nombreCliente.Text = "Nombres:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_nombreEmpleado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridView_servicios);
            this.panel1.Controls.Add(this.txb_Observaciones);
            this.panel1.Controls.Add(this.txb_Recomendaciones);
            this.panel1.Controls.Add(this.dataGridView_Accesorios);
            this.panel1.Location = new System.Drawing.Point(21, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 525);
            this.panel1.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "SERVICIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 20);
            this.label5.TabIndex = 54;
            this.label5.Text = "RECOMENDACIONES FINALES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "OBSERVACIONES INICIALES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(785, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "ACCESORIOS";
            // 
            // dataGridView_servicios
            // 
            this.dataGridView_servicios.AllowUserToAddRows = false;
            this.dataGridView_servicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_servicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_servicios.Location = new System.Drawing.Point(46, 172);
            this.dataGridView_servicios.Name = "dataGridView_servicios";
            this.dataGridView_servicios.RowHeadersVisible = false;
            this.dataGridView_servicios.Size = new System.Drawing.Size(733, 171);
            this.dataGridView_servicios.TabIndex = 50;
            this.dataGridView_servicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_servicios_CellDoubleClick);
            // 
            // txb_Observaciones
            // 
            this.txb_Observaciones.Location = new System.Drawing.Point(44, 369);
            this.txb_Observaciones.Multiline = true;
            this.txb_Observaciones.Name = "txb_Observaciones";
            this.txb_Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_Observaciones.Size = new System.Drawing.Size(354, 148);
            this.txb_Observaciones.TabIndex = 49;
            // 
            // txb_Recomendaciones
            // 
            this.txb_Recomendaciones.Location = new System.Drawing.Point(425, 369);
            this.txb_Recomendaciones.Multiline = true;
            this.txb_Recomendaciones.Name = "txb_Recomendaciones";
            this.txb_Recomendaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_Recomendaciones.Size = new System.Drawing.Size(354, 148);
            this.txb_Recomendaciones.TabIndex = 41;
            // 
            // dataGridView_Accesorios
            // 
            this.dataGridView_Accesorios.AllowUserToAddRows = false;
            this.dataGridView_Accesorios.AllowUserToDeleteRows = false;
            this.dataGridView_Accesorios.AllowUserToResizeColumns = false;
            this.dataGridView_Accesorios.AllowUserToResizeRows = false;
            this.dataGridView_Accesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Accesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Accesorios.Location = new System.Drawing.Point(785, 264);
            this.dataGridView_Accesorios.Name = "dataGridView_Accesorios";
            this.dataGridView_Accesorios.RowHeadersVisible = false;
            this.dataGridView_Accesorios.Size = new System.Drawing.Size(303, 253);
            this.dataGridView_Accesorios.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(418, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(317, 31);
            this.label7.TabIndex = 48;
            this.label7.Text = "HISTORIAL DE EQUIPO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_estadoEquipo);
            this.groupBox1.Controls.Add(this.lb_marca);
            this.groupBox1.Controls.Add(this.lb_modelo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lb_serie);
            this.groupBox1.Controls.Add(this.lb_categoria_equipo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(569, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 130);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Equipo";
            // 
            // lb_serie
            // 
            this.lb_serie.AutoSize = true;
            this.lb_serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_serie.Location = new System.Drawing.Point(82, 57);
            this.lb_serie.Name = "lb_serie";
            this.lb_serie.Size = new System.Drawing.Size(46, 20);
            this.lb_serie.TabIndex = 61;
            this.lb_serie.Text = "Serie";
            // 
            // lb_categoria_equipo
            // 
            this.lb_categoria_equipo.AutoSize = true;
            this.lb_categoria_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_categoria_equipo.Location = new System.Drawing.Point(111, 16);
            this.lb_categoria_equipo.Name = "lb_categoria_equipo";
            this.lb_categoria_equipo.Size = new System.Drawing.Size(65, 20);
            this.lb_categoria_equipo.TabIndex = 60;
            this.lb_categoria_equipo.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(295, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 56;
            this.label11.Text = "Serie:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 62;
            this.label12.Text = "Teléfono:";
            // 
            // lb_telefono
            // 
            this.lb_telefono.AutoSize = true;
            this.lb_telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_telefono.Location = new System.Drawing.Point(115, 98);
            this.lb_telefono.Name = "lb_telefono";
            this.lb_telefono.Size = new System.Drawing.Size(65, 20);
            this.lb_telefono.TabIndex = 63;
            this.lb_telefono.Text = "Número";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 62;
            this.label14.Text = "Modelo:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(295, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 20);
            this.label15.TabIndex = 63;
            this.label15.Text = "Marca:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 64;
            this.label16.Text = "Instrumento:";
            // 
            // lb_modelo
            // 
            this.lb_modelo.AutoSize = true;
            this.lb_modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_modelo.Location = new System.Drawing.Point(82, 98);
            this.lb_modelo.Name = "lb_modelo";
            this.lb_modelo.Size = new System.Drawing.Size(61, 20);
            this.lb_modelo.TabIndex = 65;
            this.lb_modelo.Text = "Modelo";
            // 
            // lb_marca
            // 
            this.lb_marca.AutoSize = true;
            this.lb_marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_marca.Location = new System.Drawing.Point(371, 57);
            this.lb_marca.Name = "lb_marca";
            this.lb_marca.Size = new System.Drawing.Size(53, 20);
            this.lb_marca.TabIndex = 66;
            this.lb_marca.Text = "Marca";
            // 
            // lb_estadoEquipo
            // 
            this.lb_estadoEquipo.AutoSize = true;
            this.lb_estadoEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_estadoEquipo.Location = new System.Drawing.Point(371, 98);
            this.lb_estadoEquipo.Name = "lb_estadoEquipo";
            this.lb_estadoEquipo.Size = new System.Drawing.Size(60, 20);
            this.lb_estadoEquipo.TabIndex = 67;
            this.lb_estadoEquipo.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(785, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "ATENDIDO POR";
            // 
            // lb_nombreEmpleado
            // 
            this.lb_nombreEmpleado.AutoSize = true;
            this.lb_nombreEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombreEmpleado.Location = new System.Drawing.Point(803, 203);
            this.lb_nombreEmpleado.Name = "lb_nombreEmpleado";
            this.lb_nombreEmpleado.Size = new System.Drawing.Size(65, 20);
            this.lb_nombreEmpleado.TabIndex = 69;
            this.lb_nombreEmpleado.Text = "Nombre";
            // 
            // txb_serie_equipo
            // 
            this.txb_serie_equipo.Location = new System.Drawing.Point(21, 68);
            this.txb_serie_equipo.Name = "txb_serie_equipo";
            this.txb_serie_equipo.Size = new System.Drawing.Size(302, 20);
            this.txb_serie_equipo.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "SERIE DE QUIPO";
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_buscar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_buscar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_buscar.BorderRadius = 0;
            this.btn_buscar.BorderSize = 0;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.White;
            this.btn_buscar.Location = new System.Drawing.Point(329, 56);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(126, 40);
            this.btn_buscar.TabIndex = 51;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.TextColor = System.Drawing.Color.White;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLimpiar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLimpiar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLimpiar.BorderRadius = 0;
            this.btnLimpiar.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(1025, 56);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(126, 40);
            this.btnLimpiar.TabIndex = 52;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextColor = System.Drawing.Color.White;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // preHistorialEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 642);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_serie_equipo);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preHistorialEquipo";
            this.Text = "preHistorialEquipo";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_servicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RecursosAdicionales.BotonesModernos.BTNModernos btn_buscar;
        private RecursosAdicionales.BotonesModernos.BTNModernos btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_dni_ruc;
        private System.Windows.Forms.Label lb_nombre_razonSocial;
        private System.Windows.Forms.Label lb_dni_cliente;
        private System.Windows.Forms.Label lb_nombreCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_servicios;
        private System.Windows.Forms.TextBox txb_Observaciones;
        private System.Windows.Forms.TextBox txb_Recomendaciones;
        private System.Windows.Forms.DataGridView dataGridView_Accesorios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_serie;
        private System.Windows.Forms.Label lb_categoria_equipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_telefono;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lb_estadoEquipo;
        private System.Windows.Forms.Label lb_marca;
        private System.Windows.Forms.Label lb_modelo;
        private System.Windows.Forms.Label lb_nombreEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_serie_equipo;
        private System.Windows.Forms.Label label3;
    }
}