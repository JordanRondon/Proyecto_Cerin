
// --------------------------------------------------------------
// Nombre del archivo: preClienteServicio.cs
// Descripción: Clase que gestiona la el historial de servicios 
//              de un cliente.
// --------------------------------------------------------------

using CapaDato;
using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using Cerin_Ingenieros.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Consultas
{
    public partial class preClienteServicio : Form
    {
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private entCliente clienteSeleccionado = null;
        private entServicio servicioSelecccionado = null;
        private readonly List<entTipoServicio> listaTipoServicios;
        private readonly List<entAccesorio> listaAccesorios;

        // --------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------
        public preClienteServicio()
        {
            InitializeComponent();
            ConfigCabecera();
            listaTipoServicios = logTipoServicio.GetInstancia.listarTipoServicios();
            listaAccesorios = logAccesorio.GetInstancia.listarAccesorio();
        }

        /// <summary>
        /// Limpia las tablas de equipos y accesorios en la interfaz.
        /// </summary>
        private void LimpiarTablas()
        {
            dataGridView_equipos.Rows.Clear();
            dataGridView_Accesorios.Rows.Clear();
        }

        /// <summary>
        /// Limpia los cuadros de texto en la interfaz.
        /// </summary>
        private void LimpiarTextBox()
        {
            txb_Observaciones.Text = "";
            txb_Recomendaciones.Text = "";
            txbOtrosAccesorios.Text = "";
        }

        /// <summary>
        /// Limpia todas las entradas en la interfaz.
        /// </summary>
        private void limpiarEntradas()
        {
            lb_nombreCliente.Text = "Nombres:";
            lb_dni_cliente.Text = "DNI:";
            lb_nombre_razonSocial.Text = "Cliente o Razón Social";
            lb_dni_ruc.Text = "DNI o RUC";
            lb_nombreEmpleado.Text = "Nombre";
            LimpiarTextBox();
            LimpiarTablas();
        }

        /// <summary>
        /// Configura la cabecera de las tablas en la interfaz.
        /// </summary>
        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dataGridView_servicios,
                new string[] { "Código", "Fecha de Registro", "Fecha de Entrega", "Tipo Servicio", "Estado", "Comprobante" });
            dgvConfiguracion.ConfigurarColumnas(dataGridView_equipos, 
                new string[] { "Instrumento", "Serie", "modelo", "Marca", "Certificado" });
            dgvConfiguracion.ConfigurarColumnas(dataGridView_Accesorios, 
                new string[] { "Nombre", "Cantidad" });
        }

        /// <summary>
        /// Lista los servicios asociados al cliente en la interfaz.
        /// </summary>
        public void ListarServicios()
        {
            List<entServicio> listaServicios = logServicio.GetInstancia.listarServicioCliente(clienteSeleccionado.IdCliente);
            dataGridView_servicios.Rows.Clear();            

            foreach (var servicio in listaServicios)
            {
                string estado = (servicio.estado == 'P') ? "Pendiente" : "Terminado";
                entTipoServicio tipoServicio = listaTipoServicios.FirstOrDefault(tipo => tipo.IdTipoServicio == servicio.IdTipoServicio);

                dataGridView_servicios.Rows.Add(
                    servicio.IdServicio,
                    servicio.FechaRegistro,
                    servicio.FechaEntrega,
                    tipoServicio.Nombre,
                    estado,
                    "Descargar"
                );
            }
        }

        /// <summary>
        /// Lista los equipos asociados a un servicio en la interfaz.
        /// </summary>
        /// <param name="servicioId">codigo del servicio.</param>
        public void ListarEquipos(int servicioId)
        {
            List<entEquipo> listaEquipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(servicioId);
            dataGridView_equipos.Rows.Clear();
 
            foreach (var equipo in listaEquipos)
            {
                entMarca marca;
                entModelo modelo;
                entCategoria categoria;

                (categoria, marca, modelo) = logEquipo.GetInstancia.datosCompledoDeEquipoPorId(equipo.SerieEquipo);

                entTipoServicio tipoServicio = listaTipoServicios.FirstOrDefault(tipo => tipo.IdTipoServicio == servicioSelecccionado.IdTipoServicio);
                string certif = (tipoServicio.Nombre != "ALQUILER") ? "DESCARGAR" : "No disponible";

                dataGridView_equipos.Rows.Add(
                    categoria.Nombre,
                    equipo.SerieEquipo,
                    modelo.nombre,
                    marca.Nombre,
                    certif
                );
            }
        }

        /// <summary>
        /// Lista los accesorios asociados a un equipo en la interfaz.
        /// </summary>
        /// <param name="serieEquipo">Serie del equipo.</param>
        public void ListarAccesorios(string serieEquipo)
        {
            List<entEquipo_Accesorio> listaEquipoAccesorios = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(serieEquipo);
            dataGridView_Accesorios.Rows.Clear();

            foreach (var equipoAccesorio in listaEquipoAccesorios)
            {
                entAccesorio accesorio = listaAccesorios.FirstOrDefault(tipo => tipo.IdAccesorio == equipoAccesorio.id_accesorio);
                
                dataGridView_Accesorios.Rows.Add(
                    accesorio.Nombre,
                    equipoAccesorio.cantidad
                );
            }            
        }

        /// <summary>
        /// Lista los detalles del equipo y sus accesorios en la interfaz.
        /// </summary>
        /// <param name="serieEquipo">Serie del equipo.</param>
        /// <param name="otrosAccesorios">Otros accesorios del equipo.</param>
        private void ListarDatosDelEquipo(string serieEquipo, string otrosAccesorios)
        {
            
            entEquipo_Servicio equipoServicio = logEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(serieEquipo, servicioSelecccionado.IdServicio);
            txb_Observaciones.Text = equipoServicio.Observaciones_preliminares;
            txb_Recomendaciones.Text = equipoServicio.observaciones_finales;
            txbOtrosAccesorios.Text = otrosAccesorios;
        }

        #region Eventos
        /// <summary>
        /// Maneja el evento de clic en el botón para seleccionar un cliente.
        /// </summary>
        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
            preSeleccionarCliente ventanaSeleccionCliente = new preSeleccionarCliente();
            ventanaSeleccionCliente.ShowDialog();
            clienteSeleccionado = ventanaSeleccionCliente.getCliente();

            if (clienteSeleccionado != null)
            {
                string tipoIdentificacion = !string.IsNullOrEmpty(clienteSeleccionado.Dni) ? "DNI" : "RUC";
                bool esRuc = !string.IsNullOrEmpty(clienteSeleccionado.Ruc);
                lb_nombreCliente.Text = esRuc ? "Razón Social:" : "Nombres:";

                lb_dni_cliente.Text = tipoIdentificacion + ":";

                lb_nombre_razonSocial.Text = esRuc ?clienteSeleccionado.RazonSocial: $"{clienteSeleccionado.Nombre}, {clienteSeleccionado.Apellido}";

                lb_dni_ruc.Text = esRuc ? clienteSeleccionado.Ruc.ToString() : clienteSeleccionado.Dni.ToString();

                ListarServicios();
            }
        }
        /// <summary>
        /// Maneja el evento de clic en el botón para limpiar la interfaz.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView_servicios.Rows.Clear();
            limpiarEntradas();
        }

        /// <summary>
        /// Maneja el evento de clic en una celda de la tabla de equipos.
        /// </summary>
        private void dataGridView_equipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];
                    string serieEquipo = filaActual.Cells["Serie"].Value.ToString();

                    entEquipo equipo = logEquipo.GetInstancia.buscarEquipo(serieEquipo);

                    ListarDatosDelEquipo(serieEquipo, equipo.otrosaccesorios);
                    ListarAccesorios(serieEquipo);

                    if (e.ColumnIndex == 4)
                    {
                        entTipoServicio tipoServicio = listaTipoServicios.FirstOrDefault(tipo => tipo.IdTipoServicio == servicioSelecccionado.IdTipoServicio);

                        if (servicioSelecccionado.estado == 'T' && tipoServicio.Nombre != "ALQUILER")
                        {
                            string ruta = ClassValidaciones.SelecionarCarpeta();

                            if (!string.IsNullOrEmpty(ruta) && servicioSelecccionado.FechaEntrega != null)
                            {
                                DateTime fentrega = (DateTime)servicioSelecccionado.FechaEntrega;

                                string path = logCertificado.GetInstancia.GenerarCerificado(equipo, fentrega, ruta, servicioSelecccionado.IdServicio);

                                if (path != null)
                                {
                                    ClassValidaciones.AbrirDocumento(path);
                                }
                            }
                            else
                            {
                                Mensajes.MensajeError("Ruta no valida");
                            }
                        }
                        else
                        {
                            if (tipoServicio.Nombre == "ALQUILER" && e.ColumnIndex == 4) Mensajes.MensajeGeneral("No se puede, el servicio es de alquiler");
                            else if (servicioSelecccionado.estado != 'T' && e.ColumnIndex == 4) Mensajes.MensajeGeneral("El servicio aun no termina");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensajes.MensajeError("Se produjo un error");
            }            
        }

        /// <summary>
        /// Maneja el evento de clic en una celda de la tabla de servicios.
        /// </summary>
        private void dataGridView_servicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView_Accesorios.Rows.Clear();
                LimpiarTextBox();
                DataGridViewRow filaActual = dataGridView_servicios.Rows[e.RowIndex];                
                servicioSelecccionado = logServicio.GetInstancia.buscarServicio(int.Parse(filaActual.Cells[0].Value.ToString()));

                int idEmpleado = servicioSelecccionado.IdEmpleado;
                entEmpleado empleado = logEmpleado.GetInstancia.BuscarEmpleadoId(idEmpleado);

                lb_nombreEmpleado.Text = empleado.Nombre + ' ' + empleado.Apellido;
                ListarEquipos(servicioSelecccionado.IdServicio);

                if (e.ColumnIndex == 5)
                {
                    string ruta = ClassValidaciones.SelecionarCarpeta();

                    if (!string.IsNullOrEmpty(ruta))
                    {
                        List<entEquipo> equipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(servicioSelecccionado.IdServicio);
                        string src = logComprobante.GetInstancia.generarComprobante(servicioSelecccionado, clienteSeleccionado, equipos, ruta);
                        ClassValidaciones.AbrirCarpeta(ruta);
                    }
                }
            }
            
        }
        #endregion Eventos
    }
}
