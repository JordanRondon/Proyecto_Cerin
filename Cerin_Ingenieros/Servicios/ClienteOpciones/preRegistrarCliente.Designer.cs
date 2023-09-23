namespace Cerin_Ingenieros.Servicios.ClienteOpciones
{
    partial class preRegistrarCliente
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
            this.dgvClientes2 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancelar_registro = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.groupBoxRegistrar = new System.Windows.Forms.GroupBox();
            this.txb_razonSocial_cliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_telefono_cliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_nombre_cliente = new System.Windows.Forms.TextBox();
            this.txb_ruc_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_apellidos_cliente = new System.Windows.Forms.TextBox();
            this.txb_dni_cliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarRuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxRegistrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientes2
            // 
            this.dgvClientes2.AllowUserToAddRows = false;
            this.dgvClientes2.AllowUserToDeleteRows = false;
            this.dgvClientes2.AllowUserToResizeColumns = false;
            this.dgvClientes2.AllowUserToResizeRows = false;
            this.dgvClientes2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes2.Location = new System.Drawing.Point(66, 305);
            this.dgvClientes2.Name = "dgvClientes2";
            this.dgvClientes2.RowHeadersVisible = false;
            this.dgvClientes2.Size = new System.Drawing.Size(1047, 232);
            this.dgvClientes2.TabIndex = 39;
            this.dgvClientes2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes2_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancelar_registro);
            this.panel1.Controls.Add(this.btn_eliminar);
            this.panel1.Controls.Add(this.btn_editar);
            this.panel1.Controls.Add(this.btn_guardar);
            this.panel1.Controls.Add(this.btn_nuevo);
            this.panel1.Location = new System.Drawing.Point(30, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 54);
            this.panel1.TabIndex = 38;
            // 
            // btn_cancelar_registro
            // 
            this.btn_cancelar_registro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar_registro.Location = new System.Drawing.Point(789, 9);
            this.btn_cancelar_registro.Name = "btn_cancelar_registro";
            this.btn_cancelar_registro.Size = new System.Drawing.Size(90, 35);
            this.btn_cancelar_registro.TabIndex = 9;
            this.btn_cancelar_registro.Text = "Cancelar";
            this.btn_cancelar_registro.UseVisualStyleBackColor = true;
            this.btn_cancelar_registro.Click += new System.EventHandler(this.btn_cancelar_registro_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Location = new System.Drawing.Point(647, 10);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(90, 35);
            this.btn_eliminar.TabIndex = 8;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(371, 39);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(90, 23);
            this.btn_buscar.TabIndex = 7;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(525, 9);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(90, 35);
            this.btn_editar.TabIndex = 3;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Location = new System.Drawing.Point(407, 9);
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
            this.btn_nuevo.Location = new System.Drawing.Point(273, 9);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(90, 35);
            this.btn_nuevo.TabIndex = 0;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // groupBoxRegistrar
            // 
            this.groupBoxRegistrar.Controls.Add(this.btnBuscarRuc);
            this.groupBoxRegistrar.Controls.Add(this.txb_razonSocial_cliente);
            this.groupBoxRegistrar.Controls.Add(this.label6);
            this.groupBoxRegistrar.Controls.Add(this.txb_nombre_cliente);
            this.groupBoxRegistrar.Controls.Add(this.label2);
            this.groupBoxRegistrar.Controls.Add(this.btn_buscar);
            this.groupBoxRegistrar.Controls.Add(this.txb_telefono_cliente);
            this.groupBoxRegistrar.Controls.Add(this.label5);
            this.groupBoxRegistrar.Controls.Add(this.txb_ruc_cliente);
            this.groupBoxRegistrar.Controls.Add(this.label4);
            this.groupBoxRegistrar.Controls.Add(this.txb_apellidos_cliente);
            this.groupBoxRegistrar.Controls.Add(this.txb_dni_cliente);
            this.groupBoxRegistrar.Controls.Add(this.label3);
            this.groupBoxRegistrar.Controls.Add(this.label1);
            this.groupBoxRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRegistrar.Location = new System.Drawing.Point(66, 43);
            this.groupBoxRegistrar.Name = "groupBoxRegistrar";
            this.groupBoxRegistrar.Size = new System.Drawing.Size(1047, 161);
            this.groupBoxRegistrar.TabIndex = 37;
            this.groupBoxRegistrar.TabStop = false;
            this.groupBoxRegistrar.Text = "DATOS CLIENTE";
            // 
            // txb_razonSocial_cliente
            // 
            this.txb_razonSocial_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_razonSocial_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_razonSocial_cliente.Location = new System.Drawing.Point(629, 83);
            this.txb_razonSocial_cliente.Name = "txb_razonSocial_cliente";
            this.txb_razonSocial_cliente.Size = new System.Drawing.Size(241, 23);
            this.txb_razonSocial_cliente.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(538, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Razon Social";
            // 
            // txb_telefono_cliente
            // 
            this.txb_telefono_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_telefono_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_telefono_cliente.Location = new System.Drawing.Point(629, 132);
            this.txb_telefono_cliente.Name = "txb_telefono_cliente";
            this.txb_telefono_cliente.Size = new System.Drawing.Size(241, 23);
            this.txb_telefono_cliente.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(539, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Telefono";
            // 
            // txb_nombre_cliente
            // 
            this.txb_nombre_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_nombre_cliente.Location = new System.Drawing.Point(115, 132);
            this.txb_nombre_cliente.Name = "txb_nombre_cliente";
            this.txb_nombre_cliente.Size = new System.Drawing.Size(241, 23);
            this.txb_nombre_cliente.TabIndex = 14;
            // 
            // txb_ruc_cliente
            // 
            this.txb_ruc_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_ruc_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_ruc_cliente.Location = new System.Drawing.Point(629, 39);
            this.txb_ruc_cliente.Name = "txb_ruc_cliente";
            this.txb_ruc_cliente.Size = new System.Drawing.Size(241, 23);
            this.txb_ruc_cliente.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombres";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "RUC";
            // 
            // txb_apellidos_cliente
            // 
            this.txb_apellidos_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_apellidos_cliente.Location = new System.Drawing.Point(114, 83);
            this.txb_apellidos_cliente.Name = "txb_apellidos_cliente";
            this.txb_apellidos_cliente.Size = new System.Drawing.Size(241, 23);
            this.txb_apellidos_cliente.TabIndex = 10;
            // 
            // txb_dni_cliente
            // 
            this.txb_dni_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_dni_cliente.Location = new System.Drawing.Point(114, 39);
            this.txb_dni_cliente.Name = "txb_dni_cliente";
            this.txb_dni_cliente.Size = new System.Drawing.Size(241, 23);
            this.txb_dni_cliente.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI";
            // 
            // btnBuscarRuc
            // 
            this.btnBuscarRuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarRuc.Location = new System.Drawing.Point(889, 39);
            this.btnBuscarRuc.Name = "btnBuscarRuc";
            this.btnBuscarRuc.Size = new System.Drawing.Size(90, 23);
            this.btnBuscarRuc.TabIndex = 19;
            this.btnBuscarRuc.Text = "Buscar";
            this.btnBuscarRuc.UseVisualStyleBackColor = true;
            this.btnBuscarRuc.Click += new System.EventHandler(this.btnBuscarRuc_Click);
            // 
            // preRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 642);
            this.Controls.Add(this.dgvClientes2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxRegistrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preRegistrarCliente";
            this.Text = "preRegistrarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxRegistrar.ResumeLayout(false);
            this.groupBoxRegistrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cancelar_registro;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.GroupBox groupBoxRegistrar;
        private System.Windows.Forms.TextBox txb_razonSocial_cliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_telefono_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_nombre_cliente;
        private System.Windows.Forms.TextBox txb_ruc_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_apellidos_cliente;
        private System.Windows.Forms.TextBox txb_dni_cliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarRuc;
    }
}