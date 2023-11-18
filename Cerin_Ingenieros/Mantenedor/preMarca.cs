
// --------------------------------------------------------------
// Nombre del archivo: preMarca.cs
// Descripción: Clase que gestiona la interfaz de usuario para la
//              administración de marcas de equipos.
// --------------------------------------------------------------

using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

namespace Cerin_Ingenieros
{
    public partial class preMarca : Form
    {
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private List<entCategoria> opciones;
        public preMarca()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            listarMarcas();

            opciones = logCategoria.GetInstancia.listarCategoriasEquipos();
            MostrarChecks();
        }

        /// <summary>
        /// Muestra los controles CheckBox en el panelContenedor según
        /// las opciones de categorías disponibles.
        /// </summary>
        private void MostrarChecks()
        {
            panelContenedor.Controls.Clear();
            foreach (var opcion in opciones)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Text = opcion.Nombre;
                checkbox.Size = new System.Drawing.Size(150, 20);
                checkbox.Tag = opcion.id_categoria_equipo;
                checkbox.Name = "chk_" + opcion.id_categoria_equipo;  // Asigna un nombre único
                checkbox.Checked = false;
                panelContenedor.Controls.Add(checkbox);
            }
        }

        /// <summary>
        /// Limpia las entradas en la interfaz.
        /// </summary>
        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
        }

        /// <summary>
        /// Deshabilita las entradas en la interfaz.
        /// </summary>
        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;
            panelContenedor.Enabled = false;
        }

        /// <summary>
        /// Deshabilita los botones en la interfaz.
        /// </summary>
        private void deshablitar_btn()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, false, configColores.btDesactivado);
        }

        /// <summary>
        /// Habilita los botones de edición en la interfaz.
        /// </summary>
        private void habilitar_btn_modificacion()
        {
            txb_nombre.Enabled = true;
            panelContenedor.Enabled=true;
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
        }

        /// <summary>
        /// Evento click para el botón Nuevo.
        /// </summary>
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            panelContenedor.Enabled = true;
            txb_nombre.Enabled = true;
            MostrarChecks();
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
        }

        /// <summary>
        /// Evento click para el botón Cancelar.
        /// </summary>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
            MostrarChecks();
        }

        /// <summary>
        /// Lista las marcas en el DataGridView.
        /// </summary>
        private void listarMarcas()
        {
            dataGridView_marcas.DataSource = logMarca.GetInstancia.listarMarcas();
        }

        /// <summary>
        /// Evento CellDoubleClick para el DataGridView_marcas.
        /// </summary>
        private void dataGridView_marcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow filaActual = dataGridView_marcas.Rows[e.RowIndex];

                txb_codigo.Text = filaActual.Cells[0].Value.ToString();
                txb_nombre.Text = filaActual.Cells[1].Value.ToString();

                List<entMarcaCategoria> lista = logMarca.GetInstancia.ListaDetalleMarcaCategoria(Convert.ToInt16(txb_codigo.Text));
                MostrarChecks();
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

        /// <summary>
        /// Verifica las categorías marcadas en los CheckBox.
        /// </summary>
        /// <returns>Lista de identificadores de categorías marcadas.</returns>
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

        /// <summary>
        /// Evento click para el botón Guardar.
        /// </summary>
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
                    MostrarChecks();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento click para el botón Editar.
        /// </summary>
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
                    MostrarChecks();
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

        /// <summary>
        /// Evento click para el botón Eliminar.
        /// </summary>
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
