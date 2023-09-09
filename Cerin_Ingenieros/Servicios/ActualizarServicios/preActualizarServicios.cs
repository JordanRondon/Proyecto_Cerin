using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios.ActualizarServicios
{
    public partial class preActualizarServicios : Form
    {
        private int indexEquipo = -1;
        private int indexServicio = -1;
        public preActualizarServicios()
        {
            InitializeComponent();
            ConfigCabecera();
            dataGridView_equipos.ReadOnly = true;
            dataGridView_Accesorios.ReadOnly = true;
        }

        private void limpiarTablas()
        {
            dataGridView_equipos.Rows.Clear();
            dataGridView_Accesorios.Rows.Clear();
        }

        private void limpiarEntradas()
        {
            txb_id_Servicio.Text = "";
            label_nombre_ruc_cliente.Text = "NOMBRE O RAZONSOCIAL";
            label_tipo_Servicio.Text = "TIPO";
            txb_Recomendaciones.Text = "";
            limpiarTablas();
            indexEquipo = -1;
            indexServicio = -1;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            entServicio servicioActual = logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString()));
            entCliente cliente = new entCliente();
            entTipo tipoServicio = new entTipo();

            limpiarTablas();

            if (txb_id_Servicio.Text != "" && servicioActual != null)
            {
                if (servicioActual.FechaEntrega == null)
                {
                    indexServicio = servicioActual.IdServicio;
                    cliente = logCliente.GetInstancia.buscarClienteId(servicioActual.IdCliente);
                    tipoServicio = logTipo.GetInstancia.buscarTipoServicioId(servicioActual.IdTipo);
                    if (cliente.Nombre != "")
                        label_nombre_ruc_cliente.Text = cliente.Apellido + ", " + cliente.Nombre;
                    else
                        label_nombre_ruc_cliente.Text = cliente.RazonSocial;

                    label_tipo_Servicio.Text = tipoServicio.Nombre;
                    listarEquipos(servicioActual.IdServicio);
                } else MessageBox.Show("Proceso terminado");
            }
            else
                MessageBox.Show("Código de Servicio inexistente");
        }

        private void ConfigCabecera()
        {
            dataGridView_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Codigo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );

            dataGridView_Accesorios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad" }
            );
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

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dataGridView_equipos.Rows.Add(
                    item.IdEquipo,
                    item.SerieEquipo,
                    item.Modelo,
                    estado,
                    marca.Nombre
                );
            }
        }

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //indice de la fila seccionada con doble click para
            DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];
            indexEquipo = int.Parse(filaActual.Cells[0].Value.ToString());

            List<entEquipo_Accesorio> listaAccesorios = logEquipoAccesorio.GetInstancia.ListAccsDeEquipo(indexEquipo);

            dataGridView_Accesorios.Rows.Clear();

            foreach (var item in listaAccesorios)
            {
                entAccesorio accesorio = logAccesorio.GetInstancia.BuscarAccesorioId(item.id_accesorio);

                dataGridView_Accesorios.Rows.Add(
                    accesorio.Nombre,
                    item.cantidad
                );
            }

            entEquipo equipo = logEquipo.GetInstancia.buscarEquipoID(indexEquipo);
            if (equipo.Recomendaciones != "")
            {
                txb_Recomendaciones.Text = equipo.Recomendaciones;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
        }

        private void btn_agregarRecomendacion_Click(object sender, EventArgs e)
        {
            if (indexEquipo != -1)
            {
                entEquipo equipo = logEquipo.GetInstancia.buscarEquipoID(indexEquipo);
                if (!string.IsNullOrWhiteSpace(txb_Recomendaciones.Text))
                {
                    equipo.Recomendaciones = txb_Recomendaciones.Text;
                    logEquipo.GetInstancia.editarEquipo(equipo);
                }
                else
                {
                    MessageBox.Show("Campo de Texto vacío");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un Equipo");
            }
        }

        private void btn_FinalizarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (indexServicio != -1)
                {
                    entServicio servicio = new entServicio();
                    servicio.IdServicio = indexServicio;
                    servicio.FechaEntrega = DateTime.Now;
                    if (logServicio.GetInstancia.ActualizarEntregaServicio(servicio))
                    {
                        //cambia el estado de los equipos relacionados a un servicio a D -> DISPONIBLE
                        logServicio.GetInstancia.ActualizarEstadoEquipo(servicio);
                        limpiarEntradas();
                    }
                } else MessageBox.Show("Ingresa el Código del Servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
        }
    }
}
