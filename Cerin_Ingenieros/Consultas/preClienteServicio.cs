using CapaDato;
using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios;
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


namespace Cerin_Ingenieros.Consultas
{
    public partial class preClienteServicio : Form
    {
        private entCliente clienteSelecionado = null;
        private int id_servicio = -1;
        private entServicio servicioSelect = null;

        public preClienteServicio()
        {
            InitializeComponent();
            ConfigCabecera();
        }

        private void limpiarTablas()
        {
            dataGridView_equipos.Rows.Clear();
            dataGridView_Accesorios.Rows.Clear();
        }

        private void limpiarTextBox()
        {
            txb_Observaciones.Text = "";
            txb_Recomendaciones.Text = "";
        }

        private void limpiarEntradas()
        {
            lb_nombreCliente.Text = "Nombres:";
            lb_dni_cliente.Text = "DNI:";

            lb_nombre_razonSocial.Text = "Cliente o Razón Social";
            lb_dni_ruc.Text = "DNI o RUC";
            lb_nombreEmpleado.Text = "Nombre";
            limpiarTextBox();
            limpiarTablas();
        }

        private void ConfigCabecera()
        {
            dataGridView_servicios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Código" },
                new DataGridViewTextBoxColumn { HeaderText = "Fecha de Registro" },
                new DataGridViewTextBoxColumn { HeaderText = "Fecha de Entrega" },
                new DataGridViewTextBoxColumn { HeaderText = "Tipo Servicio" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Comprobante"}
            );
            dataGridView_servicios.Columns[0].Width = 60;
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_servicios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Instrumento" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie" },
                new DataGridViewTextBoxColumn { HeaderText = "modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" },
                //new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Certificado"}
            );
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView_Accesorios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad" }
            );
            dataGridView_Accesorios.Columns[1].Width = 80;
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_Accesorios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        public void listarServicios()
        {
            List<entServicio> listaServicios = logServicio.GetInstancia.listarServicioCliente(clienteSelecionado.IdCliente);

            dataGridView_servicios.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaServicios)
            {
                string estado;
                if (item.estado == 'P') estado = "Pendiente";
                else estado = "Terminado";

                dataGridView_servicios.Rows.Add(
                    item.IdServicio,
                    item.FechaRegistro,
                    item.FechaEntrega,
                    logTipoServicio.GetInstancia.buscarTipoServicioId(item.IdTipoServicio).Nombre,
                    estado,
                    "Descargar"
                );
            }
        }

        public void listarEquipos(DataGridViewRow filaActual)
        {
            List<entEquipo> listaEquipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(int.Parse(filaActual.Cells[0].Value.ToString()));

            dataGridView_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaEquipos)
            {
                //string estado = null;
                entCategoria categoriaEquipo = logCategoria.GetInstancia.buscarCategoriaId(item.id_categoria);
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entModelo modelo = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);
                string certif = "";
                if (logTipoServicio.GetInstancia.buscarTipoServicioId(servicioSelect.IdTipoServicio).Nombre != "ALQUILER")
                {
                    certif = "DESCARGAR";
                }
                else
                    certif = "No disponible";

                dataGridView_equipos.Rows.Add(
                    categoriaEquipo.Nombre,
                    item.SerieEquipo,
                    modelo.nombre,
                    marca.Nombre,
                    //estado,
                    certif
                );
            }
        }

        public void listarAccesorios(DataGridViewRow filaActual)
        {
            string serieEquipo = filaActual.Cells[1].Value.ToString();
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

            entEquipo_Servicio equipoServicio = logEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(serieEquipo, id_servicio);
            txb_Observaciones.Text = equipoServicio.Observaciones_preliminares;
            txb_Recomendaciones.Text = equipoServicio.observaciones_finales;
        }

        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
            preSeleccionarCliente preSeleccionarCliente = new preSeleccionarCliente();
            preSeleccionarCliente.ShowDialog();

            clienteSelecionado = preSeleccionarCliente.getCliente();

            if (clienteSelecionado != null)
            {

                if (clienteSelecionado.Dni != null)
                {
                    lb_nombreCliente.Text = "Nombres:";
                    lb_dni_cliente.Text = "DNI:";
                    lb_nombre_razonSocial.Text = clienteSelecionado.Nombre.ToString() + ' ' + clienteSelecionado.Apellido.ToString();
                    lb_dni_ruc.Text = clienteSelecionado.Dni.ToString();
                }
                else
                {
                    lb_nombreCliente.Text = "Razón Social:";
                    lb_dni_cliente.Text = "RUC:";
                    lb_nombre_razonSocial.Text = clienteSelecionado.RazonSocial.ToString();
                    lb_dni_ruc.Text = clienteSelecionado.Ruc.ToString();
                }
                listarServicios();
            }
        }

        private void dataGridView_servicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView_Accesorios.Rows.Clear();
                limpiarTextBox();

                DataGridViewRow filaActual = dataGridView_servicios.Rows[e.RowIndex];
                id_servicio = int.Parse(filaActual.Cells[0].Value.ToString());

                servicioSelect = logServicio.GetInstancia.buscarServicio(id_servicio);
                int idEmpleado = servicioSelect.IdEmpleado;
                entEmpleado empleado = logEmpleado.GetInstancia.BuscarEmpleadoId(idEmpleado);
                lb_nombreEmpleado.Text = empleado.Nombre + ' ' + empleado.Apellido;

                listarEquipos(filaActual);
            }
        }

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];
                listarAccesorios(filaActual);
                string serieEquipo = filaActual.Cells[1].Value.ToString();
                txbOtrosAccesorios.Text = logEquipo.GetInstancia.buscarEquipo(serieEquipo).otrosaccesorios;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView_servicios.Rows.Clear();
            limpiarEntradas();
        }

        private void dataGridView_equipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                entTipoServicio tiposervicio = logTipoServicio.GetInstancia.buscarTipoServicioId(servicioSelect.IdTipoServicio);
                if (servicioSelect.estado == 'T' && tiposervicio.Nombre != "ALQUILER")
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

                    if (!string.IsNullOrEmpty(ruta) && servicioSelect.FechaEntrega != null)
                    {
                        DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];
                        string serieEquipo = Convert.ToString(filaActual.Cells[1].Value.ToString());
                        entEquipo equipo = logEquipo.GetInstancia.buscarEquipo(serieEquipo);
                        DateTime fentrega = (DateTime)servicioSelect.FechaEntrega;
                        DateTime date = fentrega;


                        //string nombreDocumento = serieEquipo+".docx";
                        //string rutaCompleta = Path.Combine(ruta, nombreDocumento);

                        string path = logCertificado.GetInstancia.GenerarCerificado(equipo, date, ruta, servicioSelect.IdServicio);

                        if (path != null)
                        {
                            Process.Start(path);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona una carpeta antes de guardar el documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (tiposervicio.Nombre == "ALQUILER" && e.ColumnIndex == 5) MessageBox.Show("No se puede, el servicio es de alquiler");
                    else if (servicioSelect.estado != 'T' && e.ColumnIndex == 5) MessageBox.Show("El servicio aun no termina");
                }
            }
        }

        private void dataGridView_servicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                DataGridViewRow filaActual = dataGridView_servicios.Rows[e.RowIndex];
                id_servicio = int.Parse(filaActual.Cells[0].Value.ToString());

                servicioSelect = logServicio.GetInstancia.buscarServicio(id_servicio);
            }
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
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
                    List<entEquipo> equipos = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(servicioSelect.IdServicio);
                    string src = logComprobante.GetInstancia.generarComprobante(servicioSelect, clienteSelecionado, equipos, ruta);

                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una carpeta antes de guardar el documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
