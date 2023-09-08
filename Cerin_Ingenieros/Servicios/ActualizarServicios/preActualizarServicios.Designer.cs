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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_id_Servicio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_tipo_Servicio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_Accesorios = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.dataGridView_equipos = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label_nombre_ruc_cliente = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.richTextBox_Obs_Rec = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_equipos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Buscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_id_Servicio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 51);
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
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo del servicio";
            // 
            // txb_id_Servicio
            // 
            this.txb_id_Servicio.Location = new System.Drawing.Point(22, 32);
            this.txb_id_Servicio.Name = "txb_id_Servicio";
            this.txb_id_Servicio.Size = new System.Drawing.Size(302, 26);
            this.txb_id_Servicio.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(424, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(323, 31);
            this.label7.TabIndex = 39;
            this.label7.Text = "ACTUALIZAR SERVICIO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_equipos);
            this.panel1.Controls.Add(this.label_tipo_Servicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.dataGridView_Accesorios);
            this.panel1.Location = new System.Drawing.Point(27, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 411);
            this.panel1.TabIndex = 40;
            // 
            // label_tipo_Servicio
            // 
            this.label_tipo_Servicio.AutoSize = true;
            this.label_tipo_Servicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tipo_Servicio.Location = new System.Drawing.Point(563, 13);
            this.label_tipo_Servicio.Name = "label_tipo_Servicio";
            this.label_tipo_Servicio.Size = new System.Drawing.Size(130, 20);
            this.label_tipo_Servicio.TabIndex = 45;
            this.label_tipo_Servicio.Text = "MANTENIMIETO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(399, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "TIPO DE SERVICIO:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox_Obs_Rec);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(485, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(632, 204);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OBSERVACIONES DEL EQUIPO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "OBSERVACIONES / RECOMENDACIONES PRELIMINARES";
            // 
            // dataGridView_Accesorios
            // 
            this.dataGridView_Accesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Accesorios.Location = new System.Drawing.Point(22, 199);
            this.dataGridView_Accesorios.Name = "dataGridView_Accesorios";
            this.dataGridView_Accesorios.Size = new System.Drawing.Size(426, 194);
            this.dataGridView_Accesorios.TabIndex = 41;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(918, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 62);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha y hora";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(122, 26);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(91, 23);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(91, 23);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Actualizar);
            this.panel2.Location = new System.Drawing.Point(27, 576);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 54);
            this.panel2.TabIndex = 43;
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Actualizar.Location = new System.Drawing.Point(464, 10);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(256, 35);
            this.btn_Actualizar.TabIndex = 3;
            this.btn_Actualizar.Text = "Actualizar servicio como terminado";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            // 
            // dataGridView_equipos
            // 
            this.dataGridView_equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_equipos.Location = new System.Drawing.Point(116, 36);
            this.dataGridView_equipos.Name = "dataGridView_equipos";
            this.dataGridView_equipos.Size = new System.Drawing.Size(899, 136);
            this.dataGridView_equipos.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(517, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "CLIENTE:";
            // 
            // label_nombre_ruc_cliente
            // 
            this.label_nombre_ruc_cliente.AutoSize = true;
            this.label_nombre_ruc_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombre_ruc_cliente.Location = new System.Drawing.Point(603, 121);
            this.label_nombre_ruc_cliente.Name = "label_nombre_ruc_cliente";
            this.label_nombre_ruc_cliente.Size = new System.Drawing.Size(214, 20);
            this.label_nombre_ruc_cliente.TabIndex = 48;
            this.label_nombre_ruc_cliente.Text = "NOMBRE O RAZONSOCIAL";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // richTextBox_Obs_Rec
            // 
            this.richTextBox_Obs_Rec.Location = new System.Drawing.Point(20, 57);
            this.richTextBox_Obs_Rec.Name = "richTextBox_Obs_Rec";
            this.richTextBox_Obs_Rec.Size = new System.Drawing.Size(594, 134);
            this.richTextBox_Obs_Rec.TabIndex = 40;
            this.richTextBox_Obs_Rec.Text = "";
            // 
            // preActualizarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 642);
            this.Controls.Add(this.label_nombre_ruc_cliente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preActualizarServicios";
            this.Text = "preActualizarServicios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Accesorios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_equipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_id_Servicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.DataGridView dataGridView_Accesorios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.Label label_tipo_Servicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_equipos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_nombre_ruc_cliente;
        private System.Windows.Forms.RichTextBox richTextBox_Obs_Rec;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}