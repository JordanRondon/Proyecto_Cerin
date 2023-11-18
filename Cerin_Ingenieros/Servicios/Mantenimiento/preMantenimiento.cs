using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preMantenimiento : Form
    {
        entCliente clienteSelecionado = null;
        List<entEquipo> equiposSelecionados;
        List<entEquipo_Servicio> list_det_equipo_servicio = new List<entEquipo_Servicio>();
        private List<entAccesorio> listaaccesorios;
        private string equipoSelecionado = "";
        bool prosesoCancelado = true;

        public preMantenimiento()
        {
            InitializeComponent();
            listaaccesorios = logAccesorio.GetInstancia.listarAccesorio();
            ConfiguracionInicial();
            ConfigCabecera();
            listarDatosComboBoxEmpleados();

            //reiniciar variables
            prosesoCancelado = true;
            clienteSelecionado = null;
            equiposSelecionados.Clear();
            list_det_equipo_servicio.Clear();
            equiposSelecionados.Clear();
            equipoSelecionado = "";
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
                new DataGridViewTextBoxColumn { HeaderText = "Equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo", Name = "Serie" },
                new DataGridViewImageColumn { HeaderText = "Editar", ImageLayout = DataGridViewImageCellLayout.Zoom, Name = "Editar" },
                new DataGridViewImageColumn { HeaderText = "Eliminar", ImageLayout = DataGridViewImageCellLayout.Zoom, Name = "Eliminar" }
            );
            dataGridView_lista_quipos.Columns["Editar"].Width = 50;
            dataGridView_lista_quipos.Columns["Eliminar"].Width = 80;

            foreach (DataGridViewColumn columna in dataGridView_lista_quipos.Columns)
            {
                columna.HeaderCell.Style.Font = new System.Drawing.Font("Arial", 14);
            }

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_lista_quipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            equiposSelecionados = new List<entEquipo>();

            dgvAcesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "Opcion",Name="Opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre", ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true }
            );
            dgvAcesorios.Columns[0].Width = 50;
            dgvAcesorios.Columns[2].Width = 80;

            foreach (DataGridViewColumn column in dgvAcesorios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void listarEquipos()
        {
            dataGridView_lista_quipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in equiposSelecionados)
            {
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entModelo modelo = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);
                entCategoria categoria = logCategoria.GetInstancia.buscarCategoriaId(item.id_categoria);
                // Obtener la imagen desde los recursos
                Image imagenEditar = Properties.Resources.editar;
                Image imagenElimnar = Properties.Resources.eliminar;
                dataGridView_lista_quipos.Rows.Add(
                    categoria.Nombre,
                    marca.Nombre,
                    modelo.nombre,
                    item.SerieEquipo,
                    imagenEditar,
                    imagenElimnar
                );
            }
        }
        private void LimpiarDGV()
        {
            dgvAcesorios.Rows.Clear();
            dgvAcesorios.Columns.Clear();

            dataGridView_lista_quipos.Rows.Clear();
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
            dataGridView_lista_quipos.Enabled = false;
            txb_Recomendaciones.Enabled = false;

            LimpiarObservaciones();
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
                if (clienteSelecionado.Dni != "") lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                if (clienteSelecionado.Ruc != "") txb_ruc.Text = clienteSelecionado.Ruc;
                if (clienteSelecionado.Apellido != "") lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                if (clienteSelecionado.Nombre != "") lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                if (clienteSelecionado.Telefono != "") lb_telefono_cliente.Text = clienteSelecionado.Telefono;
                if (clienteSelecionado.RazonSocial != "") txb_razon_social.Text = clienteSelecionado.RazonSocial;
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
            ConfiguracionInicial();
            LimpiarDGV();
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

            comboBox_empleado.Enabled = true;
            dataGridView_lista_quipos.Enabled = true;
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
                    IdCliente = clienteSelecionado.IdCliente,
                    estado = 'P',
                    estadoLaboratorio = 'A',
                    estadoPago = 'R',
                    estadoStikers = 'A'
                };
                
                servicio.IdEmpleado = Convert.ToInt16(comboBox_empleado.SelectedValue); //temp.IdEmpleado;
                

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

                string file = logComprobante.GetInstancia.generarComprobante(servicio, clienteSelecionado, equiposSelecionados, "");

                if (file != null)
                {
                    Process.Start(file);
                }

                prosesoCancelado = true;
                clienteSelecionado = null;
                equiposSelecionados.Clear();

                lb_dni_ruc_cliente.Text = "DNI / RUC";
                lb_apellidos_cliente.Text = "Apellidos";
                lb_nombres_cliente.Text = "Nombres";
                lb_telefono_cliente.Text = "Telefono";

                txb_Recomendaciones.Text = "";

                dgvAcesorios.Rows.Clear();

                ConfiguracionInicial();
                listarEquipos();
            }
            else
            {
                MessageBox.Show("Faltan campos por completar");
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
            dgvAcesorios.Rows.Clear();
            txb_Recomendaciones.Enabled = false;
            txb_Recomendaciones.Text = "";
            txbOtrosAccesorios.Enabled = false;
            txbOtrosAccesorios.Text = "";
            btn_agregarRecomendacion.Enabled = false;
            btn_agregarRecomendacion.BackColor = configColores.btDesactivado;
            btn_cancelarObservacion.Enabled = false;
            btn_cancelarObservacion.BackColor = configColores.btDesactivado;
            equipoSelecionado = "";
        }

        private void btn_agregarRecomendacion_Click(object sender, EventArgs e)
        {
            //ACTUALIZACION DE LAS OBSERVACIONES PRELIMINARES
            foreach (var item in list_det_equipo_servicio)
            {
                if (item.serie_equipo == equipoSelecionado)
                {
                    item.Observaciones_preliminares = txb_Recomendaciones.Text;
                }
            }
            //ACTUALIZACION DE OTROS ACCESORIOS
            foreach (var item in equiposSelecionados)
            {
                if (item.SerieEquipo == equipoSelecionado)
                {
                    item.otrosaccesorios = txbOtrosAccesorios.Text;
                }
            }
            //ELIMINAR DE LA BD EQUIPOACCESORIOS
            logEquipo.GetInstancia.EliminarequipoAccesorio(equipoSelecionado);

            //insertar los accesorios del equipo
            entEquipo_Accesorio det_equipo_Accesorio = new entEquipo_Accesorio
            {
                SerieEquipo = equipoSelecionado
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

            //limpiamos 
            LimpiarObservaciones();
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

        private void btn_cancelarObservacion_Click(object sender, EventArgs e)
        {
            LimpiarObservaciones();
        }

        private void dataGridView_lista_quipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Obtenemos la fila selecionada
                DataGridViewRow filaActual = dataGridView_lista_quipos.Rows[e.RowIndex];
                equipoSelecionado = Convert.ToString(filaActual.Cells["Serie"].Value.ToString());
                //Buscamos la lista de accesorios yla cantidad de un equipo X
                List<entEquipo_Accesorio> listaAccesorios = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(equipoSelecionado);

                if (e.ColumnIndex == 4)
                {
                    txb_Recomendaciones.Enabled = true;
                    txbOtrosAccesorios.Enabled = true;
                    btn_agregarRecomendacion.Enabled = true;
                    btn_agregarRecomendacion.BackColor = configColores.btnActivo;
                    btn_cancelarObservacion.Enabled = true;
                    btn_cancelarObservacion.BackColor = configColores.btnActivo;
                    dgvAcesorios.Enabled = true;

                    //EDITAR ACCESORIOS
                    //obtenemos todos los accesorios
                    dgvAcesorios.Rows.Clear();
                    foreach (var item in listaaccesorios)
                    {
                        string cantidad = "";
                        bool estado = false;
                        foreach (var ac in listaAccesorios)
                        {
                            if (item.IdAccesorio==ac.id_accesorio)
                            {
                                estado = true;
                                cantidad = ac.cantidad.ToString();
                                break;
                            }
                        }
                        dgvAcesorios.Rows.Add(
                            estado,
                            item.Nombre,
                            cantidad
                        );
                    }
                    foreach (DataGridViewRow fila in dgvAcesorios.Rows)
                    {
                        DataGridViewCheckBoxCell checkBoxCell = fila.Cells[0] as DataGridViewCheckBoxCell;
                        DataGridViewCell cantidadCell = fila.Cells[2];

                        if (checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                        {
                            cantidadCell.ReadOnly = false;
                        }
                        else
                        {
                            cantidadCell.ReadOnly = true;
                        }
                    }

                    dgvAcesorios.Columns[0].Visible = true;

                }
                else if (e.ColumnIndex == 5)
                {
                    if (list_det_equipo_servicio.Count > 0)
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
                                item.Estado = 'E';
                                logEquipo.GetInstancia.editarEquipo(item);
                                break;
                            }
                        }
                        LimpiarObservaciones();
                        listarEquipos();
                        return;
                    }
                }
                else
                {
                    dgvAcesorios.Rows.Clear();
                    //mostramos el accesorio
                    foreach (var item in listaAccesorios)
                    {
                        entAccesorio accesorio = logAccesorio.GetInstancia.BuscarAccesorioId(item.id_accesorio);

                        dgvAcesorios.Rows.Add(
                            true,
                            accesorio.Nombre,
                            item.cantidad
                        );
                    }
                    dgvAcesorios.Columns[0].Visible = false;
                }                

                foreach (var item in list_det_equipo_servicio)
                {
                    if (item.serie_equipo == equipoSelecionado)
                    {
                        txb_Recomendaciones.Text = item.Observaciones_preliminares;
                    }
                }

                foreach (var item in equiposSelecionados)
                {
                    if (item.SerieEquipo == equipoSelecionado)
                    {
                        txbOtrosAccesorios.Text = item.otrosaccesorios;
                    }
                }
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
    }
}
