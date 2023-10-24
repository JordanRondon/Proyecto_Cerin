using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
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

namespace Cerin_Ingenieros.Servicios.Mantenimiento
{
    public partial class preRegistEquipoMantenimiento : Form
    {
        ////private List<entEquipo> lisEquiposelect;
        private List<entEquipo> selecionado = new List<entEquipo>();
        private entEquipo temp = new entEquipo();
        List<entAccesorio> listaaccesorios;

        //selecionar equipos
        List<entEquipo_Servicio> list_equipo_servicio = new List<entEquipo_Servicio>();
        private string registroSeleccionado = "";

        public preRegistEquipoMantenimiento()
        {
            InitializeComponent();
            //registrar
            listarDatosComboBox();
            configInitial();
            ConfigCabecera();
            comboBox_modelo.SelectedIndex = -1;

            //selecionar
            ConfigInicial();
        }

        #region REGISTRAR
        private void configInitial()
        {
            
            txb_serie_equipo.Enabled = false;
            comboBox_modelo.Enabled = false;
            comboBox_modelo.SelectedIndex = -1;
            comboBox_marca.Enabled = false;
            comboBox_marca.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            comboBoxCategoria.Enabled = false;

            btnNuevoRegis.Enabled = true;
            btnNuevoRegis.BackColor = configColores.btnActivo;
            btnguardarRegist.Enabled = false;
            btnguardarRegist.BackColor = configColores.btDesactivado;
            btnCancelarRegist.Enabled = false;
            btnCancelarRegist.BackColor = configColores.btDesactivado;
            BtnEditarRegist.Enabled = false;
            BtnEditarRegist.BackColor = configColores.btDesactivado;
        }
        private void configNuevo()
        {
            txb_serie_equipo.Text = "";
            comboBox_modelo.SelectedIndex = 0;
            comboBox_marca.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;

            txb_serie_equipo.Enabled = true;
            comboBox_modelo.Enabled = true;
            comboBox_marca.Enabled = true;
            comboBoxCategoria.Enabled = true;

            btnNuevoRegis.Enabled = false;
            btnNuevoRegis.BackColor = configColores.btDesactivado;
            btnguardarRegist.Enabled = true;
            btnguardarRegist.BackColor = configColores.btnActivo;
            btnCancelarRegist.Enabled = true;
            btnCancelarRegist.BackColor = configColores.btnActivo;
        }

        private void listarDatosComboBox()
        {
            comboBoxCategoria.ValueMember = "id_categoria_equipo";
            comboBoxCategoria.DisplayMember = "nombre";
            comboBoxCategoria.DataSource = logCategoria.GetInstancia.listarCategoriasEquipos();

            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.DataSource = logMarca.GetInstancia.listarMarcas();

            comboBox_modelo.ValueMember = "id_modelo";
            comboBox_modelo.DisplayMember = "nombre";
        }

        private void btnCancelarRegist_Click(object sender, EventArgs e)
        {
            configInitial();
        }

        private void btnNuevoRegis_Click(object sender, EventArgs e)
        {
            if (comboBoxCategoria.Items.Count == 0)
            {
                MessageBox.Show("Registra una categoria");
            }
            else
            {
                comboBoxCategoria.SelectedIndex = 0;
                if (comboBox_marca.Items.Count == 0)
                {
                    MessageBox.Show("Registra una marca");
                }
                else
                {
                    comboBox_marca.SelectedIndex = 0;
                    //entMarca marca = (entMarca)comboBox_marca.SelectedItem;
                    //comboBox_modelo.DataSource = logModelo.GetInstancia.listarModelos(marca.IdMarca);
                    if (comboBox_modelo.Items.Count == 0)
                    {
                        MessageBox.Show("Registra un modelo");
                    }
                    else
                    {
                        comboBox_modelo.SelectedIndex = 0;
                        configNuevo();
                    }
                }
            }
        }

        private void btnguardarRegist_Click(object sender, EventArgs e)
        {
            try
            {
                bool campos = txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex!=-1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex!=-1;
                if (campos)
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    equipo.id_modelo = modeloSelec.id_modelo;
                    equipo.Estado = 'E';//POR DEFECTO DISPONIBLE
                    equipo.IdTipo = 2; //EQUIPO EXTERNO A LA EMPRESA
                    entMarca marcaselect = (entMarca)comboBox_marca.SelectedItem;
                    equipo.IdMarca = marcaselect.IdMarca;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    equipo.id_categoria = categoria.id_categoria_equipo;
                    equipo.otrosaccesorios = "";

                    logEquipo.GetInstancia.insertaEquipo(equipo);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }



            listarEquipo();
            configNuevo();
        }

        private void ConfigCabecera()
        {
            dgvListaDeEquipoClientes.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Categoria" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dgvListaDeEquipoClientes.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            listarEquipo();
        }
        private void listarEquipo()
        {

            List<entEquipo> listaEquipos = logEquipo.GetInstancia.listarEquipoExternos();

            dgvListaDeEquipoClientes.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaEquipos)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entCategoria categoria = logCategoria.GetInstancia.buscarCategoriaId(item.id_categoria);
                entModelo modelo  = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);

                if (item.Estado == 'E') estado = "Entregado";
                else if (item.Estado == 'U') estado = "En uso";
                else estado = "En proceso";
                dgvListaDeEquipoClientes.Rows.Add(
                    categoria.Nombre,
                    marca.Nombre,
                    modelo.nombre,
                    item.SerieEquipo,
                    estado
                );
            }
        }
        #endregion REGISTRAR

        public List<entEquipo> getEquipos() { return selecionado; }
        public List<entEquipo_Servicio> getServicios() { return list_equipo_servicio; }

        private void ConfigInicial()
        {
            groupBoxAccesorios.Enabled = false;
            groupBoxObservaciones.Enabled = false;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btnCancelarEquipo.Enabled = false;
            btnCancelarEquipo.BackColor = configColores.btDesactivado;
        }

        private void CargarTodosLosAccesorios()
        {
            listaaccesorios = logAccesorio.GetInstancia.listarAccesorio();
            CargarAccesorios();
        }

        private void CargarAccesorios()
        {
            dgvAcesorios.Enabled = true;
            dgvAcesorios.Rows.Clear();
            dgvAcesorios.Columns.Clear();

            dgvAcesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "Opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" , ReadOnly = true } ,
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditarRegist_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex != -1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex != -1);
            try
            {
                if (datosIngresados && registroSeleccionado!="")
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    equipo.id_modelo = modeloSelec.id_modelo;
                    equipo.Estado = 'E';//POR DEFECTO DISPONIBLE
                    equipo.IdTipo = 2; //EQUIPO EXTERNO A LA EMPRESA
                    entMarca marcaselect = (entMarca)comboBox_marca.SelectedItem;
                    equipo.IdMarca = marcaselect.IdMarca;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    equipo.id_categoria = categoria.id_categoria_equipo;
                    equipo.otrosaccesorios = "";

                    logEquipo.GetInstancia.editarEquipo(equipo);
                    listarEquipo();
                    configInitial();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problemas para editar el equipo");
            }
        }

        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            if (txb_serie.Text!="")
            {
                entEquipo equipo = logEquipo.GetInstancia.buscarEquipo(txb_serie.Text);
                if (equipo != null && equipo.IdTipo == 2)
                {
                    if(equipo.Estado == 'E')
                    {
                        //Desactivamos las opciones de modificar el equipo selecionado
                        txb_serie.Enabled = false;
                        btnBuscarEquipo.Enabled = false;
                        btnBuscarEquipo.BackColor = configColores.btDesactivado;

                        //activamos los accesorios y las observaciones
                        groupBoxAccesorios.Enabled = true;
                        groupBoxOtosAccesorios.Enabled = true;
                        groupBoxObservaciones.Enabled = true;
                        btnCancelarEquipo.Enabled = true;
                        btnCancelarEquipo.BackColor = configColores.btnActivo;
                        btn_guardar.Enabled = true;
                        btn_guardar.BackColor = configColores.btnActivo;

                        //cargamos los accesorios y elejimos los accesorios del equipo
                        //con los cuales entra al laboratorio
                        CargarTodosLosAccesorios();
                        temp = equipo;
                    }
                    else
                    {
                        if (equipo.Estado=='U')
                        {
                            MessageBox.Show("El equipo ya se encuentra en la lista");
                        }
                        else
                        {
                            MessageBox.Show("El equipo ya se encuentra en laboratorio");
                        }
                    }                    
                }
                else
                {
                    DialogResult result = MessageBox.Show("El equipo no se encuentra. ¿Registrasr equipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = tabPage2;
                        btnNuevoRegis_Click(this,EventArgs.Empty);
                        txb_serie_equipo.Text = txb_serie.Text;
                    }
                }
            }

        }        

        private void btnCancelarEquipo_Click(object sender, EventArgs e)
        {

            conficancel();
        }
        private void conficancel()
        {
            txb_serie.Enabled = true;
            btnBuscarEquipo.Enabled = true;
            btnBuscarEquipo.BackColor = configColores.btnActivo;

            txbObservaciones.Text = "";
            txb_serie.Text = "";
            txbOtrosAccesorios.Text = "";
            //vaciamos la lista de accesorios
            listaaccesorios.Clear();
            CargarAccesorios();

            groupBoxAccesorios.Enabled = false;
            groupBoxObservaciones.Enabled = false;
            groupBoxOtosAccesorios.Enabled = false;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btnCancelarEquipo.Enabled = false;
            btnCancelarEquipo.BackColor = configColores.btDesactivado;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            //creamos un equipo_servicio
            entEquipo_Servicio equipo_Servicio = new entEquipo_Servicio();

            //damos los valores - recomendaciones finales se dara cuando se actualice el servicio
            // y id_servicio cuando se registre
            equipo_Servicio.serie_equipo = txb_serie.Text;
            equipo_Servicio.Observaciones_preliminares = txbObservaciones.Text;
            //agregamos a la lista
            list_equipo_servicio.Add(equipo_Servicio);

            //agregamos el equipo selecionado a la lsita de equipos
            temp.Estado = 'U';
            temp.otrosaccesorios = txbOtrosAccesorios.Text;
            logEquipo.GetInstancia.editarEquipo(temp);
            selecionado.Add(temp);

            //Registramos los accesorios para el equipo

            List<entEquipo_Accesorio> list_det_equipo_accesorio_ = logEquipoAccesorio.GetInstancia.listar(temp.SerieEquipo);

            for (int i = 0; i < dgvAcesorios.Rows.Count; i++)
            {
                DataGridViewRow row = dgvAcesorios.Rows[i];
                if (!row.IsNewRow)
                {
                    string serie_equipo = txb_serie.Text;
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
                        entEquipo_Accesorio det_equipo_Accesorio = logEquipoAccesorio.GetInstancia.BuscarEquipoAccesorio(serie_equipo, id_accesorio);

                        //verificar que si el equiop_accesorio esxiste en la base de datos
                        if (det_equipo_Accesorio != null)
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
                            if (item.SerieEquipo == serie_equipo && item.id_accesorio == id_accesorio)
                            {
                                bool estadofel = logEquipoAccesorio.GetInstancia.EliminarDetalle(serie_equipo, id_accesorio);
                                break;
                            }
                        }
                    }
                }
            }

            //configuracion inicial
            conficancel();
            listarEquipo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int obtenerIndiceModeloSelec(DataGridViewRow filaActual)
        {
            List<entModelo> listaModelo = new List<entModelo>();

            //listaModelo = logModelo.GetInstancia.listarModelos();

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

        private void habilitar_btn_modificacion()
        {
            btnNuevoRegis.Enabled = false;
            btnNuevoRegis.BackColor = configColores.btDesactivado;
            btnguardarRegist.Enabled = false;
            btnguardarRegist.BackColor = configColores.btDesactivado;
            BtnEditarRegist.Enabled = true;
            BtnEditarRegist.BackColor = configColores.btnActivo;
            btnCancelarRegist.Enabled = true;
            btnCancelarRegist.BackColor = configColores.btnActivo;

            txb_serie.Enabled = true;
            comboBoxCategoria.Enabled = true;
            comboBox_marca.Enabled = true;
            comboBox_modelo.Enabled = true;
        }

        private void dgvListaDeEquipoClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow filaActual = dgvListaDeEquipoClientes.Rows[e.RowIndex];

                registroSeleccionado = Convert.ToString(filaActual.Cells[0].Value.ToString());
                txb_serie_equipo.Text = registroSeleccionado;
                //FALTA ACUTALIZAR EL ESTADO
                comboBox_modelo.SelectedIndex = obtenerIndiceModeloSelec(filaActual);
                comboBox_marca.SelectedIndex = obtenerIndiceMarcaSelec(filaActual);
                comboBoxCategoria.SelectedIndex = obtenerIndiceCategoriaSelec(filaActual);

                habilitar_btn_modificacion();

                
            }
        }

        private void dgvAcesorios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2) 
            {
                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)dgvAcesorios.Rows[e.RowIndex].Cells[2];
                string valor = textBoxCell.Value.ToString();
                if (!Regex.IsMatch(valor, @"^\d+$"))
                {
                    MessageBox.Show("Ingrese solo numeros");
                    textBoxCell.Value = "1";
                }
                else
                {
                    if (Convert.ToInt16(valor) <= 0)
                        textBoxCell.Value = "1";
                    else
                        textBoxCell.Value = Convert.ToInt16(valor);
                }
            }
        }

        private void comboBox_marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            entMarca marca = (entMarca)comboBox_marca.SelectedValue;
            if (marca != null)
            {

                // Consulta y llena comboBox_Modelo con modelos relacionados a la marca seleccionada
                List<entModelo> modelos = logModelo.GetInstancia.listarModelos(marca.IdMarca);

                // Llena comboBox_Modelo con los datos de los modelos
                comboBox_modelo.DataSource = modelos;
            }
        }
    }
}
