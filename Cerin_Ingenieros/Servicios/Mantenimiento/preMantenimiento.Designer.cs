﻿namespace Cerin_Ingenieros.Servicios
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_lista_quipos = new System.Windows.Forms.DataGridView();
            this.btn_agregar_equipo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_dni_ruc = new System.Windows.Forms.Label();
            this.lb_apellidos = new System.Windows.Forms.Label();
            this.lb_telefono = new System.Windows.Forms.Label();
            this.lb_nombres = new System.Windows.Forms.Label();
            this.comboBox_cliente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_select_cliente = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista_quipos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_lista_quipos);
            this.groupBox3.Controls.Add(this.btn_agregar_equipo);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(396, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(766, 386);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Equipo";
            // 
            // dataGridView_lista_quipos
            // 
            this.dataGridView_lista_quipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_lista_quipos.Location = new System.Drawing.Point(33, 89);
            this.dataGridView_lista_quipos.Name = "dataGridView_lista_quipos";
            this.dataGridView_lista_quipos.Size = new System.Drawing.Size(717, 273);
            this.dataGridView_lista_quipos.TabIndex = 2;
            // 
            // btn_agregar_equipo
            // 
            this.btn_agregar_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar_equipo.Location = new System.Drawing.Point(33, 32);
            this.btn_agregar_equipo.Name = "btn_agregar_equipo";
            this.btn_agregar_equipo.Size = new System.Drawing.Size(201, 37);
            this.btn_agregar_equipo.TabIndex = 1;
            this.btn_agregar_equipo.Text = "Agregar equipo";
            this.btn_agregar_equipo.UseVisualStyleBackColor = true;
            this.btn_agregar_equipo.Click += new System.EventHandler(this.btn_agregar_equipo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_dni_ruc);
            this.groupBox2.Controls.Add(this.lb_apellidos);
            this.groupBox2.Controls.Add(this.lb_telefono);
            this.groupBox2.Controls.Add(this.lb_nombres);
            this.groupBox2.Controls.Add(this.comboBox_cliente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_select_cliente);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 386);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // lb_dni_ruc
            // 
            this.lb_dni_ruc.BackColor = System.Drawing.SystemColors.Control;
            this.lb_dni_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dni_ruc.Location = new System.Drawing.Point(35, 113);
            this.lb_dni_ruc.Name = "lb_dni_ruc";
            this.lb_dni_ruc.Size = new System.Drawing.Size(280, 20);
            this.lb_dni_ruc.TabIndex = 19;
            this.lb_dni_ruc.Text = "DNI / RUC";
            this.lb_dni_ruc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_apellidos
            // 
            this.lb_apellidos.BackColor = System.Drawing.SystemColors.Control;
            this.lb_apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_apellidos.Location = new System.Drawing.Point(35, 169);
            this.lb_apellidos.Name = "lb_apellidos";
            this.lb_apellidos.Size = new System.Drawing.Size(280, 20);
            this.lb_apellidos.TabIndex = 18;
            this.lb_apellidos.Text = "Apellidos";
            this.lb_apellidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_telefono
            // 
            this.lb_telefono.BackColor = System.Drawing.SystemColors.Control;
            this.lb_telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_telefono.Location = new System.Drawing.Point(35, 282);
            this.lb_telefono.Name = "lb_telefono";
            this.lb_telefono.Size = new System.Drawing.Size(280, 20);
            this.lb_telefono.TabIndex = 17;
            this.lb_telefono.Text = "Telefono";
            this.lb_telefono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_nombres
            // 
            this.lb_nombres.BackColor = System.Drawing.SystemColors.Control;
            this.lb_nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombres.Location = new System.Drawing.Point(35, 226);
            this.lb_nombres.Name = "lb_nombres";
            this.lb_nombres.Size = new System.Drawing.Size(280, 20);
            this.lb_nombres.TabIndex = 16;
            this.lb_nombres.Text = "Nombres";
            this.lb_nombres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_cliente
            // 
            this.comboBox_cliente.FormattingEnabled = true;
            this.comboBox_cliente.Items.AddRange(new object[] {
            "Trimble",
            "Riegl",
            "Pentax",
            "Geoslam",
            "DJI Enterprise",
            "Spectra Precision"});
            this.comboBox_cliente.Location = new System.Drawing.Point(117, 336);
            this.comboBox_cliente.Name = "comboBox_cliente";
            this.comboBox_cliente.Size = new System.Drawing.Size(180, 26);
            this.comboBox_cliente.TabIndex = 15;
            this.comboBox_cliente.Text = "(seleciones una opcion)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Recepcionista";
            // 
            // btn_select_cliente
            // 
            this.btn_select_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_select_cliente.Location = new System.Drawing.Point(58, 37);
            this.btn_select_cliente.Name = "btn_select_cliente";
            this.btn_select_cliente.Size = new System.Drawing.Size(201, 37);
            this.btn_select_cliente.TabIndex = 1;
            this.btn_select_cliente.Text = "Selecionar cliente";
            this.btn_select_cliente.UseVisualStyleBackColor = true;
            this.btn_select_cliente.Click += new System.EventHandler(this.btn_select_cliente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(321, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(448, 31);
            this.label7.TabIndex = 23;
            this.label7.Text = "MANTENIMIENTO DE UN EQUIPO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(936, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 62);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha y hora";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_editar);
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.btn_guardar);
            this.panel1.Controls.Add(this.btn_nuevo);
            this.panel1.Location = new System.Drawing.Point(12, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 54);
            this.panel1.TabIndex = 26;
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
            // 
            // preMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preMantenimiento";
            this.Text = "Mantenimiento";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista_quipos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_lista_quipos;
        private System.Windows.Forms.Button btn_agregar_equipo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_dni_ruc;
        private System.Windows.Forms.Label lb_apellidos;
        private System.Windows.Forms.Label lb_telefono;
        private System.Windows.Forms.Label lb_nombres;
        private System.Windows.Forms.ComboBox comboBox_cliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_select_cliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_nuevo;
    }
}