using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Windows.Forms;

namespace Cerin_Ingenieros
{
    public partial class preEquipo : Form
    {
        private string registroSeleccionado = "";
        private readonly List<entAccesorio> listaaccesorios;

        public preEquipo()
        {
            InitializeComponent();
            listaaccesorios = logAccesorio.GetInstancia.listarAccesorio();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarEquipo();
            listarDatosComboBox();
            limpiar_entradas();
        }

        private void limpiar_entradas()
        {
            txb_serie_equipo.Text = "";
            comboBox_marca.SelectedIndex = -1;
            comboBox_modelo.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            registroSeleccionado = "";
            dgvAcesorios.Rows.Clear();
        }

        private void hablitar_entradas()
        {
            txb_serie_equipo.Enabled = true;
            comboBox_marca.Enabled = true;
            comboBox_modelo.Enabled = true;
            comboBoxCategoria.Enabled = true;
        }

        private void deshablitar_entradas()
        {
            txb_serie_equipo.Enabled = false;
            comboBox_marca.Enabled = false;
            comboBox_modelo.Enabled = false;
            comboBoxCategoria.Enabled = false;
            dgvAcesorios.Enabled = false;
        }

        private void deshablitar_btn()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, false, configColores.btDesactivado);
        }

        private void habilitar_btn_modificacion()
        {
            hablitar_entradas();
            txb_serie_equipo.Enabled = false;
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
        }
        private void configNuevo()
        {
            hablitar_entradas();
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
            dgvAcesorios.Enabled = true;
            CargarAccesorios(); 
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }
        private void CargarAccesorios()
        {
            dgvAcesorios.Enabled=true;
            dgvAcesorios.Rows.Clear();
            
            foreach (var accesorio in listaaccesorios)
            {
                dgvAcesorios.Rows.Add(
                    false,
                    accesorio.Nombre,
                    ""
                );
            }

        }
        private void ConfigCabecera()
        {
            dgvAcesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre", ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true, Name = "Cantidad" }
            );
            dgvAcesorios.Columns[0].Width = 40;
            dgvAcesorios.Columns[2].Width = 60;

            dgvConfiguracion.ConfigurarColumnas(dataGridView_equipos, 
                        new string[] { "Categira equipo", "Marca", "Modelo", "Serie del equipo", "Estado" });
        }

        private void listarEquipo()
        {
            List<entEquipo> listaEquipos = logEquipo.GetInstancia.listarEquipoAlquiler();
            dataGridView_equipos.Rows.Clear();

            //insertar Equipos
            foreach (var equipo in listaEquipos)
            {
                string estado;
                entMarca marca ;
                entModelo modelo ;
                entCategoria categoria;

                (categoria, marca, modelo) = logEquipo.GetInstancia.datosCompledoDeEquipoPorId(equipo.SerieEquipo);

                switch (equipo.Estado)
                {
                    case 'D': estado = "Disponible"; break;
                    case 'U': estado = "En Uso"; break;
                    case 'O': estado = "Ocupado"; break;
                    default: estado = "Eliminado"; break;

                }
                dataGridView_equipos.Rows.Add(                    
                    categoria.Nombre,
                    marca.Nombre,
                    modelo.nombre,
                    equipo.SerieEquipo,
                    estado
                );
            }
        }

        private void listarDatosComboBox()
        {
            comboBoxCategoria.ValueMember = "id_categoria_equipo";
            comboBoxCategoria.DisplayMember = "Nombre";
            comboBoxCategoria.DataSource = logCategoria.GetInstancia.listarCategoriasEquipos();

            comboBox_marca.ValueMember = "IdMarca";
            comboBox_marca.DisplayMember = "Nombre";

            comboBox_modelo.ValueMember = "id_modelo";
            comboBox_modelo.DisplayMember = "nombre";

        }

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                //LIMPIAR EQUIPO ACESORIO
                CargarAccesorios();

                DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];

                registroSeleccionado = Convert.ToString(filaActual.Cells["Serie del equipo"].Value.ToString());
                txb_serie_equipo.Text = registroSeleccionado;

                comboBoxCategoria.SelectedIndex = comboBoxCategoria.FindStringExact(filaActual.Cells["Categira equipo"].Value.ToString());
                comboBox_marca.SelectedIndex = comboBox_marca.FindStringExact(filaActual.Cells["Marca"].Value.ToString());
                comboBox_modelo.SelectedIndex = comboBox_modelo.FindStringExact(filaActual.Cells["Modelo"].Value.ToString());

                habilitar_btn_modificacion();

                //cargar accesorios del equipo actual
                List<entEquipo_Accesorio> listAccesoriosDeX = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(registroSeleccionado);

                foreach (var item in listAccesoriosDeX)
                {
                    entAccesorio acctemp = logAccesorio.GetInstancia.BuscarAccesorioId(item.id_accesorio);
                    for (int i = 0; dgvAcesorios.Rows.Count > 0; i++)
                    {
                        string nombreaccesorio = dgvAcesorios.Rows[i].Cells[1].Value.ToString();
                        if (nombreaccesorio == acctemp.Nombre)
                        {
                            dgvAcesorios.Rows[i].Cells[0].Value = true;
                            dgvAcesorios.Rows[i].Cells[2].Value = item.cantidad;
                            dgvAcesorios.Rows[i].Cells[2].ReadOnly = false;
                            break;
                        }
                    }
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex != -1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex !=-1);

            try
            {
                if (datosIngresados == true)
                {

                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    entCategoria marcaCategoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    entEquipo equipo = new entEquipo
                    {
                        SerieEquipo = txb_serie_equipo.Text.Trim(),
                        Estado = 'D',//estado disponible
                        IdTipo = 1, //tipo de servicio alquiler
                        otrosaccesorios = "",
                        id_modelo = modeloSelec.id_modelo,
                        IdMarca = marcaSelec.IdMarca,
                        id_categoria = marcaCategoria.id_categoria_equipo
                    };

                    string seri_selecionada = logEquipo.GetInstancia.insertaEquipo(equipo);

                    //insertar los accesorios del equipo
                    entEquipo_Accesorio det_equipo_Accesorio = new entEquipo_Accesorio
                    {
                        SerieEquipo = seri_selecionada
                    };

                    for (int i = 0; i < dgvAcesorios.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvAcesorios.Rows[i];
                        if (!row.IsNewRow)
                        {
                            bool estadoacesorio = false;
                            int cantidad = 0; 
                            string name="";

                            DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];

                            if (!row.IsNewRow)
                            {
                                estadoacesorio = (bool)checkBoxCell.Value;
                                if (estadoacesorio)
                                {
                                    DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)row.Cells[2];
                                    DataGridViewTextBoxCell textBoxCellName = (DataGridViewTextBoxCell)row.Cells[1];

                                    cantidad = Convert.ToInt16(textBoxCell.Value.ToString());
                                    name = Convert.ToString(textBoxCellName.Value);
                                    det_equipo_Accesorio.id_accesorio = BuscarAccesorio(name).IdAccesorio;
                                    det_equipo_Accesorio.cantidad = cantidad;
                                    logEquipoAccesorio.GetInstancia.insertarEquipoAccesorio(det_equipo_Accesorio);
                                }
                            }
                        }
                    }
                    limpiar_entradas();
                    listarEquipo();
                    configNuevo();
                    comboBox_marca.SelectedIndex = 0;
                    comboBox_modelo.SelectedIndex = 0;
                    comboBoxCategoria.SelectedIndex = 0;

                }
                else 
                { 
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private entAccesorio BuscarAccesorio(string nombre)
        {
            foreach(entAccesorio accesorio in listaaccesorios)
            {
                if (accesorio.Nombre == nombre)
                    return accesorio;
            }
            return null;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex != -1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true && registroSeleccionado !="")
                {
                    entEquipo equipo = new entEquipo();
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();                    
                    equipo.id_modelo = modeloSelec.id_modelo;
                    equipo.IdMarca = marcaSelec.IdMarca ;
                    equipo.id_categoria = categoria.id_categoria_equipo;
                    equipo.otrosaccesorios = "";

                    logEquipo.GetInstancia.editarEquipo(equipo);

                    string serie_equipo = equipo.SerieEquipo;

                    //ELIMINAR DE LA BD EQUIPOACCESORIOS
                    logEquipo.GetInstancia.EliminarequipoAccesorio(serie_equipo);

                    //Volver a registrar equipo accesorio
                    entEquipo_Accesorio det_equipo_Accesorio = new entEquipo_Accesorio
                    {
                        SerieEquipo = serie_equipo
                    };

                    for (int i = 0; i < dgvAcesorios.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvAcesorios.Rows[i];
                        if (!row.IsNewRow)
                        {
                            bool estadoacesorio = false;
                            int cantidad = 0;
                            string name = "";

                            DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];

                            if (!row.IsNewRow)
                            {
                                estadoacesorio = (bool)checkBoxCell.Value;
                                if (estadoacesorio)
                                {
                                    DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)row.Cells[2];
                                    DataGridViewTextBoxCell textBoxCellName = (DataGridViewTextBoxCell)row.Cells[1];

                                    cantidad = Convert.ToInt16(textBoxCell.Value.ToString());
                                    name = Convert.ToString(textBoxCellName.Value);
                                    det_equipo_Accesorio.id_accesorio = BuscarAccesorio(name).IdAccesorio;
                                    det_equipo_Accesorio.cantidad = cantidad;
                                    logEquipoAccesorio.GetInstancia.insertarEquipoAccesorio(det_equipo_Accesorio);
                                }
                            }
                        }
                    }
                    limpiar_entradas();
                    listarEquipo();
                    deshablitar_btn();
                    deshablitar_entradas();
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && 
                                    comboBox_modelo.SelectedIndex != -1 && 
                                    comboBox_marca.SelectedIndex != -1 && 
                                    comboBoxCategoria.SelectedIndex!=-1);
            try
            {
                if (datosIngresados == true && registroSeleccionado !="")
                {
                    entEquipo equipo = new entEquipo
                    {
                        SerieEquipo = registroSeleccionado
                    };

                    logEquipo.GetInstancia.deshabilitarEquipo(equipo);
                    limpiar_entradas();
                    listarEquipo();
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

        private void dgvAcesorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) 
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvAcesorios.Rows[e.RowIndex].Cells[0];
                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)dgvAcesorios.Rows[e.RowIndex].Cells[2];

                // Verifica el estado del checkbox y habilita o deshabilita la edición de la tercera columna
                if (textBoxCell.Value.ToString() != "")
                {
                    textBoxCell.ReadOnly = true;
                    textBoxCell.Value = ""; 
                }
                else
                {
                    textBoxCell.ReadOnly = false;
                    textBoxCell.Value = "1";
                }
            }
        }

        private void dgvAcesorios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0  && e.ColumnIndex == 2)
            {
                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)dgvAcesorios.Rows[e.RowIndex].Cells[2];
                string cadena = textBoxCell.Value.ToString();
                if (!Regex.IsMatch(cadena, @"^\d+$"))
                {
                    MessageBox.Show("Ingrese solo numeros");
                    textBoxCell.Value = "1";
                }
                else
                {
                    if (Convert.ToInt16(cadena) <= 0)
                        textBoxCell.Value = "1";
                    else
                        textBoxCell.Value = Convert.ToInt16(cadena);
                }
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;

            if (categoria != null)
            {
                List<entMarca> marcas = logMarca.GetInstancia.listarMarcasPorCategoria(categoria.id_categoria_equipo);
                comboBox_marca.DataSource = marcas;
                if(marcas.Count>0)
                    comboBox_marca.SelectedIndex = 0;
                else
                {
                    comboBox_modelo.DataSource = null;
                    comboBox_modelo.ValueMember = "id_modelo";
                    comboBox_modelo.DisplayMember = "nombre";
                }
            }
        }

        private void comboBox_marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            entMarca marca = (entMarca)comboBox_marca.SelectedItem;
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
            if (marca != null && categoria!=null)
            {
                List<entModelo> modelos = logModelo.GetInstancia.listarModelos(marca.IdMarca,categoria.id_categoria_equipo);
                comboBox_modelo.DataSource = modelos;
                comboBox_modelo.Refresh();
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (comboBoxCategoria.Items.Count == 0)
                MessageBox.Show("Registra una categoria");
            else
            {
                comboBoxCategoria.SelectedIndex = 0;
                if (comboBox_marca.Items.Count == 0)
                    MessageBox.Show("Registra una marca");
                else
                {
                    comboBox_marca.SelectedIndex = 0;
                    if (comboBox_modelo.Items.Count == 0)
                        MessageBox.Show("Registra un modelo");
                    else
                    {
                        comboBox_modelo.SelectedIndex = 0;
                        configNuevo();
                    }
                }
            }
        }
    }
}

