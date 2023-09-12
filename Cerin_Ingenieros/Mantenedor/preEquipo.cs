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
    public partial class preEquipo : Form
    {
        string registroSeleccionado = "";
        List<entAccesorio> listaaccesorios;

        public preEquipo()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarEquipo();
            listarDatosComboBoxMarca();
            dataGridView_equipos.ReadOnly = true;
            comboBox_marca.SelectedIndex = -1;
            comboBox_marca.DropDownStyle = ComboBoxStyle.DropDownList;//comboBox solo lectura
        }

        private void limpiar_entradas()
        {
            txb_serie_equipo.Text = "";
            txb_modelo_equipo.Text = "";
            comboBox_marca.SelectedIndex = -1;
            registroSeleccionado = "";
            listaaccesorios.Clear();
            CargarAccesorios();
            //dgvAcesorios.Enabled = false;
        }

        private void hablitar_entradas()
        {
            txb_serie_equipo.Enabled = true;
            txb_modelo_equipo.Enabled = true;
            comboBox_marca.Enabled = true;
        }

        private void deshablitar_entradas()
        {
            txb_serie_equipo.Enabled = false;
            txb_modelo_equipo.Enabled = false;
            comboBox_marca.Enabled = false;
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
            comboBox_marca.SelectedIndex = 0;
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
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true }
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

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dataGridView_equipos.Rows.Add(
                    item.SerieEquipo,
                    item.id_modelo,
                    estado,
                    marca.Nombre
                );
            }
        }

        private void listarDatosComboBoxMarca()
        {
            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.DataSource = logMarca.GetInstancia.listarMarcas();
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

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //LIMPIAR EQUIPO ACESORIO
            cargarAccesorios();

            DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];

            registroSeleccionado = Convert.ToString(filaActual.Cells[0].Value.ToString());
            txb_serie_equipo.Text = registroSeleccionado;
            txb_modelo_equipo.Text = filaActual.Cells[1].Value.ToString();
            //FALTA ACUTALIZAR EL ESTADO
            comboBox_marca.SelectedIndex = obtenerIndiceMarcaSelec(filaActual);

            habilitar_btn_modificacion();

            //cargar accesorios del equipo actual

            List<entEquipo_Accesorio> listAccesoriosDeX = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(registroSeleccionado);

            foreach(var item in listAccesoriosDeX)
            {
                entAccesorio acctemp = logAccesorio.GetInstancia.BuscarAccesorioId(item.id_accesorio);
                for(int i = 0;dgvAcesorios.Rows.Count > 0; i++)
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

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true)
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    equipo.id_modelo = Convert.ToInt16( txb_modelo_equipo.Text.Trim());
                    equipo.Estado = 'D';//estado disponible
                    equipo.IdTipo = 1; //tipo de servicio alquiler
                    equipo.IdMarca = comboBox_marca.SelectedIndex + 1;
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
            if (comboBox_marca.Items.Count >= 0)
                comboBox_marca.SelectedIndex = 0;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true && registroSeleccionado !="")
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    equipo.id_modelo =Convert.ToInt16( txb_modelo_equipo.Text.Trim());
                    equipo.Estado = 'D';//estado disponible
                    equipo.IdTipo = 1; //tipo de servicio alquiler
                    equipo.IdMarca = comboBox_marca.SelectedIndex + 1;
                    equipo.id_modelo = Convert.ToInt16(txb_modelo_equipo.Text);

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
            bool datosIngresados = (txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1);

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
                    textBoxCell.Value = ""; // aqui que asigne el valor null por defecto
                }
                else
                {
                    textBoxCell.ReadOnly = false;
                    textBoxCell.Value = "1"; // aqui que asigne el valor 1 por defecto
                }


            }
        }
    }
}

