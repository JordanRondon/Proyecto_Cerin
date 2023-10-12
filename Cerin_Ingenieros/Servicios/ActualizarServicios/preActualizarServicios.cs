using CapaDato;
using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios.ActualizarServicios
{
    public partial class preActualizarServicios : Form
    {
        private entServicio servicioActual = new entServicio();
        private entEquipo_Servicio equipoServicio = new entEquipo_Servicio();
        private int rolUser;

        public preActualizarServicios(int rolUser)
        {
            InitializeComponent();
            this.rolUser = rolUser;
            ConfiguracionInicical();

        }
        public void ConfiguracionInicical()
        {
            limpiarEntradas();
            ConfigCabecera();
            dataGridView_equipos.ReadOnly = true;
            dataGridView_Accesorios.ReadOnly = true;
            grb_observacionesFinales.Enabled = false;
            inicializarEstados();
            //Configuracion de fecha y hora
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();

            //Configuracion inicial
            if (rolUser == 1)//admin
            {
                btn_FinalizarServicio.Visible = true;
                btnActualizar.Visible = false;
            }
            else if (rolUser == 2)//recepcionista
            {
                btn_FinalizarServicio.Visible = true;
                btnActualizar.Visible = false;
            }
            else if (rolUser == 3)//laboratorio
            {
                btn_FinalizarServicio.Visible = false;
                btnActualizar.Visible = true;
            }
        }

        private void limpiarTablas()
        {
            dataGridView_equipos.Rows.Clear();
            dataGridView_Accesorios.Rows.Clear();
        }

        private void limpiarEntradas()
        {
            txb_id_Servicio.Text = "";
            txb_id_Servicio.Enabled = true;
            label_nombre_ruc_cliente.Text = "NOMBRE O RAZONSOCIAL";
            label_tipo_Servicio.Text = "TIPO";
            txb_Recomendaciones.Text = "";
            txbFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ;
            txbFile.Visible = false;
            btnUbicacion.Visible = false;
            grb_Stikers.Visible = false;
            grb_Pagos.Visible = false;
            grb_Laboratorio.Visible = false;
            limpiarTablas();
            servicioActual = null;
            equipoServicio = null;
            grb_observacionesFinales.Enabled = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txb_id_Servicio.Text != "")
            {
                servicioActual = logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString()));
                equipoServicio = null;
                grb_observacionesFinales.Enabled = false;
                txb_Recomendaciones.Text = "";
                

                entCliente cliente = new entCliente();
                entTipoServicio tipoServicio = new entTipoServicio();

                limpiarTablas();

                if (txb_id_Servicio.Text != "" && servicioActual != null)
                {
                    if (servicioActual.FechaEntrega == null)
                    {
                        //Desactivamos el txb de id servicio para evitar cambios al momento de guardar
                        txb_id_Servicio.Enabled = false;
                        if (rolUser == 1)
                        {
                            grb_Pagos.Visible = true;
                            grb_Stikers.Visible = true;
                        }
                        else if(rolUser==3)
                        {
                            grb_Laboratorio.Visible = true;
                        }

                        txbFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        cliente = logCliente.GetInstancia.buscarClienteId(servicioActual.IdCliente);
                        tipoServicio = logTipoServicio.GetInstancia.buscarTipoServicioId(servicioActual.IdTipoServicio);
                        if (cliente.Nombre != "")
                            label_nombre_ruc_cliente.Text = cliente.Apellido + ", " + cliente.Nombre;
                        else
                            label_nombre_ruc_cliente.Text = cliente.RazonSocial;

                        label_tipo_Servicio.Text = tipoServicio.Nombre;

                        if (servicioActual.estadoLaboratorio == 'V')
                            grb_Laboratorio.Text = "Laboratorio: Terminado";
                        else if(servicioActual.estadoLaboratorio=='R')
                            grb_Laboratorio.Text = "Laboratorio: Sin solucion";
                        else
                            grb_Laboratorio.Text = "Laboratorio: Pendiente";

                        if (servicioActual.estadoPago == 'V')
                            grb_Pagos.Text = "Pago: Completo";
                        else if (servicioActual.estadoPago == 'A')
                            grb_Pagos.Text = "Pago: Parcial";
                        else
                            grb_Pagos.Text = "Pago: Sin inicial";

                        if (servicioActual.estadoStikers == 'V')
                            grb_Stikers.Text = "Stikers: Terminado";
                        else
                            grb_Stikers.Text = "Stikers: Pendiente";



                        if (tipoServicio.Nombre == "ALQUILER")
                        {
                            txbFile.Visible = false;
                            btnUbicacion.Visible = false;
                        }

                        listarEquipos(servicioActual.IdServicio);
                    }
                    else MessageBox.Show("Proceso terminado");
                }
                else
                    MessageBox.Show("Código de Servicio inexistente");
            }
        }

        private void ConfigCabecera()
        {
            dataGridView_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Serie" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView_Accesorios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad" }
            );
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_Accesorios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void listarEquipos(int id_servicio)
        {
            List<entEquipo> listaEquipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(id_servicio);

            dataGridView_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaEquipos)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entModelo modelo = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dataGridView_equipos.Rows.Add(
                    item.SerieEquipo,
                    modelo.nombre,
                    estado,
                    marca.Nombre
                );
            }
        }

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                grb_observacionesFinales.Enabled = true;

                //indice de la fila seleccionada con doble click para
                DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];
                string serieEquipo = Convert.ToString(filaActual.Cells[0].Value.ToString());
                List<entEquipo_Accesorio> listaAccesorios = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(serieEquipo);

                dataGridView_Accesorios.Rows.Clear();

                foreach (var item in listaAccesorios)
                {
                    entAccesorio accesorio = logAccesorio.GetInstancia.BuscarAccesorioId(item.id_accesorio);

                    dataGridView_Accesorios.Rows.Add(
                        accesorio.Nombre,
                        item.cantidad
                    );
                }

                equipoServicio = logEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(serieEquipo, Convert.ToInt32(txb_id_Servicio.Text.ToString()));
                txb_Recomendaciones.Text = equipoServicio.observaciones_finales;
                txbOtrosAccesorios.Text = logEquipo.GetInstancia.buscarEquipo(serieEquipo).otrosaccesorios;
                if (txb_Recomendaciones.Text != null)
                {
                    txb_Recomendaciones.Enabled = false;
                    btn_agregarRecomendacion.Enabled = false;
                    btn_editarRecomendacion.Enabled = true;
                }

            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
        }

        private void btn_agregarRecomendacion_Click(object sender, EventArgs e)
        {
            if (equipoServicio != null)
            {
                if (!string.IsNullOrWhiteSpace(txb_Recomendaciones.Text))
                {
                    equipoServicio.observaciones_finales = txb_Recomendaciones.Text;
                    logEquipo_Servicio.GetInstancia.editarEquipoServicio(equipoServicio);
                    MessageBox.Show("Observaciones Finales agregados");

                    txb_Recomendaciones.Enabled = false;
                    btn_agregarRecomendacion.Enabled = false;
                    btn_editarRecomendacion.Enabled=true;
                }
                else MessageBox.Show("Campo de Texto vacío");
            }
            else MessageBox.Show("Selecciona un Equipo");
        }

        private void btn_FinalizarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (servicioActual != null)
                {
                    List<entEquipo> listaEquipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(servicioActual.IdServicio);
                    entCliente clienteSelecionado = logCliente.GetInstancia.buscarClienteId(servicioActual.IdCliente);
                    servicioActual.FechaEntrega = DateTime.Now;
                    servicioActual.estado = 'T';

                    string file = logComprobante.GetInstancia.generarComprobante(servicioActual, clienteSelecionado, listaEquipos,"");

                    if (logServicio.GetInstancia.ActualizarEntregaServicio(servicioActual))
                    {
                        //cambia el estado de los equipos relacionados a un servicio a D -> DISPONIBLE
                        logServicio.GetInstancia.ActualizarEstadoEquipo(servicioActual);

                        if (logTipoServicio.GetInstancia.buscarTipoServicioId(servicioActual.IdTipoServicio).Nombre!="ALQUILER")
                        {
                            List<entEquipo> equipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(servicioActual.IdServicio);
                            foreach (var equipo in equipos)
                            {
                                logCertificado.GetInstancia.GenerarCerificado(equipo, DateTime.Now, txbFile.Text, servicioActual.IdServicio);
                            }
                        }

                        limpiarEntradas();
                    }
                    
                    if (file != null)
                    {
                        //preViewCertificado preView = new preViewCertificado(file);
                        //preView.Show();

                        Process.Start(file);
                    }
                } else MessageBox.Show("Ingresa el Código del Servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
            finally
            {
                btnUbicacion.Visible = true;
                txbFile.Visible = true;
            }
        }

        private void fechaHora_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_editarRecomendacion_Click(object sender, EventArgs e)
        {
            txb_Recomendaciones.Enabled = true;
            btn_agregarRecomendacion.Enabled = true;
            btn_editarRecomendacion.Enabled = false;
        }

        private void dataGridView_equipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string ruta = null;
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string carpetaSeleccionada = folderDialog.SelectedPath;
                        ruta = carpetaSeleccionada;
                    }
                }
                if (!string.IsNullOrEmpty(ruta))
                {
                    DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];
                    string serieEquipo = Convert.ToString(filaActual.Cells[0].Value.ToString());
                    entEquipo equipo = logEquipo.GetInstancia.buscarEquipo(serieEquipo);

                    string nombreDocumento = serieEquipo + ".docx";
                    string rutaCompleta = Path.Combine(ruta, nombreDocumento);

                    //logCertificado.GetInstancia.GenerarCerificado(equipo, DateTime.Now, rutaCompleta);
                }
            }
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txbFile.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void inicializarEstados()
        {
            //Estado Pagos
            grb_Pagos.Text = "Pagos: Sin Inicial";
            btn_PagosNada.BackColor = Color.Red;
            btn_PagosParcial.BackColor = Color.FromArgb(192, 64, 0);//naranja opaco
            btn_PagosTodo.BackColor = Color.Green;//verde opaco
            //------------
            //Estado Stiker
            grb_Stikers.Text = "Stikers: Nada";
            btn_StikerNada.BackColor = Color.Red;
            btn_StikerTerminado.BackColor = Color.Green;//verde opaco
            //------------
            //Estado Laboratorio
            grb_Laboratorio.Text = "Laboratorio: Pendiente";
            btn_LaboratorioSinSolucion.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
            btn_LaboratorioPendiente.BackColor = Color.FromArgb(255, 128, 0);
            btn_LaboratorioTerminado.BackColor = Color.Green;//verde opaco
            //------------
        }

        #region EstadosPagos
        private void btn_PagosNada_Click(object sender, EventArgs e)
        {
            grb_Pagos.Text = "Pago: Sin Inicial";
            btn_PagosNada.BackColor = Color.Red;
            btn_PagosParcial.BackColor = Color.FromArgb(192, 64, 0);//naranja opaco
            btn_PagosTodo.BackColor = Color.Green;//verde opaco
        }

        private void btn_PagosParcial_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar el pago en PAGO PARCIAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                grb_Pagos.Text = "Pago: Parcial";
                btn_PagosNada.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
                btn_PagosParcial.BackColor = Color.FromArgb(255, 128, 0);
                btn_PagosTodo.BackColor = Color.Green;//verde opaco
            }                
        }

        private void btn_PagosTodo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar el pago en PAGO TERMINADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                grb_Pagos.Text = "Pago: Completo";
                btn_PagosNada.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
                btn_PagosParcial.BackColor = Color.FromArgb(192, 64, 0);//naranja opaco
                btn_PagosTodo.BackColor = Color.FromArgb(0, 192, 0);
            }

                
        }
        #endregion EstadosPagos

        #region EstadosStikers
        private void btn_StikerNada_Click(object sender, EventArgs e)
        {
            grb_Stikers.Text = "Stikers: Pendiente";
            btn_StikerNada.BackColor = Color.Red;
            btn_StikerTerminado.BackColor = Color.Green;//verde opaco
        }

        private void btn_StikerTerminado_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar los estados de stikers en TERMINADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                grb_Stikers.Text = "Stikers: Terminado";
                btn_StikerNada.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
                btn_StikerTerminado.BackColor = Color.FromArgb(0, 192, 0);
            }
        }
        #endregion EstadosStikers

        #region EstadosLaboratorio
        private void btn_LaboratorioSinSolucion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar el SERCICIO como TERMINADO SIN SOLUCION?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                grb_Laboratorio.Text = "Laboratorio: Sin Solición";
                btn_LaboratorioSinSolucion.BackColor = Color.Red;
                btn_LaboratorioPendiente.BackColor = Color.FromArgb(192, 64, 0);//naranja opaco
                btn_LaboratorioTerminado.BackColor = Color.Green;//verde opaco
            }
                
        }

        private void btn_LaboratorioPendiente_Click(object sender, EventArgs e)
        {
            grb_Laboratorio.Text = "Laboratorio: Pendiente";
            btn_LaboratorioSinSolucion.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
            btn_LaboratorioPendiente.BackColor = Color.FromArgb(255, 128, 0);
            btn_LaboratorioTerminado.BackColor = Color.Green;//verde opaco
        }

        private void btn_LaboratorioTerminado_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar EL SERVICIO como TERMINADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                grb_Laboratorio.Text = "Laboratorio: Terminado";
                btn_LaboratorioSinSolucion.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
                btn_LaboratorioPendiente.BackColor = Color.FromArgb(192, 64, 0);//naranja opaco
                btn_LaboratorioTerminado.BackColor = Color.FromArgb(0, 192, 0);
            }
                
        }
        #endregion EstadosLaboratorio
    }
}
