using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
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
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
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
            if (e.RowIndex>=0)
            {
                DataGridViewRow filaActual = dataGridView_marcas.Rows[e.RowIndex];

                txb_codigo.Text = filaActual.Cells[0].Value.ToString();
                txb_nombre.Text = filaActual.Cells[1].Value.ToString();

                habilitar_btn_modificacion();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "")
                {
                    entMarca marca = new entMarca
                    {
                        Nombre = txb_nombre.Text.Trim()
                    };
                    logMarca.GetInstancia.insertaMarca(marca);

                    //Actualizar botones
                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                    listarMarcas();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entMarca marca = new entMarca
                    {
                        IdMarca = int.Parse(txb_codigo.Text),
                        Nombre = txb_nombre.Text.Trim()
                    };
                    logMarca.GetInstancia.editarMarca(marca);

                    limpiar_entradas();
                    listarMarcas();
                    deshablitar_btn();
                    deshablitar_entradas();
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entMarca marca = new entMarca
                    {
                        IdMarca = int.Parse(txb_codigo.Text)
                    };
                    logMarca.GetInstancia.deshabilitarMarca(marca);

                    limpiar_entradas();
                    listarMarcas();
                    deshablitar_btn();
                    deshablitar_entradas();
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
