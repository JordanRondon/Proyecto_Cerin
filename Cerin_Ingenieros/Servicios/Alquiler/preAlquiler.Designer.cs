namespace Cerin_Ingenieros.Servicios
{
    partial class preAlquiler
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
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_dni_ruc_cliente = new System.Windows.Forms.Label();
            this.lb_apellidos_cliente = new System.Windows.Forms.Label();
            this.lb_telefono_cliente = new System.Windows.Forms.Label();
            this.lb_nombres_cliente = new System.Windows.Forms.Label();
            this.comboBox_empleado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_list_equipos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.horaFecha = new System.Windows.Forms.Timer(this.components);
            this.lbHora = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_slect_cliente = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.btn_agregar_equipo = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_list_equipos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(210, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(519, 46);
            this.label7.TabIndex = 6;
            this.label7.Text = "ALQUILER DE UN EQUIPO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_slect_cliente);
            this.groupBox2.Controls.Add(this.lb_dni_ruc_cliente);
            this.groupBox2.Controls.Add(this.lb_apellidos_cliente);
            this.groupBox2.Controls.Add(this.lb_telefono_cliente);
            this.groupBox2.Controls.Add(this.lb_nombres_cliente);
            this.groupBox2.Controls.Add(this.comboBox_empleado);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(25, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 427);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // lb_dni_ruc_cliente
            // 
            this.lb_dni_ruc_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_dni_ruc_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dni_ruc_cliente.Location = new System.Drawing.Point(35, 122);
            this.lb_dni_ruc_cliente.Name = "lb_dni_ruc_cliente";
            this.lb_dni_ruc_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_dni_ruc_cliente.TabIndex = 19;
            this.lb_dni_ruc_cliente.Text = "DNI / RUC";
            this.lb_dni_ruc_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_apellidos_cliente
            // 
            this.lb_apellidos_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_apellidos_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_apellidos_cliente.Location = new System.Drawing.Point(35, 178);
            this.lb_apellidos_cliente.Name = "lb_apellidos_cliente";
            this.lb_apellidos_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_apellidos_cliente.TabIndex = 18;
            this.lb_apellidos_cliente.Text = "Apellidos";
            this.lb_apellidos_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_telefono_cliente
            // 
            this.lb_telefono_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_telefono_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_telefono_cliente.Location = new System.Drawing.Point(35, 295);
            this.lb_telefono_cliente.Name = "lb_telefono_cliente";
            this.lb_telefono_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_telefono_cliente.TabIndex = 17;
            this.lb_telefono_cliente.Text = "Telefono";
            this.lb_telefono_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_nombres_cliente
            // 
            this.lb_nombres_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_nombres_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres_cliente.Location = new System.Drawing.Point(35, 238);
            this.lb_nombres_cliente.Name = "lb_nombres_cliente";
            this.lb_nombres_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_nombres_cliente.TabIndex = 16;
            this.lb_nombres_cliente.Text = "Nombres";
            this.lb_nombres_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_empleado
            // 
            this.comboBox_empleado.FormattingEnabled = true;
            this.comboBox_empleado.Items.AddRange(new object[] {
            "Trimble",
            "Riegl",
            "Pentax",
            "Geoslam",
            "DJI Enterprise",
            "Spectra Precision"});
            this.comboBox_empleado.Location = new System.Drawing.Point(117, 363);
            this.comboBox_empleado.Name = "comboBox_empleado";
            this.comboBox_empleado.Size = new System.Drawing.Size(180, 26);
            this.comboBox_empleado.TabIndex = 15;
            this.comboBox_empleado.Text = "(seleciones una opcion)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Recepcionista";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_agregar_equipo);
            this.groupBox3.Controls.Add(this.dataGridView_list_equipos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(404, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(766, 427);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Equipo";
            // 
            // dataGridView_list_equipos
            // 
            this.dataGridView_list_equipos.AllowUserToAddRows = false;
            this.dataGridView_list_equipos.AllowUserToDeleteRows = false;
            this.dataGridView_list_equipos.AllowUserToResizeColumns = false;
            this.dataGridView_list_equipos.AllowUserToResizeRows = false;
            this.dataGridView_list_equipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_list_equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_list_equipos.Location = new System.Drawing.Point(33, 89);
            this.dataGridView_list_equipos.Name = "dataGridView_list_equipos";
            this.dataGridView_list_equipos.ReadOnly = true;
            this.dataGridView_list_equipos.RowHeadersVisible = false;
            this.dataGridView_list_equipos.Size = new System.Drawing.Size(717, 310);
            this.dataGridView_list_equipos.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_editar);
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.btn_guardar);
            this.panel1.Controls.Add(this.btn_nuevo);
            this.panel1.Location = new System.Drawing.Point(0, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 55);
            this.panel1.TabIndex = 22;
            // 
            // btn_editar
            // 
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(495, 10);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(90, 35);
            this.btn_editar.TabIndex = 3;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Location = new System.Drawing.Point(749, 9);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(90, 35);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Location = new System.Drawing.Point(618, 9);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(90, 35);
            this.btn_guardar.TabIndex = 1;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevo.Location = new System.Drawing.Point(355, 9);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(90, 35);
            this.btn_nuevo.TabIndex = 0;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // horaFecha
            // 
            this.horaFecha.Enabled = true;
            this.horaFecha.Tick += new System.EventHandler(this.horaFecha_Tick);
            // 
            // lbHora
            // 
            this.lbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHora.AutoSize = true;
            this.lbHora.BackColor = System.Drawing.Color.Transparent;
            this.lbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHora.Location = new System.Drawing.Point(1019, 19);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(149, 39);
            this.lbHora.TabIndex = 0;
            this.lbHora.Text = "12:12:12";
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.Gray;
            this.lbFecha.Location = new System.Drawing.Point(769, 58);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(401, 29);
            this.lbFecha.TabIndex = 1;
            this.lbFecha.Text = "martes, 29 de agosto del 2023";
            this.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lbFecha);
            this.panel2.Controls.Add(this.lbHora);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 642);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(0, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1180, 540);
            this.panel3.TabIndex = 23;
            // 
            // btn_slect_cliente
            // 
            this.btn_slect_cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_slect_cliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_slect_cliente.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_slect_cliente.BorderRadius = 0;
            this.btn_slect_cliente.BorderSize = 0;
            this.btn_slect_cliente.FlatAppearance.BorderSize = 0;
            this.btn_slect_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_slect_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_slect_cliente.ForeColor = System.Drawing.Color.White;
            this.btn_slect_cliente.Location = new System.Drawing.Point(81, 34);
            this.btn_slect_cliente.Name = "btn_slect_cliente";
            this.btn_slect_cliente.Size = new System.Drawing.Size(200, 40);
            this.btn_slect_cliente.TabIndex = 20;
            this.btn_slect_cliente.Text = "Selecionar cliente";
            this.btn_slect_cliente.TextColor = System.Drawing.Color.White;
            this.btn_slect_cliente.UseVisualStyleBackColor = false;
            this.btn_slect_cliente.Click += new System.EventHandler(this.btn_slect_cliente_Click);
            // 
            // btn_agregar_equipo
            // 
            this.btn_agregar_equipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_agregar_equipo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_agregar_equipo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_agregar_equipo.BorderRadius = 0;
            this.btn_agregar_equipo.BorderSize = 0;
            this.btn_agregar_equipo.FlatAppearance.BorderSize = 0;
            this.btn_agregar_equipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar_equipo.ForeColor = System.Drawing.Color.White;
            this.btn_agregar_equipo.Location = new System.Drawing.Point(33, 34);
            this.btn_agregar_equipo.Name = "btn_agregar_equipo";
            this.btn_agregar_equipo.Size = new System.Drawing.Size(200, 40);
            this.btn_agregar_equipo.TabIndex = 4;
            this.btn_agregar_equipo.Text = "Agregar equipo";
            this.btn_agregar_equipo.TextColor = System.Drawing.Color.White;
            this.btn_agregar_equipo.UseVisualStyleBackColor = false;
            this.btn_agregar_equipo.Click += new System.EventHandler(this.btn_agregar_equipo_Click);
            // 
            // preAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 642);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preAlquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "preAlquiler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.preAlquiler_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_list_equipos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_dni_ruc_cliente;
        private System.Windows.Forms.Label lb_apellidos_cliente;
        private System.Windows.Forms.Label lb_telefono_cliente;
        private System.Windows.Forms.Label lb_nombres_cliente;
        private System.Windows.Forms.ComboBox comboBox_empleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_list_equipos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Timer horaFecha;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Label lbFecha;
        private RecursosAdicionales.BotonesModernos.BTNModernos btn_agregar_equipo;
        private RecursosAdicionales.BotonesModernos.BTNModernos btn_slect_cliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}