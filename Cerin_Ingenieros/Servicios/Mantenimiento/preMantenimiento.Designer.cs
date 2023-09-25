namespace Cerin_Ingenieros.Servicios
{
    partial class preMantenimiento
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_cancelarObservacion = new System.Windows.Forms.Button();
            this.btn_agregarRecomendacion = new System.Windows.Forms.Button();
            this.grb_observacionesFinales = new System.Windows.Forms.GroupBox();
            this.txb_Recomendaciones = new System.Windows.Forms.TextBox();
            this.dataGridView_Accesorios = new System.Windows.Forms.DataGridView();
            this.btn_agregar_equipo = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.dataGridView_lista_quipos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txb_razon_social = new System.Windows.Forms.TextBox();
            this.txb_ruc = new System.Windows.Forms.TextBox();
            this.btn_slect_cliente = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.lb_apellidos_cliente = new System.Windows.Forms.Label();
            this.lb_telefono_cliente = new System.Windows.Forms.Label();
            this.lb_nombres_cliente = new System.Windows.Forms.Label();
            this.comboBox_empleado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbHora = new System.Windows.Forms.Label();
            this.horaFecha = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_dni_ruc_cliente = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.grb_observacionesFinales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista_quipos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_Delete);
            this.groupBox3.Controls.Add(this.btn_cancelarObservacion);
            this.groupBox3.Controls.Add(this.btn_agregarRecomendacion);
            this.groupBox3.Controls.Add(this.grb_observacionesFinales);
            this.groupBox3.Controls.Add(this.dataGridView_Accesorios);
            this.groupBox3.Controls.Add(this.btn_agregar_equipo);
            this.groupBox3.Controls.Add(this.dataGridView_lista_quipos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(404, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 535);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Equipo";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(33, 492);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(153, 35);
            this.btn_Delete.TabIndex = 50;
            this.btn_Delete.Text = "Eliminar equipo";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_cancelarObservacion
            // 
            this.btn_cancelarObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cancelarObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelarObservacion.Location = new System.Drawing.Point(655, 489);
            this.btn_cancelarObservacion.Name = "btn_cancelarObservacion";
            this.btn_cancelarObservacion.Size = new System.Drawing.Size(95, 35);
            this.btn_cancelarObservacion.TabIndex = 47;
            this.btn_cancelarObservacion.Text = "Cancelar";
            this.btn_cancelarObservacion.UseVisualStyleBackColor = true;
            this.btn_cancelarObservacion.Click += new System.EventHandler(this.btn_cancelarObservacion_Click);
            // 
            // btn_agregarRecomendacion
            // 
            this.btn_agregarRecomendacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_agregarRecomendacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregarRecomendacion.Location = new System.Drawing.Point(345, 491);
            this.btn_agregarRecomendacion.Name = "btn_agregarRecomendacion";
            this.btn_agregarRecomendacion.Size = new System.Drawing.Size(200, 35);
            this.btn_agregarRecomendacion.TabIndex = 46;
            this.btn_agregarRecomendacion.Text = "Actualizar observaciones";
            this.btn_agregarRecomendacion.UseVisualStyleBackColor = true;
            this.btn_agregarRecomendacion.Click += new System.EventHandler(this.btn_agregarRecomendacion_Click);
            // 
            // grb_observacionesFinales
            // 
            this.grb_observacionesFinales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_observacionesFinales.Controls.Add(this.txb_Recomendaciones);
            this.grb_observacionesFinales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_observacionesFinales.Location = new System.Drawing.Point(399, 327);
            this.grb_observacionesFinales.Name = "grb_observacionesFinales";
            this.grb_observacionesFinales.Size = new System.Drawing.Size(351, 151);
            this.grb_observacionesFinales.TabIndex = 49;
            this.grb_observacionesFinales.TabStop = false;
            this.grb_observacionesFinales.Text = "Observaciones preliminares";
            // 
            // txb_Recomendaciones
            // 
            this.txb_Recomendaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_Recomendaciones.Location = new System.Drawing.Point(12, 24);
            this.txb_Recomendaciones.Multiline = true;
            this.txb_Recomendaciones.Name = "txb_Recomendaciones";
            this.txb_Recomendaciones.Size = new System.Drawing.Size(321, 109);
            this.txb_Recomendaciones.TabIndex = 41;
            // 
            // dataGridView_Accesorios
            // 
            this.dataGridView_Accesorios.AllowUserToAddRows = false;
            this.dataGridView_Accesorios.AllowUserToDeleteRows = false;
            this.dataGridView_Accesorios.AllowUserToResizeColumns = false;
            this.dataGridView_Accesorios.AllowUserToResizeRows = false;
            this.dataGridView_Accesorios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Accesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Accesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Accesorios.Location = new System.Drawing.Point(33, 327);
            this.dataGridView_Accesorios.Name = "dataGridView_Accesorios";
            this.dataGridView_Accesorios.ReadOnly = true;
            this.dataGridView_Accesorios.RowHeadersVisible = false;
            this.dataGridView_Accesorios.Size = new System.Drawing.Size(360, 151);
            this.dataGridView_Accesorios.TabIndex = 48;
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
            this.btn_agregar_equipo.TabIndex = 5;
            this.btn_agregar_equipo.Text = "Agregar equipo";
            this.btn_agregar_equipo.TextColor = System.Drawing.Color.White;
            this.btn_agregar_equipo.UseVisualStyleBackColor = false;
            this.btn_agregar_equipo.Click += new System.EventHandler(this.btn_agregar_equipo_Click);
            // 
            // dataGridView_lista_quipos
            // 
            this.dataGridView_lista_quipos.AllowUserToAddRows = false;
            this.dataGridView_lista_quipos.AllowUserToDeleteRows = false;
            this.dataGridView_lista_quipos.AllowUserToResizeColumns = false;
            this.dataGridView_lista_quipos.AllowUserToResizeRows = false;
            this.dataGridView_lista_quipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_lista_quipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_lista_quipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_lista_quipos.Location = new System.Drawing.Point(33, 89);
            this.dataGridView_lista_quipos.Name = "dataGridView_lista_quipos";
            this.dataGridView_lista_quipos.ReadOnly = true;
            this.dataGridView_lista_quipos.RowHeadersVisible = false;
            this.dataGridView_lista_quipos.Size = new System.Drawing.Size(717, 224);
            this.dataGridView_lista_quipos.TabIndex = 2;
            this.dataGridView_lista_quipos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_lista_quipos_CellContentDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.txb_razon_social);
            this.groupBox2.Controls.Add(this.txb_ruc);
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
            this.groupBox2.Size = new System.Drawing.Size(347, 535);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // txb_razon_social
            // 
            this.txb_razon_social.Location = new System.Drawing.Point(39, 391);
            this.txb_razon_social.Name = "txb_razon_social";
            this.txb_razon_social.Size = new System.Drawing.Size(276, 24);
            this.txb_razon_social.TabIndex = 29;
            this.txb_razon_social.Tag = "Razon social";
            this.txb_razon_social.Text = "Razon social";
            this.txb_razon_social.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_ruc
            // 
            this.txb_ruc.Location = new System.Drawing.Point(39, 334);
            this.txb_ruc.Name = "txb_ruc";
            this.txb_ruc.Size = new System.Drawing.Size(276, 24);
            this.txb_ruc.TabIndex = 28;
            this.txb_ruc.Tag = "RUC";
            this.txb_ruc.Text = "RUC";
            this.txb_ruc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btn_slect_cliente.TabIndex = 27;
            this.btn_slect_cliente.Text = "Selecionar cliente";
            this.btn_slect_cliente.TextColor = System.Drawing.Color.White;
            this.btn_slect_cliente.UseVisualStyleBackColor = false;
            this.btn_slect_cliente.Click += new System.EventHandler(this.btn_slect_cliente_Click);
            // 
            // lb_apellidos_cliente
            // 
            this.lb_apellidos_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_apellidos_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_apellidos_cliente.Location = new System.Drawing.Point(35, 167);
            this.lb_apellidos_cliente.Name = "lb_apellidos_cliente";
            this.lb_apellidos_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_apellidos_cliente.TabIndex = 25;
            this.lb_apellidos_cliente.Text = "Apellidos";
            this.lb_apellidos_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_telefono_cliente
            // 
            this.lb_telefono_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_telefono_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_telefono_cliente.Location = new System.Drawing.Point(35, 283);
            this.lb_telefono_cliente.Name = "lb_telefono_cliente";
            this.lb_telefono_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_telefono_cliente.TabIndex = 24;
            this.lb_telefono_cliente.Text = "Telefono";
            this.lb_telefono_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_nombres_cliente
            // 
            this.lb_nombres_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_nombres_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres_cliente.Location = new System.Drawing.Point(35, 226);
            this.lb_nombres_cliente.Name = "lb_nombres_cliente";
            this.lb_nombres_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_nombres_cliente.TabIndex = 23;
            this.lb_nombres_cliente.Text = "Nombres";
            this.lb_nombres_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_empleado
            // 
            this.comboBox_empleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_empleado.FormattingEnabled = true;
            this.comboBox_empleado.Location = new System.Drawing.Point(39, 471);
            this.comboBox_empleado.Name = "comboBox_empleado";
            this.comboBox_empleado.Size = new System.Drawing.Size(276, 26);
            this.comboBox_empleado.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(117, 450);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Recepcionista";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Location = new System.Drawing.Point(849, 570);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(150, 50);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Location = new System.Drawing.Point(501, 570);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(150, 50);
            this.btn_guardar.TabIndex = 1;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevo.Location = new System.Drawing.Point(159, 570);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(150, 50);
            this.btn_nuevo.TabIndex = 0;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.Gray;
            this.lbFecha.Location = new System.Drawing.Point(770, 47);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(401, 29);
            this.lbFecha.TabIndex = 28;
            this.lbFecha.Text = "martes, 29 de agosto del 2023";
            this.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbHora
            // 
            this.lbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHora.AutoSize = true;
            this.lbHora.BackColor = System.Drawing.Color.Transparent;
            this.lbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHora.Location = new System.Drawing.Point(1020, 8);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(149, 39);
            this.lbHora.TabIndex = 27;
            this.lbHora.Text = "12:12:12";
            // 
            // horaFecha
            // 
            this.horaFecha.Enabled = true;
            this.horaFecha.Tick += new System.EventHandler(this.horaFecha_Tick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(548, 54);
            this.label7.TabIndex = 29;
            this.label7.Text = "EQUIPOS A LABORATORIO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbHora);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 79);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.btn_nuevo);
            this.panel2.Controls.Add(this.btn_guardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 641);
            this.panel2.TabIndex = 31;
            // 
            // lb_dni_ruc_cliente
            // 
            this.lb_dni_ruc_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.lb_dni_ruc_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dni_ruc_cliente.Location = new System.Drawing.Point(35, 109);
            this.lb_dni_ruc_cliente.Name = "lb_dni_ruc_cliente";
            this.lb_dni_ruc_cliente.Size = new System.Drawing.Size(280, 20);
            this.lb_dni_ruc_cliente.TabIndex = 26;
            this.lb_dni_ruc_cliente.Text = "DNI";
            this.lb_dni_ruc_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // preMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preMantenimiento";
            this.Text = "Mantenimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.preMantenimiento_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.grb_observacionesFinales.ResumeLayout(false);
            this.grb_observacionesFinales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista_quipos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_lista_quipos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Timer horaFecha;
        private RecursosAdicionales.BotonesModernos.BTNModernos btn_slect_cliente;
        private System.Windows.Forms.Label lb_dni_ruc_cliente;
        private System.Windows.Forms.Label lb_apellidos_cliente;
        private System.Windows.Forms.Label lb_telefono_cliente;
        private System.Windows.Forms.Label lb_nombres_cliente;
        private System.Windows.Forms.ComboBox comboBox_empleado;
        private System.Windows.Forms.Label label8;
        private RecursosAdicionales.BotonesModernos.BTNModernos btn_agregar_equipo;
        private System.Windows.Forms.TextBox txb_razon_social;
        private System.Windows.Forms.TextBox txb_ruc;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_cancelarObservacion;
        private System.Windows.Forms.Button btn_agregarRecomendacion;
        private System.Windows.Forms.GroupBox grb_observacionesFinales;
        private System.Windows.Forms.TextBox txb_Recomendaciones;
        private System.Windows.Forms.DataGridView dataGridView_Accesorios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}