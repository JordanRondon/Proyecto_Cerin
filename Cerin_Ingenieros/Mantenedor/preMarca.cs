using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros
{
    public partial class preMarca : Form
    {
        public preMarca()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            listarMarcas();
            dataGridView_marcas.ReadOnly = true;
        }

        private void limpiar_entradas()
        {
            txb_codigo_marca.Text = "";
            txb_nombre_marca.Text = "";
        }

        private void deshablitar_entradas()
        {
            txb_codigo_marca.Enabled = false;
            txb_nombre_marca.Enabled = false;
        }

        private void deshablitar_btn()
        {
            btn_nuevo.Enabled = true;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = false;
        }

        private void habilitar_btn_modificacion()
        {
            txb_nombre_marca.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_cancelar.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txb_nombre_marca.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = true;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }

        private void listarMarcas()
        {
            dataGridView_marcas.DataSource = logMarca.GetInstancia.listarMarcas();
        }

        private void dataGridView_marcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dataGridView_marcas.Rows[e.RowIndex];

            txb_codigo_marca.Text = filaActual.Cells[0].Value.ToString();
            txb_nombre_marca.Text = filaActual.Cells[1].Value.ToString();
            
            habilitar_btn_modificacion();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre_marca.Text != "")
                {
                    entMarca marca = new entMarca();
                    marca.Nombre = txb_nombre_marca.Text.Trim();
                    logMarca.GetInstancia.insertaMarca(marca);

                    //Actualizar botones
                    btn_nuevo.Enabled = true;
                    btn_guardar.Enabled = false;
                    btn_eliminar.Enabled = false;
                    btn_editar.Enabled = false;
                    btn_cancelar.Enabled = false;
                    txb_nombre_marca.Enabled = false;
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarMarcas();

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo_marca.Text != "" && txb_nombre_marca.Text != "")
                {
                    entMarca marca = new entMarca();

                    marca.IdMarca = int.Parse(txb_codigo_marca.Text);
                    marca.Nombre = txb_nombre_marca.Text.Trim();

                    logMarca.GetInstancia.editarMarca(marca);
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
            limpiar_entradas();
            listarMarcas();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo_marca.Text != "" && txb_nombre_marca.Text != "")
                {
                    entMarca marca = new entMarca();

                    marca.IdMarca = int.Parse(txb_codigo_marca.Text);

                    logMarca.GetInstancia.eliminarMarca(marca);
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
            limpiar_entradas();
            listarMarcas();
            deshablitar_btn();
            deshablitar_entradas();
        }
    }
}
