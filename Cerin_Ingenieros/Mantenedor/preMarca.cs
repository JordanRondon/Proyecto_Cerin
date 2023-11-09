using CapaDato;
using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

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
            MostrarChecks();
        }

        private void MostrarChecks()
        {
            List<entCategoria> opciones = logCategoria.GetInstancia.listarCategoriasEquipos() ;

            foreach (var opcion in opciones)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Text = opcion.Nombre;
                checkbox.Size = new System.Drawing.Size(150, 20);
                checkbox.Tag = opcion.id_categoria_equipo;
                checkbox.Name = "chk_" + opcion.id_categoria_equipo;  // Asigna un nombre único
                panelContenedor.Controls.Add(checkbox);
            }
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

                List<entMarcaCategoria> lista = logMarca.GetInstancia.ListaDetalleMarcaCategoria(Convert.ToInt16(txb_codigo.Text));

                foreach (entMarcaCategoria marcaCategoria in lista)
                {
                    foreach (Control control in panelContenedor.Controls)
                    {
                        if (control is CheckBox && ((CheckBox)control).Tag.ToString() == marcaCategoria.id_categoria_equipo.ToString())
                        {
                            ((CheckBox)control).Checked = true;
                        }
                    }
                }

                habilitar_btn_modificacion();
            }
        }

        public List<int> Verificar()
        {
            List<int> idsCategoriasMarcadas = new List<int>();
            foreach (Control control in panelContenedor.Controls)
            {
                if (control is CheckBox && ((CheckBox)control).Checked)
                {
                    int idCategoria = (int)control.Tag;
                    idsCategoriasMarcadas.Add(idCategoria);
                }
            }
            return idsCategoriasMarcadas;
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
                    //REGISTRAR LA MARCA Y TAMBIEN MARCA_CATEGORIA
                    int id_marca = logMarca.GetInstancia.insertaMarca(marca);

                    List<int> idsCategoriasMarcadas = Verificar();

                    foreach(int id_categoria in idsCategoriasMarcadas)
                    {
                        logMarca.GetInstancia.InsertarMarcaCategoria(id_marca, id_categoria);
                    }

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

                    //elimino los detalles marca categoria
                    logMarca.GetInstancia.eliminarMarcaCategoria(marca.IdMarca);

                    List<int> idsCategoriasMarcadas = Verificar();
                    foreach (int id_categoria in idsCategoriasMarcadas)
                    {
                        logMarca.GetInstancia.InsertarMarcaCategoria(marca.IdMarca, id_categoria);
                    }

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
