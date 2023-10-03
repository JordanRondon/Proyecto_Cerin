namespace Cerin_Ingenieros.Servicios.ActualizarServicios
{
    partial class preActualizarServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_id_Servicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_equipos = new System.Windows.Forms.DataGridView();
            this.label_nombre_ruc_cliente = new System.Windows.Forms.Label();
            this.label_tipo_Servicio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grb_observacionesFinales = new System.Windows.Forms.GroupBox();
            this.btn_editarRecomendacion = new System.Windows.Forms.Button();
            this.txb_Recomendaciones = new System.Windows.Forms.TextBox();
            this.btn_agregarRecomendacion = new System.Windows.Forms.Button();
            this.dataGridView_Accesorios = new System.Windows.Forms.DataGridView();
            this.btn_FinalizarServicio = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbHora = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.fechaHora = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUbicacion = new Cerin_Ingenieros.RecursosAdicionales.BotonesModernos.BTNModernos();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_equipos)).BeginInit();
            this.grb_observacionesFinales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Buscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_id_Servicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(48, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 90);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Servicio";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Location = new System.Drawing.Point(353, 29);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(95, 35);
            this.btn_Buscar.TabIndex = 37;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo del servicio";
            // 
            // txb_id_Servicio
            // 
            this.txb_id_Servicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_id_Servicio.ForeColor = System.Drawing.Color.Red;
            this.txb_id_Servicio.Location = new System.Drawing.Point(49, 35);
            this.txb_id_Servicio.Multiline = true;
            this.txb_id_Servicio.Name = "txb_id_Servicio";
            this.txb_id_Servicio.Size = new System.Drawing.Size(260, 20);
            this.txb_id_Servicio.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(24, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "N°";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(289, 26);
            this.textBox1.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridView_equipos);
            this.panel1.Controls.Add(this.label_nombre_ruc_cliente);
            this.panel1.Controls.Add(this.label_tipo_Servicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.grb_observacionesFinales);
            this.panel1.Controls.Add(this.dataGridView_Accesorios);
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 471);
            this.panel1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "ACCESORIOS";
            // 
            // dataGridView_equipos
            // 
            this.dataGridView_equipos.AllowUserToAddRows = false;
            this.dataGridView_equipos.AllowUserToDeleteRows = false;
            this.dataGridView_equipos.AllowUserToResizeColumns = false;
            this.dataGridView_equipos.AllowUserToResizeRows = false;
            this.dataGridView_equipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_equipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_equipos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_equipos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_equipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_equipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_equipos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_equipos.EnableHeadersVisualStyles = false;
            this.dataGridView_equipos.Location = new System.Drawing.Point(48, 26);
            this.dataGridView_equipos.Name = "dataGridView_equipos";
            this.dataGridView_equipos.RowHeadersVisible = false;
            this.dataGridView_equipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_equipos.Size = new System.Drawing.Size(1107, 208);
            this.dataGridView_equipos.TabIndex = 46;
            this.dataGridView_equipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_equipos_CellClick);
            this.dataGridView_equipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_equipos_CellDoubleClick);
            // 
            // label_nombre_ruc_cliente
            // 
            this.label_nombre_ruc_cliente.AutoSize = true;
            this.label_nombre_ruc_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombre_ruc_cliente.Location = new System.Drawing.Point(130, 3);
            this.label_nombre_ruc_cliente.Name = "label_nombre_ruc_cliente";
            this.label_nombre_ruc_cliente.Size = new System.Drawing.Size(214, 20);
            this.label_nombre_ruc_cliente.TabIndex = 48;
            this.label_nombre_ruc_cliente.Text = "NOMBRE O RAZONSOCIAL";
            // 
            // label_tipo_Servicio
            // 
            this.label_tipo_Servicio.AutoSize = true;
            this.label_tipo_Servicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tipo_Servicio.Location = new System.Drawing.Point(901, 3);
            this.label_tipo_Servicio.Name = "label_tipo_Servicio";
            this.label_tipo_Servicio.Size = new System.Drawing.Size(45, 20);
            this.label_tipo_Servicio.TabIndex = 45;
            this.label_tipo_Servicio.Text = "TIPO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(737, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "TIPO DE SERVICIO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "CLIENTE:";
            // 
            // grb_observacionesFinales
            // 
            this.grb_observacionesFinales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_observacionesFinales.Controls.Add(this.btn_editarRecomendacion);
            this.grb_observacionesFinales.Controls.Add(this.txb_Recomendaciones);
            this.grb_observacionesFinales.Controls.Add(this.btn_agregarRecomendacion);
            this.grb_observacionesFinales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_observacionesFinales.Location = new System.Drawing.Point(431, 240);
            this.grb_observacionesFinales.Name = "grb_observacionesFinales";
            this.grb_observacionesFinales.Size = new System.Drawing.Size(724, 220);
            this.grb_observacionesFinales.TabIndex = 43;
            this.grb_observacionesFinales.TabStop = false;
            this.grb_observacionesFinales.Text = "OBSERVACIONES FINALES";
            // 
            // btn_editarRecomendacion
            // 
            this.btn_editarRecomendacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editarRecomendacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editarRecomendacion.Location = new System.Drawing.Point(623, 179);
            this.btn_editarRecomendacion.Name = "btn_editarRecomendacion";
            this.btn_editarRecomendacion.Size = new System.Drawing.Size(95, 35);
            this.btn_editarRecomendacion.TabIndex = 42;
            this.btn_editarRecomendacion.Text = "Editar";
            this.btn_editarRecomendacion.UseVisualStyleBackColor = true;
            this.btn_editarRecomendacion.Click += new System.EventHandler(this.btn_editarRecomendacion_Click);
            // 
            // txb_Recomendaciones
            // 
            this.txb_Recomendaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_Recomendaciones.Location = new System.Drawing.Point(25, 23);
            this.txb_Recomendaciones.Multiline = true;
            this.txb_Recomendaciones.Name = "txb_Recomendaciones";
            this.txb_Recomendaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_Recomendaciones.Size = new System.Drawing.Size(592, 191);
            this.txb_Recomendaciones.TabIndex = 41;
            // 
            // btn_agregarRecomendacion
            // 
            this.btn_agregarRecomendacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_agregarRecomendacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregarRecomendacion.Location = new System.Drawing.Point(623, 18);
            this.btn_agregarRecomendacion.Name = "btn_agregarRecomendacion";
            this.btn_agregarRecomendacion.Size = new System.Drawing.Size(95, 35);
            this.btn_agregarRecomendacion.TabIndex = 39;
            this.btn_agregarRecomendacion.Text = "Agregar";
            this.btn_agregarRecomendacion.UseVisualStyleBackColor = true;
            this.btn_agregarRecomendacion.Click += new System.EventHandler(this.btn_agregarRecomendacion_Click);
            // 
            // dataGridView_Accesorios
            // 
            this.dataGridView_Accesorios.AllowUserToAddRows = false;
            this.dataGridView_Accesorios.AllowUserToDeleteRows = false;
            this.dataGridView_Accesorios.AllowUserToResizeColumns = false;
            this.dataGridView_Accesorios.AllowUserToResizeRows = false;
            this.dataGridView_Accesorios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Accesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Accesorios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Accesorios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Accesorios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Accesorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Accesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Accesorios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Accesorios.EnableHeadersVisualStyles = false;
            this.dataGridView_Accesorios.Location = new System.Drawing.Point(48, 263);
            this.dataGridView_Accesorios.Name = "dataGridView_Accesorios";
            this.dataGridView_Accesorios.RowHeadersVisible = false;
            this.dataGridView_Accesorios.Size = new System.Drawing.Size(360, 197);
            this.dataGridView_Accesorios.TabIndex = 41;
            // 
            // btn_FinalizarServicio
            // 
            this.btn_FinalizarServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_FinalizarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FinalizarServicio.Location = new System.Drawing.Point(48, 579);
            this.btn_FinalizarServicio.Name = "btn_FinalizarServicio";
            this.btn_FinalizarServicio.Size = new System.Drawing.Size(150, 50);
            this.btn_FinalizarServicio.TabIndex = 39;
            this.btn_FinalizarServicio.Text = "Finalizar";
            this.btn_FinalizarServicio.UseVisualStyleBackColor = true;
            this.btn_FinalizarServicio.Click += new System.EventHandler(this.btn_FinalizarServicio_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(993, 579);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(150, 50);
            this.btn_Cancelar.TabIndex = 38;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbHora
            // 
            this.lbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHora.AutoSize = true;
            this.lbHora.BackColor = System.Drawing.Color.Transparent;
            this.lbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHora.Location = new System.Drawing.Point(1020, 4);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(149, 39);
            this.lbHora.TabIndex = 44;
            this.lbHora.Text = "12:12:12";
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.Gray;
            this.lbFecha.Location = new System.Drawing.Point(770, 43);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(401, 29);
            this.lbFecha.TabIndex = 45;
            this.lbFecha.Text = "martes, 29 de agosto del 2023";
            this.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fechaHora
            // 
            this.fechaHora.Enabled = true;
            this.fechaHora.Tick += new System.EventHandler(this.fechaHora_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lbFecha);
            this.panel3.Controls.Add(this.lbHora);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1180, 79);
            this.panel3.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(477, 54);
            this.label7.TabIndex = 30;
            this.label7.Text = "ACTUALIZAR SERVICIO";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnUbicacion);
            this.panel4.Controls.Add(this.txbFile);
            this.panel4.Controls.Add(this.btn_FinalizarServicio);
            this.panel4.Controls.Add(this.btn_Cancelar);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 79);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1180, 641);
            this.panel4.TabIndex = 47;
            // 
            // btnUbicacion
            // 
            this.btnUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUbicacion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUbicacion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUbicacion.BorderRadius = 0;
            this.btnUbicacion.BorderSize = 0;
            this.btnUbicacion.FlatAppearance.BorderSize = 0;
            this.btnUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbicacion.ForeColor = System.Drawing.Color.White;
            this.btnUbicacion.Location = new System.Drawing.Point(1090, 70);
            this.btnUbicacion.Name = "btnUbicacion";
            this.btnUbicacion.Size = new System.Drawing.Size(65, 20);
            this.btnUbicacion.TabIndex = 50;
            this.btnUbicacion.Text = "iii";
            this.btnUbicacion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUbicacion.TextColor = System.Drawing.Color.White;
            this.btnUbicacion.UseVisualStyleBackColor = false;
            this.btnUbicacion.Click += new System.EventHandler(this.btnUbicacion_Click);
            // 
            // txbFile
            // 
            this.txbFile.Location = new System.Drawing.Point(605, 70);
            this.txbFile.Name = "txbFile";
            this.txbFile.ReadOnly = true;
            this.txbFile.Size = new System.Drawing.Size(479, 20);
            this.txbFile.TabIndex = 41;
            this.txbFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Column1";
            this.dataGridViewImageColumn1.Image = global::Cerin_Ingenieros.Properties.Resources.descagar2;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Cerificado";
            this.dataGridViewImageColumn2.Image = global::Cerin_Ingenieros.Properties.Resources.agregar;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Visible = false;
            // 
            // preActualizarServicios
            // 
            this.AcceptButton = this.btn_Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preActualizarServicios";
            this.Text = "preActualizarServicios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_equipos)).EndInit();
            this.grb_observacionesFinales.ResumeLayout(false);
            this.grb_observacionesFinales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_id_Servicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.DataGridView dataGridView_Accesorios;
        private System.Windows.Forms.GroupBox grb_observacionesFinales;
        private System.Windows.Forms.Label label_tipo_Servicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_equipos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_nombre_ruc_cliente;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_agregarRecomendacion;
        private System.Windows.Forms.Button btn_FinalizarServicio;
        private System.Windows.Forms.TextBox txb_Recomendaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Timer fechaHora;
        private System.Windows.Forms.Button btn_editarRecomendacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private RecursosAdicionales.BotonesModernos.BTNModernos btnUbicacion;
        private System.Windows.Forms.TextBox txbFile;
    }
}