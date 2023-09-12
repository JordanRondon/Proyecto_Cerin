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

namespace Cerin_Ingenieros.Servicios.Mantenimiento
{
    public partial class preRegistEquipoMantenimiento : Form
    {
        private List<entEquipo> lisEquiposelect;
        private List<entEquipo> selecionado = new List<entEquipo>();
        private entEquipo temp = new entEquipo();
        List<entAccesorio> listaaccesorios;

        //selecionar equipos
        List<entEquipo_Servicio> list_equipo_servicio = new List<entEquipo_Servicio>();

        public preRegistEquipoMantenimiento()
        {
            InitializeComponent();
            //registrar
            listarDatosComboBoxMarca();
            configInitial();
            ConfigCabecera();

            //selecionar
            ConfigInicial();
        }

        #region REGISTRAR
        private void configInitial()
        {
            txb_serie_equipo.Enabled = false;
            txb_modelo_equipo.Enabled = false;
            comboBox_marca.Enabled = false;

            btnNuevoRegis.Enabled = true;
            btnguardarRegist.Enabled = false;
            btnCancelarRegist.Enabled = false;
            BtnEditarRegist.Enabled = false;
        }
        private void configNuevo()
        {
            txb_serie_equipo.Text = "";
            txb_modelo_equipo.Text = "";

            txb_serie_equipo.Enabled = true;
            txb_modelo_equipo.Enabled = true;
            comboBox_marca.Enabled = true;

            btnNuevoRegis.Enabled = false;
            btnguardarRegist.Enabled = true;
            btnCancelarRegist.Enabled = true;
            BtnEditarRegist.Enabled = true;
        }

        private void listarDatosComboBoxMarca()
        {
            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.DataSource = logMarca.GetInstancia.listarMarcas();
        }

        private void btnCancelarRegist_Click(object sender, EventArgs e)
        {
            configInitial();
        }

        private void btnNuevoRegis_Click(object sender, EventArgs e)
        {
            configNuevo();
        }

        private void btnguardarRegist_Click(object sender, EventArgs e)
        {
            try
            {
                bool campos = txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1;
                if (campos)
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    equipo.id_modelo = Convert.ToInt16(txb_modelo_equipo.Text.Trim());
                    equipo.Estado = 'D';//POR DEFECTO DISPONIBLE
                    equipo.IdTipo = 2; //EQUIPO EXTERNO A LA EMPRESA
                    equipo.IdMarca = comboBox_marca.SelectedIndex + 1;
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
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
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

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dgvListaDeEquipoClientes.Rows.Add(
                    item.SerieEquipo,
                    item.id_modelo,
                    estado,
                    marca.Nombre
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
            btnCancelarEquipo.Enabled = false;
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

        }

        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            if (txb_serie.Text!="")
            {
                entEquipo equipo = logEquipo.GetInstancia.buscarEquipoID(txb_serie.Text,2);
                if (equipo != null)
                {
                    //Desactivamos las opciones de modificar el equipo selecionado
                    txb_serie.Enabled = false;
                    btnBuscarEquipo.Enabled = false;

                    //activamos los accesorios y las observaciones
                    groupBoxAccesorios.Enabled = true;
                    groupBoxObservaciones.Enabled = true;
                    btnCancelarEquipo.Enabled = true;
                    btn_guardar.Enabled = true;

                    //cargamos los accesorios y elejimos los accesorios del equipo
                    //con los cuales entra al laboratorio
                    CargarTodosLosAccesorios();

                    temp = equipo;
                }
                else
                {
                    MessageBox.Show("La serie no es valida");
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

            txbObservaciones.Text = "";
            txb_serie.Text = "";

            //vaciamos la lista de accesorios
            listaaccesorios.Clear();
            CargarAccesorios();

            groupBoxAccesorios.Enabled = false;
            groupBoxObservaciones.Enabled = false;
            btn_guardar.Enabled = false;
            btnCancelarEquipo.Enabled = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entEquipo_Servicio equipo_Servicio = new entEquipo_Servicio();

            equipo_Servicio.serie_equipo = txb_serie.Text;
            equipo_Servicio.Observaciones_preliminares = txbObservaciones.Text;

            list_equipo_servicio.Add(equipo_Servicio);

            selecionado.Add(temp);

            conficancel();
        }
    }
}
