using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios.Alquiler;
using Cerin_Ingenieros.Servicios.ViewCertificado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preAlquiler : Form
    {
        entCliente clienteSelecionado = null;   //Cliente selecionado para el servicio
        List<entEquipo> equiposSelecionados;    //lista de equipoas para alquiler
        List<entEquipo_Servicio> listaDetalleEquiposServicios = new List<entEquipo_Servicio>();     //lista de equipo_servicio
        private string equipoSelecionado = "";
        bool prosesoCancelado = true;           //control de si el proseso se cancelo



        public preAlquiler()
        {
            InitializeComponent();
            listarDatosComboBoxEmpleados();

            ConfiguracionInicial();

            ConfigCabecera();
            listarEquipos();
            comboBox_empleado.DropDownStyle = ComboBoxStyle.DropDownList;//comboBox solo lectura
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
            dataGridView_list_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_list_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            equiposSelecionados = logEquipo.GetInstancia.listarEquipoAlquiler();
            equiposSelecionados = new List<entEquipo>();


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
            dataGridView_list_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in equiposSelecionados)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);

                if (item.Estado == 'D') estado = "Disponible";
                else if (item.Estado == 'U') estado = "Usando ahora";
                else estado = "Ocupado";
                dataGridView_list_equipos.Rows.Add(
                    item.SerieEquipo,
                    item.id_modelo,
                    estado,
                    marca.Nombre
                );
            }
        }

        private void ConfiguracionInicial()
        {
            //Configuracion de fecha y hora
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();

            //Configuracion inicial
            btn_nuevo.Enabled = true;
            btn_cancelar.Enabled = false;
            btn_guardar.Enabled = false;
            //btn_editar.Enabled = false;
            btn_Delete.Enabled = false;
            btn_cancelarObservacion.Enabled = false;

            lb_dni_ruc_cliente.Text = "DNI";
            lb_nombres_cliente.Text = "Nombres";
            lb_apellidos_cliente.Text = "Apellidos";
            lb_telefono_cliente.Text = "Telefono";

            btn_slect_cliente.Enabled = false;
            btn_agregar_equipo.Enabled = false;
            comboBox_empleado.Enabled = false;
            dataGridView_list_equipos.Enabled = false;
            dataGridView_Accesorios.Enabled = false;
            txb_Recomendaciones.Enabled = false;
            btn_agregarRecomendacion.Enabled = false;
        }

        //Botones
        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado!=null)
            {
                lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                txb_ruc.Text = clienteSelecionado.Ruc;
                lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                lb_telefono_cliente.Text = clienteSelecionado.Telefono;
                txb_razon_social.Text = clienteSelecionado.RazonSocial;
            }

        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            //abrir ventana para selecionar equipos
            preSelectEquipoAlquiler preSelectEquipo = new preSelectEquipoAlquiler();
            preSelectEquipo.ShowDialog();

            //obtenemos equipos selecionados
            equiposSelecionados.AddRange(preSelectEquipo.getEquipos());

            //detalle_equipo_servicio
            
            foreach(var equipo in equiposSelecionados)
            {
                entEquipo_Servicio equipo_Servicio = new entEquipo_Servicio();
                equipo_Servicio.serie_equipo = equipo.SerieEquipo;
                equipo_Servicio.Observaciones_preliminares = "";
                equipo_Servicio.observaciones_finales = "";
                listaDetalleEquiposServicios.Add(equipo_Servicio);
            }

            listarEquipos();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void preAlquiler_FormClosing(object sender, FormClosingEventArgs e)
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
            ConfiguracionInicial();
            LimpiarDGV();

            //reiniciar variables
            prosesoCancelado = true;
            clienteSelecionado = null;
            equiposSelecionados.Clear();
            listaDetalleEquiposServicios.Clear();
            equiposSelecionados.Clear();
            equipoSelecionado = "";
        }
        private void LimpiarDGV()
        {
            dataGridView_Accesorios.Rows.Clear();
            dataGridView_Accesorios.Columns.Clear();

            dataGridView_list_equipos.Rows.Clear();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_slect_cliente.Enabled = true;
            btn_agregar_equipo.Enabled = true;
            comboBox_empleado.Enabled = true;
            dataGridView_list_equipos.Enabled = true;

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
                    IdTipoServicio = logTipoServicio.GetInstancia.BuscarTipoPorNombre("ALQUILER").IdTipoServicio,
                    IdCliente = clienteSelecionado.IdCliente,
                    estado = 'P'
                };
                //entEmpleado temp = (entEmpleado)comboBox_empleado.SelectedItem;
                servicio.IdEmpleado = Convert.ToInt16(comboBox_empleado.SelectedValue);//temp.IdEmpleado;

                int idServicio = logServicio.GetInstancia.insertarServicio(servicio);
                servicio.IdServicio = idServicio;

                //Actualizar equipo_servicio
                foreach (var item in listaDetalleEquiposServicios)
                {
                    item.IdServicio = idServicio;
                    logEquipo_Servicio.GetInstancia.insertarEquipoServicio(item);
                }
                foreach (var equipo in equiposSelecionados)
                {
                    //ACTUALIZAR EL EQUIPO A OCUPADO(PRESTADO)
                    equipo.Estado = 'O';
                    logEquipo.GetInstancia.editarEquipo(equipo);
                }

                string file = logComprobante.GetInstancia.generarComprobante(servicio, clienteSelecionado,equiposSelecionados);

                               

                prosesoCancelado = true;
                clienteSelecionado = null;
                equiposSelecionados.Clear();
                listaDetalleEquiposServicios.Clear();
                equipoSelecionado = "";

                lb_dni_ruc_cliente.Text = "DNI / RUC";
                lb_apellidos_cliente.Text = "Apellidos";
                lb_nombres_cliente.Text = "Nombres";
                lb_telefono_cliente.Text = "Telefono";


                listarEquipos();
                ConfiguracionInicial();

                if (file != null)
                {
                    //preViewCertificado preView = new preViewCertificado(file);
                    //preView.Show();

                    Process.Start(file);
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por completar");
            }
        }

        private void txb_ruc_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "RUC")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; // Cambia el color de texto al predeterminado
            }
        }

        private void txb_ruc_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "RUC";
                textBox.ForeColor = SystemColors.GrayText; // Cambia el color de texto a gris
            }
        }

        private void txb_razon_social_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Razon social")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; // Cambia el color de texto al predeterminado
            }
        }

        private void txb_razon_social_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Razon social";
                textBox.ForeColor = SystemColors.GrayText; // Cambia el color de texto a gris
            }
        }

        private void dataGridView_list_equipos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Obtenemos la fila selecionada
                DataGridViewRow filaActual = dataGridView_list_equipos.Rows[e.RowIndex];
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
                foreach (var item in listaDetalleEquiposServicios)
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

        private void btn_agregarRecomendacion_Click(object sender, EventArgs e)
        {
            foreach (var item in listaDetalleEquiposServicios)
            {
                if (item.serie_equipo == equipoSelecionado)
                {
                    item.Observaciones_preliminares = txb_Recomendaciones.Text;
                }
            }

            //limpiamos 
            LimpiarObservaciones();
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

        private void btn_cancelarObservacion_Click(object sender, EventArgs e)
        {
            LimpiarObservaciones();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            foreach (var item in listaDetalleEquiposServicios)
            {
                if (item.serie_equipo == equipoSelecionado)
                {
                    listaDetalleEquiposServicios.Remove(item);
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
    }
}
