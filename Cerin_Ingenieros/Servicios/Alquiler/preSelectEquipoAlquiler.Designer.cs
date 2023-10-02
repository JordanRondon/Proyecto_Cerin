namespace Cerin_Ingenieros.Servicios.Alquiler
{
    partial class preSelectEquipoAlquiler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_marca = new System.Windows.Forms.RadioButton();
            this.rb_modelo = new System.Windows.Forms.RadioButton();
            this.rb_serie = new System.Windows.Forms.RadioButton();
            this.txb_buscar = new System.Windows.Forms.TextBox();
            this.btn_agregar_equipo = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_equipos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_equipos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_marca);
            this.groupBox1.Controls.Add(this.rb_modelo);
            this.groupBox1.Controls.Add(this.rb_serie);
            this.groupBox1.Controls.Add(this.txb_buscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 113);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Equipo";
            // 
            // rb_marca
            // 
            this.rb_marca.AutoSize = true;
            this.rb_marca.Location = new System.Drawing.Point(252, 78);
            this.rb_marca.Name = "rb_marca";
            this.rb_marca.Size = new System.Drawing.Size(71, 24);
            this.rb_marca.TabIndex = 3;
            this.rb_marca.TabStop = true;
            this.rb_marca.Text = "Marca";
            this.rb_marca.UseVisualStyleBackColor = true;
            // 
            // rb_modelo
            // 
            this.rb_modelo.AutoSize = true;
            this.rb_modelo.Location = new System.Drawing.Point(138, 78);
            this.rb_modelo.Name = "rb_modelo";
            this.rb_modelo.Size = new System.Drawing.Size(79, 24);
            this.rb_modelo.TabIndex = 2;
            this.rb_modelo.TabStop = true;
            this.rb_modelo.Text = "Modelo";
            this.rb_modelo.UseVisualStyleBackColor = true;
            // 
            // rb_serie
            // 
            this.rb_serie.AutoSize = true;
            this.rb_serie.Checked = true;
            this.rb_serie.Location = new System.Drawing.Point(22, 78);
            this.rb_serie.Name = "rb_serie";
            this.rb_serie.Size = new System.Drawing.Size(64, 24);
            this.rb_serie.TabIndex = 1;
            this.rb_serie.TabStop = true;
            this.rb_serie.Text = "Serie";
            this.rb_serie.UseVisualStyleBackColor = true;
            // 
            // txb_buscar
            // 
            this.txb_buscar.Location = new System.Drawing.Point(22, 36);
            this.txb_buscar.Name = "txb_buscar";
            this.txb_buscar.Size = new System.Drawing.Size(307, 26);
            this.txb_buscar.TabIndex = 0;
            this.txb_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txb_buscar_KeyUp);
            // 
            // btn_agregar_equipo
            // 
            this.btn_agregar_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar_equipo.Location = new System.Drawing.Point(965, 136);
            this.btn_agregar_equipo.Name = "btn_agregar_equipo";
            this.btn_agregar_equipo.Size = new System.Drawing.Size(146, 43);
            this.btn_agregar_equipo.TabIndex = 37;
            this.btn_agregar_equipo.Text = "Agregar equipo";
            this.btn_agregar_equipo.UseVisualStyleBackColor = true;
            this.btn_agregar_equipo.Click += new System.EventHandler(this.btn_agregar_equipo_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Location = new System.Drawing.Point(1016, 23);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(95, 35);
            this.btn_cancelar.TabIndex = 36;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 31);
            this.label7.TabIndex = 38;
            this.label7.Text = "Selecionar equipo";
            // 
            // dataGridView_equipos
            // 
            this.dataGridView_equipos.AllowUserToAddRows = false;
            this.dataGridView_equipos.AllowUserToDeleteRows = false;
            this.dataGridView_equipos.AllowUserToResizeColumns = false;
            this.dataGridView_equipos.AllowUserToResizeRows = false;
            this.dataGridView_equipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridView_equipos.Location = new System.Drawing.Point(20, 218);
            this.dataGridView_equipos.Name = "dataGridView_equipos";
            this.dataGridView_equipos.ReadOnly = true;
            this.dataGridView_equipos.RowHeadersVisible = false;
            this.dataGridView_equipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_equipos.Size = new System.Drawing.Size(1091, 332);
            this.dataGridView_equipos.TabIndex = 39;
            // 
            // preSelectEquipoAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1130, 562);
            this.Controls.Add(this.dataGridView_equipos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_agregar_equipo);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preSelectEquipoAlquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "preSelectEquipoAlquiler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_equipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_marca;
        private System.Windows.Forms.RadioButton rb_modelo;
        private System.Windows.Forms.RadioButton rb_serie;
        private System.Windows.Forms.TextBox txb_buscar;
        private System.Windows.Forms.Button btn_agregar_equipo;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_equipos;
    }
}