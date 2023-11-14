using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Consultas
{
    public partial class preHistorialEquipo : Form
    {

        private readonly List<entAccesorio> listaaccesorios;
        public preHistorialEquipo()
        {
            InitializeComponent();
            listaaccesorios = logAccesorio.GetInstancia.listarAccesorio();
            ConfigCabecera();
            dataGridView_servicios.ReadOnly = true;
            dataGridView_Accesorios.ReadOnly = true;
        }

        private void limpiarTablas()
        {
            dataGridView_servicios.Rows.Clear();
            dataGridView_Accesorios.Rows.Clear();
        }

        private void limpiarTextBox()
        {
            txb_Observaciones.Text = "";
            txb_Recomendaciones.Text = "";
        }

        private void limpiarDatosCliente()
        {
            lb_nombre_razonSocial.Text = "Cliente o Razón Social";
            lb_dni_ruc.Text = "DNI o RUC";
            lb_telefono.Text = "Número";
        }

        private void limpiarEntradas()
        {
            limpiarDatosCliente();

            lb_nombreCliente.Text = "Nombres:";
            lb_dni_cliente.Text = "DNI:";

            lb_categoria_equipo.Text = "Nombre";
            lb_serie.Text = "Serie";
            lb_marca.Text = "Marca";
            lb_modelo.Text = "Modelo";
            lb_estadoEquipo.Text = "Estado";

            //lb_nombreEmpleado.Text = "Nombre";

            txb_serie_equipo.Text = "";

            limpiarTextBox();
            limpiarTablas();
        }

        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dataGridView_servicios,
                new string[] { "Código", "cha de Registro", "Fecha de Entrega", "Tipo Servicio", "Estado" });

            dgvConfiguracion.ConfigurarColumnas(dataGridView_Accesorios,
                new string[] { "Nombre", "Cantidad" });
            dataGridView_Accesorios.Columns["Cantidad"].Width = 80;
        }

        private void listarServicio()
        {
            List<entServicio> listaServicios = logServicio.GetInstancia.listarServicioEquipo(txb_serie_equipo.Text);

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
                    estado
                );
            }
        }

        public void listarAccesorios()
        {
            List<entEquipo_Accesorio> listaDetalleAccesorios = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(txb_serie_equipo.Text);

            dataGridView_Accesorios.Rows.Clear();

            foreach (var item in listaDetalleAccesorios)
            {
                entAccesorio accesorio = listaaccesorios.FirstOrDefault(tipo => tipo.IdAccesorio == item.id_accesorio);

                dataGridView_Accesorios.Rows.Add(
                    accesorio.Nombre,
                    item.cantidad
                );
            }
        }

        private void mostrarDatosCliente(entCliente cliente)
        {
            if (cliente.Dni != null)
            {
                lb_nombreCliente.Text = "Nombres:";
                lb_dni_cliente.Text = "DNI:";
                lb_nombre_razonSocial.Text = cliente.Nombre.ToString() + ' ' + cliente.Apellido.ToString();
                lb_dni_ruc.Text = cliente.Dni.ToString();
            }
            else
            {
                lb_nombreCliente.Text = "Razón Social:";
                lb_dni_cliente.Text = "RUC:";
                lb_nombre_razonSocial.Text = cliente.RazonSocial.ToString();
                lb_dni_ruc.Text = cliente.Ruc.ToString();
            }
            lb_telefono.Text = cliente.Telefono.ToString();
        }

        private void mostrarDatosEquipo(entEquipo equipo)
        {
            lb_categoria_equipo.Text = logCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria).Nombre;
            lb_serie.Text = equipo.SerieEquipo;
            lb_modelo.Text = logModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo).nombre;
            lb_marca.Text = logMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca).Nombre;
            string estado = null;
            switch (equipo.Estado)
            {
                case 'D': estado = "Disponible"; break;
                case 'O': estado = "Ocupado"; break;
                case 'P': estado = "En Proceso"; break;
                case 'E': estado = "Entregado"; break;
                case 'S': estado = "Eliminado"; break;
                case 'U': estado = "En Uso"; break;
            }
            lb_estadoEquipo.Text = estado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txb_serie_equipo.Text))
            {
                limpiarDatosCliente();

                listarServicio();
                listarAccesorios();
                entEquipo equipo = logEquipo.GetInstancia.buscarEquipo(txb_serie_equipo.Text.Replace(" ", ""));
                if (equipo != null)
                    mostrarDatosEquipo(equipo);
                else MessageBox.Show("El equipo con serie " + txb_serie_equipo.Text.Replace(" ", "") + " no se encontro");
            }
        }

        private void dataGridView_servicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dataGridView_servicios.Rows[e.RowIndex];

                int idServicio = Convert.ToInt32(filaActual.Cells[0].Value.ToString());
                entEquipo_Servicio equipoServicio = logEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(txb_serie_equipo.Text, idServicio);
                entServicio servicio = logServicio.GetInstancia.buscarServicio(idServicio);
                entCliente cliente = logCliente.GetInstancia.buscarClienteId(servicio.IdCliente);
                entEmpleado empleado = logEmpleado.GetInstancia.BuscarEmpleadoId(servicio.IdEmpleado);

                mostrarDatosCliente(cliente);

                txb_Observaciones.Text = equipoServicio.Observaciones_preliminares;
                txb_Recomendaciones.Text = equipoServicio.observaciones_finales;
            }
        }
    }
}
