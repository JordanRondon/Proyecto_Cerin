using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using Cerin_Ingenieros.Servicios.Alquiler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preAlquiler : Form
    {
        entCliente clienteSelecionado = null;   //CLIENTE
        List<entEquipo> equiposSelecionados;    //LISTA DE EQUIPOS SELECIONADOS
        List<entEquipo_Servicio> listaDetalleEquiposServicios = new List<entEquipo_Servicio>();     //lista de equipo_servicio
        private string equipoSelecionado = "";  //EQUIPO SELECIONADO
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

        #region Configuracion formulario
        private void listarDatosComboBoxEmpleados()
        {
            comboBox_empleado.ValueMember = "id_empleado";
            comboBox_empleado.DisplayMember = "apellidoNombre";
            comboBox_empleado.DataSource = logEmpleado.GetInstancia.listarEmpleado()
                .Select(e => new
                {
                    id_empleado = e.IdEmpleado,
                    apellidoNombre = $"{e.Apellido}, {e.Nombre}" 
                })
                .ToList();
        }

        private void ConfigCabecera()
        {
            dataGridView_list_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo", Name ="Serie"},
                new DataGridViewImageColumn { HeaderText = "Editar", ImageLayout = DataGridViewImageCellLayout.Zoom, Name = "Editar"},
                new DataGridViewImageColumn { HeaderText = "Eliminar",ImageLayout = DataGridViewImageCellLayout.Zoom,Name = "Eliminar"}
            );
            dataGridView_list_equipos.Columns["Editar"].Width = 50;
            dataGridView_list_equipos.Columns["Eliminar"].Width = 80;

            foreach (DataGridViewColumn columna in dataGridView_list_equipos.Columns)
            {
                columna.HeaderCell.Style.Font = new System.Drawing.Font("Arial", 14);
            }

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_list_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
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
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entModelo modelo = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);
                entCategoria categoria = logCategoria.GetInstancia.buscarCategoriaId(item.id_categoria);
                // Obtener la imagen desde los recursos
                Image imagenEditar = Properties.Resources.editar;
                Image imagenElimnar = Properties.Resources.eliminar;
                dataGridView_list_equipos.Rows.Add(
                    categoria.Nombre,
                    marca.Nombre,
                    modelo.nombre,
                    item.SerieEquipo,
                    imagenEditar,
                    imagenElimnar
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
            btn_nuevo.BackColor = configColores.btnActivo;
            btn_cancelar.Enabled = false;
            btn_cancelar.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_cancelarObservacion.Enabled = false;
            btn_cancelarObservacion.BackColor = configColores.btDesactivado;
            btn_slect_cliente.Enabled = false;
            btn_slect_cliente.BackColor = configColores.btDesactivado;
            btn_agregar_equipo.Enabled = false;
            btn_agregar_equipo.BackColor = configColores.btDesactivado;
            btn_agregarRecomendacion.Enabled = false;
            btn_agregarRecomendacion.BackColor = configColores.btDesactivado;

            lb_dni_ruc_cliente.Text = "DNI";
            lb_nombres_cliente.Text = "Nombres";
            lb_apellidos_cliente.Text = "Apellidos";
            lb_telefono_cliente.Text = "Telefono";
            txb_ruc.Text = "RUC";
            txb_razon_social.Text = "Razon Social";

            comboBox_empleado.Enabled = false;
            dataGridView_list_equipos.Enabled = false;
            txb_Recomendaciones.Enabled = false;
        }

        private void LimpiarObservaciones()
        {
            dataGridView_Accesorios.Rows.Clear();
            txb_Recomendaciones.Enabled = false;
            txb_Recomendaciones.Text = "";
            btn_agregarRecomendacion.Enabled = false;
            btn_agregarRecomendacion.BackColor = configColores.btDesactivado;
            btn_cancelarObservacion.Enabled = false;
            btn_cancelarObservacion.BackColor = configColores.btDesactivado;
            equipoSelecionado = "";
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }
        #endregion Configuracion formulario

        #region Eventos botones
        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado!=null)
            {
                if(clienteSelecionado.Dni!="") lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                if (clienteSelecionado.Ruc != "") txb_ruc.Text = clienteSelecionado.Ruc;
                if (clienteSelecionado.Apellido != "") lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                if (clienteSelecionado.Nombre != "") lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                if (clienteSelecionado.Telefono != "") lb_telefono_cliente.Text = clienteSelecionado.Telefono;
                if (clienteSelecionado.RazonSocial != "") txb_razon_social.Text = clienteSelecionado.RazonSocial;
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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_slect_cliente.Enabled = true;
            btn_slect_cliente.BackColor = configColores.btnActivo;
            btn_agregar_equipo.Enabled = true;
            btn_agregar_equipo.BackColor = configColores.btnActivo;
            btn_guardar.Enabled = true;
            btn_guardar.BackColor = configColores.btnActivo;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;

            prosesoCancelado = true;
            comboBox_empleado.Enabled = true;
            dataGridView_list_equipos.Enabled = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (clienteSelecionado != null && equiposSelecionados.Count > 0 && comboBox_empleado.SelectedIndex!=-1)
            {
                //REGISTRAR EL SERVICIO
                entServicio servicio = new entServicio
                {
                    FechaRegistro = DateTime.Now,
                    IdTipoServicio = logTipoServicio.GetInstancia.BuscarTipoPorNombre("ALQUILER").IdTipoServicio,
                    IdCliente = clienteSelecionado.IdCliente,
                    estado = 'P',
                    estadoLaboratorio = 'V',
                    estadoPago = 'R',
                    estadoStikers = 'V'
                };
                
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

                string file = logComprobante.GetInstancia.generarComprobante(servicio, clienteSelecionado,equiposSelecionados, "");

                               

                prosesoCancelado = true;
                clienteSelecionado = null;
                equiposSelecionados.Clear();
                listaDetalleEquiposServicios.Clear();
                equipoSelecionado = "";

                lb_dni_ruc_cliente.Text = "DNI / RUC";
                lb_apellidos_cliente.Text = "Apellidos";
                lb_nombres_cliente.Text = "Nombres";
                lb_telefono_cliente.Text = "Telefono";

                txb_Recomendaciones.Text = "";

                dataGridView_Accesorios.Rows.Clear();


                listarEquipos();
                ConfiguracionInicial();

                if (file != null)
                {
                    Process.Start(file);
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por completar");
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

        private void btn_cancelarObservacion_Click(object sender, EventArgs e)
        {
            LimpiarObservaciones();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (listaDetalleEquiposServicios.Count > 0)
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

        private void dataGridView_list_equipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Obtenemos la fila selecionada
                DataGridViewRow filaActual = dataGridView_list_equipos.Rows[e.RowIndex];
                equipoSelecionado = Convert.ToString(filaActual.Cells["Serie"].Value.ToString());

                if (e.ColumnIndex == 4)
                {
                    txb_Recomendaciones.Enabled = true;

                    btn_agregarRecomendacion.Enabled = true;
                    btn_agregarRecomendacion.BackColor = configColores.btnActivo;
                    btn_cancelarObservacion.Enabled = true;
                    btn_cancelarObservacion.BackColor = configColores.btnActivo;
                }
                else if (e.ColumnIndex == 5)
                {
                    if (listaDetalleEquiposServicios.Count > 0)
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
                        return;
                    }
                }

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

                foreach (var item in listaDetalleEquiposServicios)
                {
                    if (item.serie_equipo == equipoSelecionado)
                    {
                        txb_Recomendaciones.Text = item.Observaciones_preliminares;
                    }
                }                
            }
        }
        #endregion Eventos botones


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

        private void LimpiarDGV()
        {
            dataGridView_Accesorios.Rows.Clear();
            dataGridView_Accesorios.Columns.Clear();

            dataGridView_list_equipos.Rows.Clear();
        }

        private void txb_ruc_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "RUC")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; 
            }
        }

        private void txb_ruc_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "RUC";
                textBox.ForeColor = SystemColors.GrayText; 
            }
        }

        private void txb_razon_social_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Razon social")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; 
            }
        }

        private void txb_razon_social_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Razon social";
                textBox.ForeColor = SystemColors.GrayText; 
            }
        }
    }
}
