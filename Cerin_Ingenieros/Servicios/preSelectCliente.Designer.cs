namespace Cerin_Ingenieros.Servicios
{
    partial class preSelectCliente
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
            this.btnSeleciionarCliente = new System.Windows.Forms.Button();
            this.btnRegistraCliente = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeleciionarCliente
            // 
            this.btnSeleciionarCliente.BackColor = System.Drawing.Color.White;
            this.btnSeleciionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleciionarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleciionarCliente.Location = new System.Drawing.Point(0, 0);
            this.btnSeleciionarCliente.Name = "btnSeleciionarCliente";
            this.btnSeleciionarCliente.Size = new System.Drawing.Size(230, 35);
            this.btnSeleciionarCliente.TabIndex = 35;
            this.btnSeleciionarCliente.Text = "SELECIONAR CLIENTE";
            this.btnSeleciionarCliente.UseVisualStyleBackColor = false;
            this.btnSeleciionarCliente.Click += new System.EventHandler(this.btnSeleciionarCliente_Click);
            // 
            // btnRegistraCliente
            // 
            this.btnRegistraCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistraCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistraCliente.Location = new System.Drawing.Point(228, 0);
            this.btnRegistraCliente.Name = "btnRegistraCliente";
            this.btnRegistraCliente.Size = new System.Drawing.Size(230, 35);
            this.btnRegistraCliente.TabIndex = 36;
            this.btnRegistraCliente.Text = "REGISTRAR CLIENTE";
            this.btnRegistraCliente.UseVisualStyleBackColor = true;
            this.btnRegistraCliente.Click += new System.EventHandler(this.btnRegistraCliente_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSeleciionarCliente);
            this.panel2.Controls.Add(this.btnRegistraCliente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 35);
            this.panel2.TabIndex = 37;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 35);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1164, 568);
            this.panelPrincipal.TabIndex = 38;
            // 
            // preSelectCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 603);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "preSelectCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "preSelectCliente";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSeleciionarCliente;
        private System.Windows.Forms.Button btnRegistraCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelPrincipal;
    }
}