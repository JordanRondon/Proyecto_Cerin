using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Properties;
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
    public partial class preVerServicios : Form
    {
        List<entServicio> listaServiciosGeneral = logServicio.GetInstancia.listarServicios();

        //Temprales

        public delegate void pasar(string id_servicio);
        public event pasar pasado;

        public preVerServicios()
        {
            InitializeComponent();
            ConfigurarCabecera();

            btnTodosTipos_Click(this, EventArgs.Empty);
        }
        public void ConfigurarCabecera()
        {
            dgvServicios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "ID" ,Name = "ID"},
                new DataGridViewTextBoxColumn { HeaderText = "Fecha de registro", Name = "FechaRegistro" },
                new DataGridViewTextBoxColumn { HeaderText = "Fecha de entrega", Name = "FechaEntrega" },
                new DataGridViewTextBoxColumn { HeaderText = "Tipo servicio", Name = "Tipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Cliente", Name = "Cliente" },
                new DataGridViewImageColumn { HeaderText = "Pago", Name = "Pago",ImageLayout = DataGridViewImageCellLayout.Zoom },
                new DataGridViewImageColumn { HeaderText = "Stikers", Name = "Stikers", ImageLayout = DataGridViewImageCellLayout.Zoom },
                new DataGridViewImageColumn { HeaderText = "Laboratorio", Name = "Laboratorio", ImageLayout = DataGridViewImageCellLayout.Zoom },
                new DataGridViewImageColumn { HeaderText = "Estado", Name = "Estado", ImageLayout = DataGridViewImageCellLayout.Zoom }
            );

            dgvServicios.Columns["ID"].Width = 40;
            dgvServicios.Columns["Pago"].Width = 51;
            dgvServicios.Columns["Stikers"].Width = 50;
            dgvServicios.Columns["Laboratorio"].Width = 50;
            dgvServicios.Columns["Estado"].Width = 73;
            dgvServicios.Columns["FechaRegistro"].Width = 165;
            dgvServicios.Columns["FechaEntrega"].Width = 165;
            dgvServicios.Columns["Tipo"].Width = 130;

            foreach (DataGridViewColumn column in dgvServicios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private Image ObtenerEstadoEnImage(char estado, string columnName)
        {
            Dictionary<char, Image> EstadosImagenes = new Dictionary<char, Image>
            {
                {'V', Resources.Verde},
                {'A', Resources.Amarillo},
                {'R', Resources.Rojo},
                {'P', Resources.Amarillo },
                {'T', Resources.Verde},
            };

            Image image = Resources.Amarillo;

            if (EstadosImagenes.ContainsKey(estado))
            {
                //dgvServicios.Columns[columnName].Width = 120;
                image = EstadosImagenes[estado];
                if (estado == 'V' || estado == 'T') image.Tag = "Completo";
                else if (estado == 'A' || estado == 'P') image.Tag = "Pendiente";
                else if (estado == 'R' ) image.Tag = "Ausente";
                return image;
            }
            return image;
        }

        private void listarServicios(List<entServicio> lista)
        {
            dgvServicios.Rows.Clear();

            //insertar los datos 
            foreach (var item in lista)
            {
                string fechasalida;
                
                if (item.FechaEntrega == null)
                    fechasalida = "Pendiente";
                else
                {
                    DateTime fechaaux = (DateTime)item.FechaEntrega;
                    fechasalida = fechaaux.ToString("dd-MM-yyyy HH:mm");
                }

                Image estadoPago = ObtenerEstadoEnImage(item.estadoPago, "Pago");
                Image estadoStiker = ObtenerEstadoEnImage(item.estadoStikers, "Stikers");
                Image estadoLab = ObtenerEstadoEnImage(item.estadoLaboratorio, "Laboratorio");
                Image estado = ObtenerEstadoEnImage(item.estado, "Estado");

                entCliente cliente = logCliente.GetInstancia.buscarClienteId(item.IdCliente);
                dgvServicios.Rows.Add(
                    item.IdServicio,
                    item.FechaRegistro.ToString("dd-MM-yyyy HH:mm"),
                    fechasalida,
                    logTipoServicio.GetInstancia.buscarTipoServicioId(item.IdTipoServicio).Nombre,
                    cliente.Apellido + ", " + cliente.Nombre,
                    estadoPago,
                    estadoStiker,
                    estadoLab,
                    estado
                );
            }

        }

        private void btnTodosTipos_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.DodgerBlue;
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);

            //dgvServicios.Rows.Clear();
            listarServicios(listaServiciosGeneral);
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.DodgerBlue;
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);

            //dgvServicios.Rows.Clear();
            List<entServicio> lista = logServicio.GetInstancia.listarServiciosPendientes();
            listarServicios(lista);
        }

        private void btnFinalizados_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0); 
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.DodgerBlue;

            //dgvServicios.Rows.Clear();
            List<entServicio> lista = logServicio.GetInstancia.listarServiciosTerminados();
            listarServicios(lista);
        }

        private void btnSinSolucion_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                string cadena = dgvServicios.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                pasado(cadena);
            }
        }
    }
}
