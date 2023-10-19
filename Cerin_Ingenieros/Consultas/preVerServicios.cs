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
            //TamColumnas();
            //foreach (DataGridViewColumn column in dgvServicios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        //private void TamColumnas()
        //{
        //    dgvServicios.Columns["ID"].Width = 40;
        //    dgvServicios.Columns["FechaRegistro"].Width = 80;
        //    dgvServicios.Columns["FechaEntrega"].Width = 80;
        //    dgvServicios.Columns["Tipo"].Width = 85;
        //    //dgvServicios.Columns["Pago"].Width = 80;
        //    //dgvServicios.Columns["Stikers"].Width = 80;
        //    //dgvServicios.Columns["Laboratorio"].Width = 80;
        //    //dgvServicios.Columns["Estado"].Width = 80;
        //}

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
                dgvServicios.Columns[columnName].Width = 120;
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

            dgvServicios.Rows.Clear();
            listarServicios(listaServiciosGeneral);
            dgvServicios.Invalidate();
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.DodgerBlue; 
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);

            dgvServicios.Rows.Clear();
            List<entServicio> lista = logServicio.GetInstancia.listarServiciosPendientes();
            listarServicios(lista);
            dgvServicios.Invalidate();
        }

        private void btnFinalizados_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0); 
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.DodgerBlue;

            dgvServicios.Rows.Clear();
            List<entServicio> lista = logServicio.GetInstancia.listarServiciosTerminados();
            listarServicios(lista);
            dgvServicios.Invalidate();
        }

        private void btnSinSolucion_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void dgvServicios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string estadoPago = dgvServicios.Rows[e.RowIndex].Cells["Pago"].Value.ToString();
                string estadoStiker = dgvServicios.Rows[e.RowIndex].Cells["Stikers"].Value.ToString();
                string estadoLab = dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Value.ToString();
                string estado = dgvServicios.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                Color colorCompleto = Color.LimeGreen;
                Color colorParcial = Color.Yellow;
                Color colorPendiente = Color.Red;

                //pago
                if (estadoPago == "Completo")
                    dgvServicios.Rows[e.RowIndex].Cells["Pago"].Style.BackColor = colorCompleto;
                else if (estadoPago == "Parcial")
                    dgvServicios.Rows[e.RowIndex].Cells["Pago"].Style.BackColor = colorParcial;
                else
                    dgvServicios.Rows[e.RowIndex].Cells["Pago"].Style.BackColor = colorPendiente;

                //Stiker
                if (estadoStiker == "Completo")
                    dgvServicios.Rows[e.RowIndex].Cells["Stikers"].Style.BackColor = colorCompleto;
                else
                    dgvServicios.Rows[e.RowIndex].Cells["Stikers"].Style.BackColor = colorParcial;

                //Laboratorio
                if (estadoLab == "Terminado")
                    dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Style.BackColor = colorCompleto;
                else if (estadoLab == "Pendiente")
                    dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Style.BackColor = colorParcial;
                else
                    dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Style.BackColor = colorPendiente;

                if (estado == "Terminado")
                    dgvServicios.Rows[e.RowIndex].Cells["Estado"].Style.BackColor = colorCompleto;
                else
                    dgvServicios.Rows[e.RowIndex].Cells["Estado"].Style.BackColor = colorParcial;
            }
        }

    }
}
