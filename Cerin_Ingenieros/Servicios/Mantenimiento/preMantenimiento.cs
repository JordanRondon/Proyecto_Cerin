using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios.Alquiler;
using Cerin_Ingenieros.Servicios.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private string equipoSelecionado = "";
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

            dataGridView_Accesorios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad" }
            );
            dataGridView_Accesorios.Columns[1].Width = 90;
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_Accesorios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

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
        private void LimpiarDGV()
        {
            dataGridView_Accesorios.Rows.Clear();
            dataGridView_Accesorios.Columns.Clear();

            dataGridView_lista_quipos.Rows.Clear();
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

            lb_dni_ruc_cliente.Text = "DNI";
            lb_nombres_cliente.Text = "Nombres";
            lb_apellidos_cliente.Text = "Apellidos";
            lb_telefono_cliente.Text = "Telefono";

            LimpiarObservaciones();
            dataGridView_Accesorios.Enabled = false;
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
                    item.Estado = 'E';
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
            LimpiarDGV();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;

            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_cancelar.Enabled = true;
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
                servicio.IdEmpleado = Convert.ToInt16(comboBox_empleado.SelectedValue); //temp.IdEmpleado;
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

                string file = logComprobante.GetInstancia.generarComprobante(servicio, clienteSelecionado, equiposSelecionados);

                if (file != null)
                {
                    //preViewCertificado preView = new preViewCertificado(file);
                    //preView.Show();

                    Process.Start(file);
                }

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

        private void dataGridView_lista_quipos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Obtenemos la fila selecionada
                DataGridViewRow filaActual = dataGridView_lista_quipos.Rows[e.RowIndex];
                equipoSelecionado = Convert.ToString(filaActual.Cells[0].Value.ToString());

                //Buscamos la lista de accesorios yla cantidad de un equipo X
                List<entEquipo_Accesorio> listaAccesorios = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(equipoSelecionado);

                dataGridView_Accesorios.Rows.Clear();

                //mostramos el accesorio
                foreach (var item in listaAccesorios)
                {
                    entAccesorio accesorio = logAccesorio.GetInstancia.BuscarAccesorioId(item.id_accesorio);

                    dataGridView_Accesorios.Rows.Add(
                        accesorio.Nombre,
                        item.cantidad
                    );
                }
                txb_Recomendaciones.Enabled = true;
                foreach (var item in list_det_equipo_servicio)
                {
                    if (item.serie_equipo == equipoSelecionado)
                    {
                        txb_Recomendaciones.Text = item.Observaciones_preliminares;
                    }
                }
                btn_agregarRecomendacion.Enabled = true;
                btn_cancelarObservacion.Enabled = true;
                dataGridView_Accesorios.Enabled = true;
                btn_Delete.Enabled = true;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            foreach (var item in list_det_equipo_servicio)
            {
                if (item.serie_equipo == equipoSelecionado)
                {
                    list_det_equipo_servicio.Remove(item);
                    break;
                }
            }
            foreach (var item in equiposSelecionados)
            {
                if (item.SerieEquipo == equipoSelecionado)
                {
                    equiposSelecionados.Remove(item);
                    item.Estado = 'D';
                    logEquipo.GetInstancia.editarEquipo(item);
                    break;
                }
            }
            LimpiarObservaciones();
            listarEquipos();
        }
        private void LimpiarObservaciones()
        {
            dataGridView_Accesorios.Rows.Clear();
            dataGridView_Accesorios.Enabled = false;
            txb_Recomendaciones.Enabled = false;
            txb_Recomendaciones.Text = "";
            btn_agregarRecomendacion.Enabled = false;
            btn_cancelarObservacion.Enabled = false;
            btn_Delete.Enabled = false;
            equipoSelecionado = "";
        }

        private void btn_agregarRecomendacion_Click(object sender, EventArgs e)
        {
            foreach (var item in list_det_equipo_servicio)
            {
                if (item.serie_equipo == equipoSelecionado)
                {
                    item.Observaciones_preliminares = txb_Recomendaciones.Text;
                }
            }

            //limpiamos 
            LimpiarObservaciones();
        }

        private void btn_cancelarObservacion_Click(object sender, EventArgs e)
        {
            LimpiarObservaciones();
        }
    }
}
