using CapaDato;
using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        public preActualizarServicios(int rolUser,string id_servicio)
        {
            InitializeComponent();
            this.rolUser = rolUser;
            ConfiguracionInicical();
            txb_id_Servicio.Text = id_servicio;
            btn_Buscar_Click(this, new EventArgs());
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
                btn_FinalizarServicio.BackColor = configColores.btnActivo;
            }
            else if (rolUser == 2)//recepcionista
            {
                btn_FinalizarServicio.Visible = true;
                btn_FinalizarServicio.BackColor = configColores.btnActivo;
            }
            else if (rolUser == 3)//laboratorio
            {
                btn_FinalizarServicio.Visible = false;
                btn_FinalizarServicio.BackColor = configColores.btDesactivado;
            }
            ConfigEstadosInicial();
        }

        private void ConfigEstadosInicial()
        {
            btn_StikerNada.Enabled = true;
            btn_StikerTerminado.Enabled = true;

            btn_PagosNada.Enabled = true;
            btn_PagosParcial.Enabled = true;
            btn_PagosTodo.Enabled = true;

            btn_LaboratorioPendiente.Enabled = true;
            btn_LaboratorioSinSolucion.Enabled = true;
            btn_LaboratorioTerminado.Enabled = true;
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
            btn_Buscar.Enabled = true;
            btn_Buscar.BackColor = configColores.btnActivo;
            btn_agregarRecomendacion.Enabled = false;
            btn_agregarRecomendacion.BackColor = configColores.btDesactivado;
            btn_editarRecomendacion.Enabled |= false;
            btn_editarRecomendacion.BackColor = configColores.btDesactivado;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txb_id_Servicio.Text != "")
            {
                servicioActual = logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString()));
                equipoServicio = null;
                grb_observacionesFinales.Enabled = false;
                txb_Recomendaciones.Text = "";
                ConfigEstadosInicial();

                entCliente cliente = new entCliente();
                entTipoServicio tipoServicio = new entTipoServicio();

                limpiarTablas();
                if (servicioActual != null)
                {
                    if (servicioActual.FechaEntrega == null)
                    {
                        //Desactivamos el txb de id servicio para evitar cambios al momento de guardar
                        txb_id_Servicio.Enabled = false;
                        btn_Buscar.Enabled = false;
                        btn_Buscar.BackColor = configColores.btDesactivado;

                        switch (rolUser)
                        {
                            case 1:
                                grb_Pagos.Visible = true;
                                if (servicioActual.IdTipoServicio != 1)
                                    grb_Stikers.Visible = true;
                                break;
                            case 2:
                                if (servicioActual.IdTipoServicio != 1)
                                    grb_Stikers.Visible = true;
                                break;
                            case 3:
                                if (servicioActual.IdTipoServicio != 1)
                                {
                                    grb_Stikers.Visible = true;
                                    grb_Laboratorio.Visible = true;
                                }
                                break;
                        }

                        txbFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        cliente = logCliente.GetInstancia.buscarClienteId(servicioActual.IdCliente);
                        tipoServicio = logTipoServicio.GetInstancia.buscarTipoServicioId(servicioActual.IdTipoServicio);
                        if (cliente.Ruc != "")
                            label_nombre_ruc_cliente.Text = cliente.RazonSocial;
                        else
                            label_nombre_ruc_cliente.Text = cliente.Apellido + ", " + cliente.Nombre;


                        label_tipo_Servicio.Text = tipoServicio.Nombre;

                        //cargando estados
                        if (servicioActual.estadoLaboratorio == 'V')
                        {
                            grb_Laboratorio.Text = "Laboratorio: Terminado";
                            btn_LaboratorioPendiente.Enabled = false;
                            btn_LaboratorioSinSolucion.Enabled = false;
                            LabTerminado();
                        }
                        else if (servicioActual.estadoLaboratorio == 'R')
                        {
                            grb_Laboratorio.Text = "Laboratorio: Sin solucion";
                            btn_LaboratorioPendiente.Enabled = false;
                            btn_LaboratorioTerminado.Enabled = false;
                            LabSinSolucion();
                        }
                        else
                        {
                            grb_Laboratorio.Text = "Laboratorio: Pendiente";
                            LabPendiente();
                        }

                        if (servicioActual.estadoPago == 'V')
                        {
                            grb_Pagos.Text = "Pago: Completo";
                            btn_PagosNada.Enabled = false;
                            btn_PagosParcial.Enabled = false;
                            pagoCompleto();
                        }
                        else if (servicioActual.estadoPago == 'A')
                        {
                            grb_Pagos.Text = "Pago: Parcial";
                            btn_PagosNada.Enabled = false;
                            PagoParcial();
                        }
                        else
                        {
                            grb_Pagos.Text = "Pago: Sin inicial";
                            PagoNada();
                        }

                        if (servicioActual.estadoStikers == 'V')
                        {
                            grb_Stikers.Text = "Stikers: Terminado";
                            btn_StikerNada.Enabled = false;
                            StikersTerminado();
                        }
                        else
                        {
                            grb_Stikers.Text = "Stikers: Pendiente";
                            StikersNada();
                        }

                        if (tipoServicio.Nombre == "ALQUILER")
                        {
                            txbFile.Visible = false;
                            btnUbicacion.Visible = false;
                        }
                        else
                        {
                            txbFile.Visible = true;
                            btnUbicacion.Visible = true;
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
            dgvConfiguracion.ConfigurarColumnas(dataGridView_equipos,
                new string[] { "Serie", "Modelo", "Estado", "Marca"});

            dgvConfiguracion.ConfigurarColumnas(dataGridView_Accesorios,
                new string[] { "Nombre", "Cantidad" });
            dataGridView_Accesorios.Columns["Cantidad"].Width = 80;
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
                    btn_agregarRecomendacion.BackColor = configColores.btDesactivado;
                    btn_editarRecomendacion.Enabled=true;
                    btn_editarRecomendacion.BackColor = configColores.btnActivo;
                }
                else MessageBox.Show("Campo de Texto vacío");
            }
            else MessageBox.Show("Selecciona un Equipo");
        }

        private void btn_FinalizarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (servicioActual != null && (servicioActual.estadoLaboratorio == 'V' || servicioActual.estadoLaboratorio == 'R') && servicioActual.estadoStikers=='V' && servicioActual.estadoPago=='V')
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
                        Process.Start(file);
                    }
                }
                else
                {
                    if (servicioActual == null) MessageBox.Show("Servicio no encontrado");
                    else if(servicioActual.estadoLaboratorio == 'A' ) MessageBox.Show("Aun no sale de laboratorio");
                    else if(servicioActual.estadoStikers != 'V') MessageBox.Show("Stikers pendientes aun");
                    else if(servicioActual.estadoPago != 'V') MessageBox.Show("Pagos pendientes");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
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
            btn_agregarRecomendacion.BackColor = configColores.btnActivo;
            btn_editarRecomendacion.Enabled = false;
            btn_editarRecomendacion.BackColor = configColores.btDesactivado;
        }

        private void dataGridView_equipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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
                txb_RecomendacionesPreliminares.Text = equipoServicio.Observaciones_preliminares;
                txbOtrosAccesorios.Text = logEquipo.GetInstancia.buscarEquipo(serieEquipo).otrosaccesorios;
                if (txb_Recomendaciones.Text != null)
                {
                    txb_Recomendaciones.Enabled = false;
                    btn_agregarRecomendacion.Enabled = false;
                    btn_agregarRecomendacion.BackColor = configColores.btDesactivado;
                    btn_editarRecomendacion.Enabled = true;
                    btn_editarRecomendacion.BackColor = configColores.btnActivo;
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
            PagoNada();
        }
        private void PagoNada()
        {
            grb_Pagos.Text = "Pago: Sin Inicial";
            btn_PagosNada.Enabled = false;
            btn_PagosNada.BackColor = Color.Red;
            btn_PagosParcial.BackColor = Color.FromArgb(210, 210, 0);//amarillo oscuro
            btn_PagosTodo.BackColor = Color.FromArgb(0, 153, 30);//verde oscuro
        }

        private void btn_PagosParcial_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar el pago en PAGO PARCIAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PagoParcial();
                servicioActual.estadoPago = 'A';
                logServicio.GetInstancia.ActualizarEstadoServicio(servicioActual);

            }                
        }
        private void PagoParcial()
        {
            grb_Pagos.Text = "Pago: Parcial";
            btn_PagosNada.Enabled = false;
            btn_PagosParcial.Enabled = false;
            btn_PagosParcial.BackColor = Color.Yellow;
            btn_PagosNada.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
            btn_PagosTodo.BackColor = Color.FromArgb(0, 153, 30);//verde oscuro
        }

        private void btn_PagosTodo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar el pago en PAGO TERMINADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                pagoCompleto();
                servicioActual.estadoPago = 'V';
                logServicio.GetInstancia.ActualizarEstadoServicio(servicioActual);
            }                
        }

        private void pagoCompleto()
        {
            grb_Pagos.Text = "Pago: Completo";
            btn_PagosNada.Enabled = false;
            btn_PagosParcial.Enabled = false;
            btn_PagosTodo.Enabled = false;
            btn_PagosParcial.BackColor = Color.FromArgb(210, 210, 0);//amarillo oscuro
            btn_PagosNada.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco;
            btn_PagosTodo.BackColor = Color.FromArgb(0, 192, 0);
        }
        #endregion EstadosPagos

        #region EstadosStikers
        private void btn_StikerNada_Click(object sender, EventArgs e)
        {
            StikersNada();
        }

        private void StikersNada()
        {
            grb_Stikers.Text = "Stikers: Pendiente";
            btn_StikerNada.Enabled = false;
            btn_StikerNada.BackColor = Color.Red;
            btn_StikerTerminado.BackColor = Color.FromArgb(0, 153, 30);//verde oscuro
        }

        private void btn_StikerTerminado_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar los estados de stikers en TERMINADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StikersTerminado();
                servicioActual.estadoStikers = 'V';
                logServicio.GetInstancia.ActualizarEstadoServicio(servicioActual);
            }
        }

        private void StikersTerminado()
        {
            grb_Stikers.Text = "Stikers: Terminado";
            btn_StikerNada.Enabled = false;
            btn_StikerTerminado.Enabled = false;
            btn_StikerTerminado.BackColor = Color.FromArgb(0, 192, 0);
            btn_StikerNada.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco;
        }
        #endregion EstadosStikers

        #region EstadosLaboratorio
        private void btn_LaboratorioSinSolucion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar el SERCICIO como TERMINADO SIN SOLUCION?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LabSinSolucion();
                servicioActual.estadoLaboratorio = 'R';
                logServicio.GetInstancia.ActualizarEstadoServicio(servicioActual);
            }
                
        }

        private void LabSinSolucion()
        {
            grb_Laboratorio.Text = "Laboratorio: Sin Solición";
            btn_LaboratorioSinSolucion.Enabled = false;
            btn_LaboratorioPendiente.Enabled = false;
            btn_LaboratorioTerminado.Enabled = false;

            btn_LaboratorioSinSolucion.BackColor = Color.Red;
            btn_LaboratorioPendiente.BackColor = Color.FromArgb(210, 210, 0);
            btn_LaboratorioTerminado.BackColor = Color.FromArgb(0, 153, 30);//verde oscuro
        }

        private void btn_LaboratorioPendiente_Click(object sender, EventArgs e)
        {
            LabPendiente();
        }

        private void LabPendiente()
        {
            grb_Laboratorio.Text = "Laboratorio: Pendiente";
            btn_LaboratorioPendiente.Enabled= false;
            btn_LaboratorioSinSolucion.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco
            btn_LaboratorioPendiente.BackColor = Color.Yellow;
            btn_LaboratorioTerminado.BackColor = Color.FromArgb(0, 153, 30);//verde oscuro
        }

        private void btn_LaboratorioTerminado_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Actualizar EL SERVICIO como TERMINADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LabTerminado();
                servicioActual.estadoLaboratorio = 'V';
                logServicio.GetInstancia.ActualizarEstadoServicio(servicioActual);
            }
                
        }
        private void LabTerminado()
        {
            grb_Laboratorio.Text = "Laboratorio: Terminado";
            btn_LaboratorioSinSolucion.Enabled = false;
            btn_LaboratorioPendiente.Enabled = false;
            btn_LaboratorioTerminado.Enabled = false;

            btn_LaboratorioSinSolucion.BackColor = Color.FromArgb(192, 0, 0);//rojo opaco;
            btn_LaboratorioPendiente.BackColor = Color.FromArgb(210,210, 0);//amarillo oscuro
            btn_LaboratorioTerminado.BackColor = Color.FromArgb(0, 192, 0);//verde claro
        }
        #endregion EstadosLaboratorio

        private void btn_LaboratorioTerminado_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("LABORATORIO TERMINADO", btn_LaboratorioTerminado);
        }

        private void btn_LaboratorioPendiente_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("LABORATORIO TERMINADO", btn_LaboratorioPendiente);
        }

        private void btn_LaboratorioSinSolucion_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("LABORATORIO TERMINADO", btn_LaboratorioSinSolucion);
        }

        private void btn_PagosParcial_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("PAGO PARCIAL", btn_PagosParcial);
        }

        private void btn_PagosTodo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("PAGO COMPLETO", btn_PagosTodo);
        }

        private void btn_PagosNada_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("SIN PAGO INICIAL", btn_PagosTodo);
        }

        private void btn_StikerTerminado_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("STIKERS COMPLETOS", btn_StikerTerminado);
        }

        private void btn_StikerNada_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("SIN STIKERS", btn_StikerNada);
        }
    }
}
