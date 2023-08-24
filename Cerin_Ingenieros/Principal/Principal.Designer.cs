namespace Cerin_Ingenieros
{
    partial class Principal
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
            this.panelOpPrincipal = new System.Windows.Forms.Panel();
            this.btn_marca = new System.Windows.Forms.Button();
            this.btn_empleado = new System.Windows.Forms.Button();
            this.btn_equipo = new System.Windows.Forms.Button();
            this.btn_mantenimiento = new System.Windows.Forms.Button();
            this.btn_alquiler = new System.Windows.Forms.Button();
            this.panel_principal = new System.Windows.Forms.Panel();
            this.panelOpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOpPrincipal
            // 
            this.panelOpPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.panelOpPrincipal.Controls.Add(this.btn_marca);
            this.panelOpPrincipal.Controls.Add(this.btn_empleado);
            this.panelOpPrincipal.Controls.Add(this.btn_equipo);
            this.panelOpPrincipal.Controls.Add(this.btn_mantenimiento);
            this.panelOpPrincipal.Controls.Add(this.btn_alquiler);
            this.panelOpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelOpPrincipal.Name = "panelOpPrincipal";
            this.panelOpPrincipal.Size = new System.Drawing.Size(150, 584);
            this.panelOpPrincipal.TabIndex = 0;
            // 
            // btn_marca
            // 
            this.btn_marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_marca.Location = new System.Drawing.Point(0, 245);
            this.btn_marca.Name = "btn_marca";
            this.btn_marca.Size = new System.Drawing.Size(150, 50);
            this.btn_marca.TabIndex = 4;
            this.btn_marca.Text = "MARCAS";
            this.btn_marca.UseVisualStyleBackColor = true;
            this.btn_marca.Click += new System.EventHandler(this.btn_marca_Click);
            // 
            // btn_empleado
            // 
            this.btn_empleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_empleado.Location = new System.Drawing.Point(0, 311);
            this.btn_empleado.Name = "btn_empleado";
            this.btn_empleado.Size = new System.Drawing.Size(150, 50);
            this.btn_empleado.TabIndex = 3;
            this.btn_empleado.Text = "EMPLEADO";
            this.btn_empleado.UseVisualStyleBackColor = true;
            this.btn_empleado.Click += new System.EventHandler(this.btn_empleado_Click);
            // 
            // btn_equipo
            // 
            this.btn_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_equipo.Location = new System.Drawing.Point(0, 180);
            this.btn_equipo.Name = "btn_equipo";
            this.btn_equipo.Size = new System.Drawing.Size(150, 50);
            this.btn_equipo.TabIndex = 2;
            this.btn_equipo.Text = "EQUIPO";
            this.btn_equipo.UseVisualStyleBackColor = true;
            this.btn_equipo.Click += new System.EventHandler(this.btn_equipo_Click);
            // 
            // btn_mantenimiento
            // 
            this.btn_mantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mantenimiento.Location = new System.Drawing.Point(0, 116);
            this.btn_mantenimiento.Name = "btn_mantenimiento";
            this.btn_mantenimiento.Size = new System.Drawing.Size(150, 50);
            this.btn_mantenimiento.TabIndex = 1;
            this.btn_mantenimiento.Text = "MANTENIMIENTO";
            this.btn_mantenimiento.UseVisualStyleBackColor = true;
            this.btn_mantenimiento.Click += new System.EventHandler(this.btn_mantenimiento_Click);
            // 
            // btn_alquiler
            // 
            this.btn_alquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alquiler.Location = new System.Drawing.Point(0, 52);
            this.btn_alquiler.Name = "btn_alquiler";
            this.btn_alquiler.Size = new System.Drawing.Size(150, 50);
            this.btn_alquiler.TabIndex = 0;
            this.btn_alquiler.Text = "ALQUILER";
            this.btn_alquiler.UseVisualStyleBackColor = true;
            this.btn_alquiler.Click += new System.EventHandler(this.btn_alquiler_Click);
            // 
            // panel_principal
            // 
            this.panel_principal.BackColor = System.Drawing.Color.Transparent;
            this.panel_principal.Location = new System.Drawing.Point(150, 0);
            this.panel_principal.Name = "panel_principal";
            this.panel_principal.Size = new System.Drawing.Size(1180, 560);
            this.panel_principal.TabIndex = 1;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 561);
            this.Controls.Add(this.panel_principal);
            this.Controls.Add(this.panelOpPrincipal);
            this.Name = "Principal";
            this.Text = "CCI CONTROL DE SERVICIOS";
            this.panelOpPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOpPrincipal;
        private System.Windows.Forms.Panel panel_principal;
        private System.Windows.Forms.Button btn_alquiler;
        private System.Windows.Forms.Button btn_empleado;
        private System.Windows.Forms.Button btn_equipo;
        private System.Windows.Forms.Button btn_mantenimiento;
        private System.Windows.Forms.Button btn_marca;
    }
}