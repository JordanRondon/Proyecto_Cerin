using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Mantenedor
{
    public partial class preCategoria : Form
    {
        public preCategoria()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
        }

        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
        }

        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;
        }

        private void deshablitar_btn()
        {
            btn_nuevo.Enabled = true;
            btn_nuevo.BackColor = configColores.btnActivo;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = false;
            btn_editar.BackColor = configColores.btDesactivado;
            btn_eliminar.Enabled = false;
            btn_eliminar.BackColor = configColores.btDesactivado;
            btn_cancelar.Enabled = false;
            btn_cancelar.BackColor = configColores.btDesactivado;
        }

        private void habilitar_btn_modificacion()
        {
            txb_nombre.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = true;
            btn_editar.BackColor = configColores.btnActivo;
            btn_eliminar.Enabled = true;
            btn_eliminar.BackColor = configColores.btnActivo;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txb_nombre.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = true;
            btn_guardar.BackColor = configColores.btnActivo;
            btn_editar.Enabled = false;
            btn_editar.BackColor = configColores.btDesactivado;
            btn_eliminar.Enabled = false;
            btn_eliminar.BackColor = configColores.btDesactivado;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }

        private void listarCategoria()
        {
            //dataGridView_categoria.DataSource = 
        }
    }
}
