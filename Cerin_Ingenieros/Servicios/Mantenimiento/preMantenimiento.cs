using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios.Alquiler;
using Cerin_Ingenieros.Servicios.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preMantenimiento : Form
    {
        entCliente clienteSelecionado = null;
        List<entEquipo> equiposSelecionados;
        List<entEquipo_Servicio> list_det_equipo_servicio = new List<entEquipo_Servicio>();
        bool prosesoCancelado = true;

        public preMantenimiento()
        {
            InitializeComponent();
            inicializarVariablesAux();
            ConfigCabecera();
            listarDatosComboBoxEmpleados();
        }
        private void listarDatosComboBoxEmpleados()
        {
            comboBox_empleado.ValueMember = "id_empleado";
            comboBox_empleado.DisplayMember = "apellidoNombre";
            comboBox_empleado.DataSource = logEmpleado.GetInstancia.listarEmpleado()
                .Select(e => new
                {
                    id_empleado = e.IdEmpleado,
                    apellidoNombre = $"{e.Apellido}, {e.Nombre}" // Combina apellido y nombre
                })
                .ToList();
        }
        private void ConfigCabecera()
        {
            dataGridView_lista_quipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_lista_quipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            equiposSelecionados = new List<entEquipo>();
            listarEquipos();
        }

        private void listarEquipos()
        {
            dataGridView_lista_quipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in equiposSelecionados)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);

                if (item.Estado == 'D') estado = "Disponible";
                else if (item.Estado == 'U') estado = "Usando ahora";
                else estado = "Ocupado";
                dataGridView_lista_quipos.Rows.Add(
                    item.SerieEquipo,
                    item.id_modelo,
                    estado,
                    marca.Nombre
                );
            }
        }
        private void inicializarVariablesAux()
        {
            //Configuracion de fecha y hora
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();

            //Configuracion inicial
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            btn_nuevo.Enabled = true;
            btn_cancelar.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;

            lb_dni_ruc_cliente.Text = "DNI";
            lb_nombres_cliente.Text = "Nombres";
            lb_apellidos_cliente.Text = "Apellidos";
            lb_telefono_cliente.Text = "Telefono";
        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            preRegistEquipoMantenimiento preRegistEquipoMantenimiento = new preRegistEquipoMantenimiento();
            preRegistEquipoMantenimiento.ShowDialog();

            equiposSelecionados.AddRange(preRegistEquipoMantenimiento.getEquipos());
            list_det_equipo_servicio.AddRange(preRegistEquipoMantenimiento.getServicios());

            listarEquipos();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado != null)
            {
                lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                txb_ruc.Text = clienteSelecionado.Ruc;
                lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                lb_telefono_cliente.Text = clienteSelecionado.Telefono;
                txb_razon_social.Text = clienteSelecionado.RazonSocial;
            }
        }

        private void preMantenimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActualizarEstadosEquipos();
        }
        private void ActualizarEstadosEquipos()
        {
            if (equiposSelecionados.Count > 0 && prosesoCancelado)
            {
                foreach (var item in equiposSelecionados)
                {
                    item.Estado = 'D';
                    logEquipo.GetInstancia.editarEquipo(item);
                }
                equiposSelecionados.Clear();
            }
            listarEquipos();
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            prosesoCancelado = true;
            ActualizarEstadosEquipos();
            listarEquipos();
            inicializarVariablesAux();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;

            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_editar.Enabled = true;
            prosesoCancelado = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (clienteSelecionado != null && equiposSelecionados.Count > 0)
            {
                //REGISTRAR EL SERVICIO
                entServicio servicio = new entServicio
                {
                    FechaRegistro = DateTime.Now,
                    IdTipoServicio = logTipoServicio.GetInstancia.BuscarTipoPorNombre("CALIBRACION").IdTipoServicio,
                    IdCliente = clienteSelecionado.IdCliente
                };
                //entEmpleado temp = (entEmpleado)comboBox_empleado.SelectedItem;
                servicio.IdEmpleado = comboBox_empleado.SelectedIndex + 1;//temp.IdEmpleado;
                servicio.estado = 'P';//estado

                int idServicio = logServicio.GetInstancia.insertarServicio(servicio);
                servicio.IdServicio = idServicio;
                //REGISTRAR EQUIPO_SERVICIO
                foreach (var item in list_det_equipo_servicio)
                {
                    item.IdServicio = idServicio;
                    item.observaciones_finales = "";

                    logEquipo_Servicio.GetInstancia.insertarEquipoServicio(item);
                }
                //ACTUALIZAR EL EQUIPO A OCUPADO(PRESTADO)
                foreach (var item in equiposSelecionados)
                {
                    item.Estado = 'P';
                    logEquipo.GetInstancia.editarEquipo(item);
                }

                logComprobante.GetInstancia.generarComprobante(servicio, list_det_equipo_servicio, clienteSelecionado, equiposSelecionados);


                prosesoCancelado = true;
                clienteSelecionado = null;
                equiposSelecionados.Clear();

                lb_dni_ruc_cliente.Text = "DNI / RUC";
                lb_apellidos_cliente.Text = "Apellidos";
                lb_nombres_cliente.Text = "Nombres";
                lb_telefono_cliente.Text = "Telefono";

                inicializarVariablesAux();

                listarEquipos();
            }
            else
            {
                MessageBox.Show("Faltan campos por completar");
            }
        }
    }
}
