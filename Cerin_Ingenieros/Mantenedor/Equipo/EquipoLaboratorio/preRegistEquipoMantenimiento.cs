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
        private List<entEquipo> listaEquiposSelecionados;
        private entEquipo EquipoSelecionaTemporal = new entEquipo();
        private List<entAccesorio> listaaccesorios;

        //selecionar equipos
        List<entEquipo_Servicio> list_equipo_servicio = new List<entEquipo_Servicio>();
        private string registroSeleccionado = "";

        public preRegistEquipoMantenimiento()
        {
            InitializeComponent();
            //registrar

            listaaccesorios = logAccesorio.GetInstancia.listarAccesorio();
            listarDatosComboBox();
            ConfigInitial();
            ConfigCabecera();
            comboBox_modelo.SelectedIndex = -1;

            //selecionar
            ConfigInicial();
            listaEquiposSelecionados = new List<entEquipo>();
        }

        #region REGISTRAR
        private void ConfigInitial()
        {
            
            txb_serie_equipo.Enabled = false;
            comboBox_modelo.Enabled = false;
            comboBox_marca.Enabled = false;
            comboBoxCategoria.Enabled = false;

            comboBox_marca.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            comboBox_modelo.SelectedIndex = -1;


            configColores.EstsblecerPropiedadesBoton(btnNuevoRegis,true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btnguardarRegist, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btnCancelarRegist, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(BtnEditarRegist, false, configColores.btDesactivado);
            
        }
        private void ConfigNuevo()
        {
            txb_serie_equipo.Text = "";
            comboBox_modelo.SelectedIndex = 0;
            comboBox_marca.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;

            txb_serie_equipo.Enabled = true;
            comboBox_modelo.Enabled = true;
            comboBox_marca.Enabled = true;
            comboBoxCategoria.Enabled = true;

            configColores.EstsblecerPropiedadesBoton(btnNuevoRegis, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btnguardarRegist, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btnCancelarRegist, true, configColores.btnActivo);
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

        private void btnCancelarRegist_Click(object sender, EventArgs e)
        {
            ConfigInitial();
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
                    if (comboBox_modelo.Items.Count == 0)
                    {
                        MessageBox.Show("Registra un modelo");
                    }
                    else
                    {
                        comboBox_modelo.SelectedIndex = 0;
                        ConfigNuevo();
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
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    entMarca marcaselect = (entMarca)comboBox_marca.SelectedItem;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    entEquipo equipo = new entEquipo
                    {
                        SerieEquipo = txb_serie_equipo.Text.Trim(),
                        Estado = 'E',//POR DEFECTO ENTREGADO
                        IdTipo = 2, //EQUIPO EXTERNO A LA EMPRESA
                        otrosaccesorios = "",
                        IdMarca = marcaselect.IdMarca,
                        id_categoria = categoria.id_categoria_equipo,
                        id_modelo = modeloSelec.id_modelo
                    };

                    logEquipo.GetInstancia.insertaEquipo(equipo);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }



            listarEquipo();
            ConfigNuevo();
        }

        private void ConfigCabecera()
        { 
            dgvConfiguracion.ConfigurarColumnas(dgvListaDeEquipoClientes,
                        new string[] { "Categira equipo", "Marca", "Modelo", "Serie del equipo", "Estado" });

            listarEquipo();

            dgvAcesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "Opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre", ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true, Name = "Cantidad" }
            );
            dgvAcesorios.Columns[0].Width = 40;
            dgvAcesorios.Columns[2].Width = 60;
        }
        private void listarEquipo()
        {

            List<entEquipo> listaEquipos = logEquipo.GetInstancia.listarEquipoExternos();
            dgvListaDeEquipoClientes.Rows.Clear();

            //insertar los datos 
            foreach (var equipo in listaEquipos)
            {
                string estado;
                entMarca marca;
                entModelo modelo;
                entCategoria categoria;

                (categoria, marca, modelo) = logEquipo.GetInstancia.datosCompledoDeEquipoPorId(equipo.SerieEquipo);

                switch (equipo.Estado)
                {
                    case 'E': estado = "Entregado"; break;
                    case 'U': estado = "En Uso"; break;
                    case 'P': estado = "En laboratorio"; break;
                    default: estado = "Eliminado"; break;

                }
                dgvListaDeEquipoClientes.Rows.Add(
                    categoria.Nombre,
                    marca.Nombre,
                    modelo.nombre,
                    equipo.SerieEquipo,
                    estado
                );
            }
        }
        #endregion REGISTRAR

        public List<entEquipo> getEquipos() { return listaEquiposSelecionados; }
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

        private void CargarAccesorios()
        {
            dgvAcesorios.Enabled = true;
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

        private void BtnEditarRegist_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && comboBox_modelo.SelectedIndex != -1 && comboBox_marca.SelectedIndex != -1 && comboBoxCategoria.SelectedIndex != -1);
            try
            {
                if (datosIngresados && registroSeleccionado!="")
                {
                    entModelo modeloSelec = (entModelo)comboBox_modelo.SelectedItem;
                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    entMarca marcaselect = (entMarca)comboBox_marca.SelectedItem;
                    entEquipo equipo = new entEquipo
                    {
                        SerieEquipo = txb_serie_equipo.Text.Trim(),
                        id_modelo = modeloSelec.id_modelo,
                        IdMarca = marcaselect.IdMarca,
                        id_categoria = categoria.id_categoria_equipo,
                        otrosaccesorios = ""
                    };

                    logEquipo.GetInstancia.editarEquipo(equipo);
                    listarEquipo();
                    ConfigInitial();
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
                        CargarAccesorios();
                        EquipoSelecionaTemporal = equipo;
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
            entEquipo_Servicio equipo_Servicio = new entEquipo_Servicio
            {
                serie_equipo = txb_serie.Text,
                Observaciones_preliminares = txbObservaciones.Text
            };
            //agregamos a la lista
            list_equipo_servicio.Add(equipo_Servicio);

            //agregamos el equipo selecionado a la lsita de equipos
            EquipoSelecionaTemporal.Estado = 'U';
            EquipoSelecionaTemporal.otrosaccesorios = txbOtrosAccesorios.Text;
            logEquipo.GetInstancia.editarEquipo(EquipoSelecionaTemporal);
            listaEquiposSelecionados.Add(EquipoSelecionaTemporal);

            //Registramos los accesorios para el equipo

            //ELIMINAR DE LA BD EQUIPOACCESORIOS
            logEquipo.GetInstancia.EliminarequipoAccesorio(EquipoSelecionaTemporal.SerieEquipo);

            //insertar los accesorios del equipo
            entEquipo_Accesorio det_equipo_Accesorio = new entEquipo_Accesorio
            {
                SerieEquipo = EquipoSelecionaTemporal.SerieEquipo
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

            //configuracion inicial
            conficancel();
            listarEquipo();
        }
        private entAccesorio BuscarAccesorio(string nombre)
        {
            foreach (entAccesorio accesorio in listaaccesorios)
            {
                if (accesorio.Nombre == nombre)
                    return accesorio;
            }
            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ALALISIS PENDIENTE
        private int obtenerIndiceModeloSelec(DataGridViewRow filaActual)
        {
            List<entModelo> listaModelo = new List<entModelo>();

            entMarca marca = (entMarca)comboBox_marca.SelectedItem;
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
            listaModelo = logModelo.GetInstancia.listarModelos(marca.IdMarca, categoria.id_categoria_equipo);

            entModelo modeloSeleccionado = new entModelo();

            foreach (var i in listaModelo)
            {
                //obtenemos el registro mediante un ID especifico 
                if (i.nombre == filaActual.Cells[2].Value.ToString())
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
                if (i.Nombre == filaActual.Cells[1].Value.ToString())
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
                if (i.Nombre == filaActual.Cells[0].Value.ToString())
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

                registroSeleccionado = Convert.ToString(filaActual.Cells[3].Value.ToString());
                txb_serie_equipo.Text = registroSeleccionado;
                //FALTA ACUTALIZAR EL ESTADO
                comboBoxCategoria.SelectedIndex = obtenerIndiceCategoriaSelec(filaActual);
                comboBox_marca.SelectedIndex = obtenerIndiceMarcaSelec(filaActual);
                comboBox_modelo.SelectedIndex = obtenerIndiceModeloSelec(filaActual);

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

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;

            if (categoria != null)
            {
                List<entMarca> marcas = logMarca.GetInstancia.listarMarcasPorCategoria(categoria.id_categoria_equipo);
                comboBox_marca.DataSource = marcas;
                if (marcas.Count > 0)
                    comboBox_marca.SelectedIndex = 0;
                else
                    comboBox_modelo.DataSource = null;
            }
        }

        private void comboBox_marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            entMarca marca = (entMarca)comboBox_marca.SelectedItem;
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
            if (marca != null && categoria != null)
            {
                List<entModelo> modelos = logModelo.GetInstancia.listarModelos(marca.IdMarca, categoria.id_categoria_equipo);
                comboBox_modelo.DataSource = modelos;
            }
        }
    }
}
