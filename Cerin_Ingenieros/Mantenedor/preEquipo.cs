using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Cerin_Ingenieros
{
    public partial class preEquipo : Form
    {
        private string registroSeleccionado = "";
        private List<entAccesorio> listaaccesorios;

        public preEquipo()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarEquipo();
            listarDatosComboBox();
            comboBox_modelo.SelectedIndex = -1;
            comboBox_marca.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
        }

        private void limpiar_entradas()
        {
            txb_serie_equipo.Text = "";
            comboBox_marca.SelectedIndex = -1;
            comboBox_modelo.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            registroSeleccionado = "";
            listaaccesorios.Clear();
            CargarAccesorios();
            //dgvAcesorios.Enabled = false;
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
            btn_nuevo.Enabled = true;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = false;
        }

        private void habilitar_btn_modificacion()
        {
            hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_cancelar.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (comboBoxCategoria.Items.Count == 0)
                MessageBox.Show("Registra una categoria");
            else if(comboBox_marca.Items.Count == 0)
                MessageBox.Show("Registra una marca");
            else if(comboBox_modelo.Items.Count ==0)
                MessageBox.Show("Registra un modelo");
            else
                configNuevo();
        }
        private void configNuevo()
        {
            hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = true;
            dgvAcesorios.Enabled = true;
            comboBox_modelo.SelectedIndex = 0;
            comboBox_marca.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;
            cargarAccesorios();
        }
        private void cargarAccesorios()
        {
            listaaccesorios = logAccesorio.GetInstancia.listarAccesorio();
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
            dgvAcesorios.Columns.Clear();

            dgvAcesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "Opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre", ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true, Name = "Cantidad" }
            );
            dgvAcesorios.Columns[0].Width = 50;
            dgvAcesorios.Columns[2].Width = 80;

            foreach (DataGridViewColumn column in dgvAcesorios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (var item in listaaccesorios)
            {
                dgvAcesorios.Rows.Add(
                    false,
                    item.Nombre,
                    ""
                );
            }

        }
        private void ConfigCabecera()
        {
            dataGridView_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Categira equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void listarEquipo()
        {

            List<entEquipo> listaEquipos = logEquipo.GetInstancia.listarEquipoAlquiler();

            dataGridView_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaEquipos)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entModelo modelo = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);
                entCategoria categoria = logCategoria.GetInstancia.buscarCategoriaId(item.id_categoria);

                switch (item.Estado)
                {
                    case 'D': estado = "Disponible"; break;
                    case 'U': estado = "En Uso"; break;
                    case 'O': estado = "Ocupado"; break;
                    default: estado = "Eliminado"; break;

                }
                dataGridView_equipos.Rows.Add(
                    item.SerieEquipo,
                    modelo.nombre,
                    estado,
                    marca.Nombre,
                    categoria.Nombre
                );
            }
        }
        

        private int obtenerIndiceModeloSelec(DataGridViewRow filaActual)
        {
            List<entModelo> listaModelo = new List<entModelo>();

            listaModelo = logModelo.GetInstancia.listarModelos();

            entModelo modeloSeleccionado = new entModelo();

            foreach (var i in listaModelo)
            {
                //obtenemos el registro mediante un ID especifico 
                if (i.nombre == filaActual.Cells[1].Value.ToString())
                {
                    modeloSeleccionado = i;
                    break;
                }
            }

            //obtenemos la poscion dentro del comboBox mediande el nombreMarca
            int index = comboBox_modelo.FindString(modeloSeleccionado.nombre);

            if (index != -1)
                return index;
            else
                return -1;
        }

        private void listarDatosComboBox()
        {
            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.DataSource = logMarca.GetInstancia.listarMarcas();

            comboBox_modelo.ValueMember = "id_modelo";
            comboBox_modelo.DisplayMember = "nombre";
            comboBox_modelo.DataSource = logModelo.GetInstancia.listarModelos();

            comboBoxCategoria.ValueMember = "id_categoria_equipo";
            comboBoxCategoria.DisplayMember = "nombre";
            comboBoxCategoria.DataSource = logCategoria.GetInstancia.listarCategoriasEquipos();
        }

        private int obtenerIndiceMarcaSelec(DataGridViewRow filaActual)
        {
            List<entMarca> listaMarca = new List<entMarca>();

            listaMarca = logMarca.GetInstancia.listarMarcas();

            entMarca marcaSeleccionada = new entMarca();

            foreach (var i in listaMarca)
            {
                //obtenemos el registro mediante un ID especifico 
                if (i.Nombre == filaActual.Cells[3].Value.ToString())
                {
                    marcaSeleccionada = i;
                    break;
                }
            }

            //obtenemos la poscion dentro del comboBox mediande el nombreMarca
            int index = comboBox_marca.FindString(marcaSeleccionada.Nombre);

            if (index != -1)
                return index;
            else
                return -1;
        }

        private int obtenerIndiceCategoriaSelec(DataGridViewRow filaActual)
        {
            List<entCategoria> listacategoria = new List<entCategoria>();

            listacategoria = logCategoria.GetInstancia.listarCategoriasEquipos();

            entCategoria categoriaSeleccionada = new entCategoria();

            foreach (var i in listacategoria)
            {
                //obtenemos el registro mediante un ID especifico 
                if (i.Nombre == filaActual.Cells[4].Value.ToString())
                {
                    categoriaSeleccionada = i;
                    break;
                }
            }

            //obtenemos la poscion dentro del comboBox mediande el nombreMarca
            int index = comboBoxCategoria.FindString(categoriaSeleccionada.Nombre);

            if (index != -1)
                return index;
            else
                return -1;
        }

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                //LIMPIAR EQUIPO ACESORIO
                cargarAccesorios();

                DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];

                registroSeleccionado = Convert.ToString(filaActual.Cells[0].Value.ToString());
                txb_serie_equipo.Text = registroSeleccionado;
                //FALTA ACUTALIZAR EL ESTADO
                comboBox_modelo.SelectedIndex = obtenerIndiceModeloSelec(filaActual);
                comboBox_marca.SelectedIndex = obtenerIndiceMarcaSelec(filaActual);
                comboBoxCategoria.SelectedIndex = obtenerIndiceCategoriaSelec(filaActual);

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
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    equipo.id_modelo = modeloSelec.id_modelo;
                    equipo.Estado = 'D';//estado disponible
                    equipo.IdTipo = 1; //tipo de servicio alquiler
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    equipo.IdMarca = marcaSelec.IdMarca;
                    entCategoria marcaCategoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    equipo.id_categoria = marcaCategoria.id_categoria_equipo;
                    equipo.otrosaccesorios = "";

                    string seri_selecionada = logEquipo.GetInstancia.insertaEquipo(equipo);

                    //insertar los accesorios del equipo
                    entEquipo_Accesorio det_equipo_Accesorio = new entEquipo_Accesorio();
                    det_equipo_Accesorio.SerieEquipo = seri_selecionada;


                    for (int i = 0; i < dgvAcesorios.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvAcesorios.Rows[i];
                        if (!row.IsNewRow)
                        {
                            bool estadoacesorio = false; // Valor predeterminado en caso de que no sea verdadero ni falso
                            int cantidad = 0; //cantidad predeterminada 
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
                                    det_equipo_Accesorio.id_accesorio = logAccesorio.GetInstancia.BuscarAccesorioNombre(name).IdAccesorio;
                                    det_equipo_Accesorio.cantidad = cantidad;
                                    logEquipoAccesorio.GetInstancia.insertarEquipoAccesorio(det_equipo_Accesorio);
                                }
                                /////// alidar por idaccesorio y acesorio
                            }
                        }
                    }

                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarEquipo();
            configNuevo();
            //listaaccesorios.Clear();

            //reiniciar el combobox al primer elemento 
            if (comboBox_marca.Items.Count >= 0 || comboBox_modelo.Items.Count >= 0 || comboBoxCategoria.Items.Count>=0)
            {
                comboBox_marca.SelectedIndex = 0;
                comboBox_modelo.SelectedIndex = 0;
                comboBoxCategoria.SelectedIndex = 0;
            }  
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex != -1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true && registroSeleccionado !="")
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    equipo.id_modelo = modeloSelec.id_modelo;
                    equipo.Estado = 'D';//estado disponible
                    equipo.IdTipo = 1; //tipo de servicio alquiler
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    equipo.IdMarca = marcaSelec.IdMarca ;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    equipo.id_categoria = categoria.id_categoria_equipo;
                    equipo.otrosaccesorios = "";

                    logEquipo.GetInstancia.editarEquipo(equipo);

                    string serie_equipo = equipo.SerieEquipo;

                    //EditarEquipoAccesorio
                    //entEquipo_Accesorio det_equipo_Accesorio = new entEquipo_Accesorio();
                    //det_equipo_Accesorio.id_equipo = id_equipo;

                    List<entEquipo_Accesorio> list_det_equipo_accesorio_ = logEquipoAccesorio.GetInstancia.listar();

                    for (int i = 0; i < dgvAcesorios.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvAcesorios.Rows[i];
                        if (!row.IsNewRow)
                        {
                            bool estadoacesorio = false; // Valor predeterminado en caso de que no sea verdadero ni falso
                            int cantidad = 0; //cantidad predeterminada 
                            string name = "";

                            DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            estadoacesorio = (bool)checkBoxCell.Value;


                            //nombre del accesorio
                            DataGridViewTextBoxCell textBoxCellName = (DataGridViewTextBoxCell)row.Cells[1];
                            name = Convert.ToString(textBoxCellName.Value);

                            //buscar el id del accesorio
                            int id_accesorio = logAccesorio.GetInstancia.BuscarAccesorioNombre(name).IdAccesorio;

                            //verificar si el accesorio es del equipo
                            if (estadoacesorio)
                            {

                                //cantidad del accesorio
                                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)row.Cells[2];
                                cantidad = Convert.ToInt16(textBoxCell.Value.ToString());

                                //bucar un equipoaccesorio
                                entEquipo_Accesorio det_equipo_Accesorio = logEquipoAccesorio.GetInstancia.BuscarEquipoAccesorio(equipo.SerieEquipo, id_accesorio);

                                //verificar que si el equiop_accesorio esxiste en la base de datos
                                if (det_equipo_Accesorio!=null)
                                {
                                    // el equipo_accesorio ya existe en la bd por lo tanto hay que editar la cantidad
                                    det_equipo_Accesorio.cantidad = cantidad;
                                    logEquipoAccesorio.GetInstancia.EditarEquipoAccesorio(det_equipo_Accesorio);
                                }
                                else
                                {
                                    //registrar un euipo accesorio nuevo que no se encuentra en la bd
                                    det_equipo_Accesorio = new entEquipo_Accesorio();

                                    det_equipo_Accesorio.SerieEquipo = serie_equipo;
                                    det_equipo_Accesorio.id_accesorio = id_accesorio;
                                    det_equipo_Accesorio.cantidad = cantidad;
                                    logEquipoAccesorio.GetInstancia.insertarEquipoAccesorio(det_equipo_Accesorio);

                                }
                            }
                            else
                            {
                                foreach (var item in list_det_equipo_accesorio_)
                                {
                                    if (item.SerieEquipo==serie_equipo && item.id_accesorio==id_accesorio)
                                    {
                                        bool estadofel = logEquipoAccesorio.GetInstancia.EliminarDetalle(serie_equipo,id_accesorio);
                                        break;
                                    }
                                }
                            }
                        }
                    }
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
            listarEquipo();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex != -1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex!=-1);

            try
            {
                if (datosIngresados == true && registroSeleccionado !="")
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = registroSeleccionado;

                    logEquipo.GetInstancia.deshabilitarEquipo(equipo);
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
            listarEquipo();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void dgvAcesorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Verifica que el evento ocurrió en la primera columna
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
    }
}

