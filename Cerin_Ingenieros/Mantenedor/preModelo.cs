
// --------------------------------------------------------------
// Nombre del archivo: preModelo.cs
// Descripción: Clase que gestiona la interfaz de usuario para el
//              mantenimiento de modelos de equipos.
// --------------------------------------------------------------

using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Mantenedor
{
    public partial class preModelo : Form
    {
        public preModelo()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarModelos();
            ComboBoxs();
        }

        /// <summary>
        /// Configura los ComboBox en la interfaz.
        /// </summary>
        private void ComboBoxs()
        {
            comboBoxCategoria.ValueMember = "id_categoria_equipo";
            comboBoxCategoria.DisplayMember = "Nombre";
            comboBoxCategoria.DataSource = logCategoria.GetInstancia.listarCategoriasEquipos();
            comboBoxCategoria.SelectedIndex = -1;

            comboBox_marca.ValueMember = "idMarca";
            comboBox_marca.DisplayMember = "Nombre";
            comboBox_marca.SelectedIndex = -1;
        }

        /// <summary>
        /// Limpia las entradas en la interfaz.
        /// </summary>
        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
            comboBox_marca.Enabled = false;
            comboBox_marca.SelectedIndex = -1;

            comboBoxCategoria.Enabled = false;
            comboBoxCategoria.SelectedIndex = -1;
        }

        /// <summary>
        /// Deshabilita las entradas en la interfaz.
        /// </summary>
        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;
        }

        /// <summary>
        /// Deshabilita los botones en la interfaz.
        /// </summary>
        private void deshablitar_btn()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, false, configColores.btDesactivado);

        }

        /// <summary>
        /// Habilita los botones para la modificación en la interfaz.
        /// </summary>
        private void habilitar_btn_modificacion()
        {
            txb_nombre.Enabled = true;
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
            comboBox_marca .Enabled = true;
            comboBoxCategoria .Enabled = true;
        }

        /// <summary>
        /// Configura el botón Nuevo en la interfaz.
        /// </summary>
        private void configBtnNuevo()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
            comboBox_marca.Enabled = true;
            comboBoxCategoria.Enabled = true;
            txb_nombre.Enabled = true;
        }

        /// <summary>
        /// Configura la cabecera de las tablas en la interfaz.
        /// </summary>
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (comboBoxCategoria.Items.Count == 0)
                MessageBox.Show("Registre una categoria");
            else
            {
                comboBoxCategoria.SelectedIndex = 0;
                if (comboBox_marca.Items.Count == 0)
                    MessageBox.Show("Registra una marca");
                else
                {
                    configBtnNuevo();
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Cancelar.
        /// </summary>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }


        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dataGridView_modelos, new string[] { "Codigo", "Nombre", "Marca", "Categoria"});
            comboBox_marca.Enabled = false;
            comboBoxCategoria.Enabled = false;
        }

        private void listarModelos()
        {
            List<entModelo> listaModelos = logModelo.GetInstancia.listarTodoModelos();

            dataGridView_modelos.Rows.Clear();

            //insertar los datos 
            foreach (var modelo in listaModelos)
            {
                dataGridView_modelos.Rows.Add(
                    modelo.id_modelo,
                    modelo.nombre,
                    modelo.IdMarca.Nombre,
                    modelo.IdCategoriaEquipo.Nombre
                );
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo
                    {
                        nombre = txb_nombre.Text.Trim()
                    };
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    entCategoria catSelec = (entCategoria)comboBoxCategoria.SelectedItem;

                    if(marcaSelec!=null && catSelec != null)
                    {
                        modelo.IdCategoriaEquipo = new entCategoria();
                        modelo.IdCategoriaEquipo.id_categoria_equipo = catSelec.id_categoria_equipo;
                        modelo.IdMarca = new entMarca();
                        modelo.IdMarca.IdMarca = marcaSelec.IdMarca;

                        logModelo.GetInstancia.insertaModelo(modelo);
                    }
                    else
                    {
                        MessageBox.Show("Se detecto un problema");
                    }

                    //Actualizar botones
                    txb_nombre.Text = "";
                    configBtnNuevo();
                    listarModelos();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void dataGridView_modelos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dataGridView_modelos.Rows[e.RowIndex];

                txb_codigo.Text = filaActual.Cells["Codigo"].Value.ToString();
                txb_nombre.Text = filaActual.Cells["Nombre"].Value.ToString();

                comboBox_marca.SelectedIndex = comboBox_marca.FindStringExact(filaActual.Cells["Marca"].Value.ToString());
                comboBoxCategoria.SelectedIndex = comboBoxCategoria.FindStringExact(filaActual.Cells["Categoria"].Value.ToString());

                habilitar_btn_modificacion();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo
                    {
                        id_modelo = int.Parse(txb_codigo.Text),
                        nombre = txb_nombre.Text.Trim(),
                        estado = 'D'
                    };
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;

                    if(marcaSelec==null  && categoria == null)
                    {
                        MessageBox.Show("Se presento un problema");
                        return;
                    }

                    modelo.IdMarca = marcaSelec;
                    modelo.IdCategoriaEquipo = categoria;
                    logModelo.GetInstancia.editarModelo(modelo);

                    limpiar_entradas();
                    listarModelos();
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
                    entModelo modelo = new entModelo
                    {
                        id_modelo = int.Parse(txb_codigo.Text),
                        nombre = txb_nombre.Text.Trim(),
                        estado = 'S'
                    };

                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;

                    if(marcaSelec == null && categoria == null)
                    {
                        MessageBox.Show("Se presento un error");
                        return;
                    }

                    modelo.IdMarca = marcaSelec;
                    modelo.IdCategoriaEquipo = categoria;
                    logModelo.GetInstancia.editarModelo(modelo);

                    limpiar_entradas();
                    listarModelos();
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

        private void comboBoxCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;

            if (categoria != null)
            {
                List<entMarca> marcas = logMarca.GetInstancia.listarMarcasPorCategoria(categoria.id_categoria_equipo);
                comboBox_marca.DataSource = marcas;
            }
        }
    }
}
