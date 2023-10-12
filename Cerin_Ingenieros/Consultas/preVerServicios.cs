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

namespace Cerin_Ingenieros.Consultas
{
    public partial class preVerServicios : Form
    {
        public preVerServicios()
        {
            InitializeComponent();
            ConfigurarCabecera();
            List<entServicio> listaServicios = logServicio.GetInstancia.listarServicios();
            listarServicios(listaServicios);
            btnTodosDias.BackColor = Color.DodgerBlue;
            btnTodosTipos.BackColor = Color.DodgerBlue;
        }
        public void ConfigurarCabecera()
        {
            dgvServicios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "ID" ,Name = "ID"},
                new DataGridViewTextBoxColumn { HeaderText = "Fecha de Registro", Name = "FechaRegistro" },
                new DataGridViewTextBoxColumn { HeaderText = "Fecha de Entrega", Name = "FechaEntrega" },
                new DataGridViewTextBoxColumn { HeaderText = "Tipo Servicio", Name = "Tipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Cliente", Name = "Cliente" },
                new DataGridViewTextBoxColumn { HeaderText = "Pago", Name = "Pago" },
                new DataGridViewTextBoxColumn { HeaderText = "Stikers", Name = "Stikers" },
                new DataGridViewTextBoxColumn { HeaderText = "Laboratorio", Name = "Laboratorio" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado", Name = "Estado" }
            );
            dgvServicios.Columns["ID"].Width = 60;
            dgvServicios.Columns["FechaRegistro"].Width = 140;
            dgvServicios.Columns["FechaEntrega"].Width = 140;
            dgvServicios.Columns["Tipo"].Width = 130;
            foreach (DataGridViewColumn column in dgvServicios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void listarServicios(List<entServicio> lista)
        {
            dgvServicios.Rows.Clear();
            //insertar los datos 
            foreach (var item in lista)
            {
                string estado,estadodelPago,estadoStikers,estadoLab,fechasalida;
                if (item.estado == 'P') estado = "Pendiente";
                else estado = "Terminado";
                if (item.FechaEntrega == null)
                    fechasalida = "Pendiente";
                else
                {
                    DateTime fechaaux = (DateTime)item.FechaEntrega;
                    fechasalida = fechaaux.ToString("dd-MM-yyyy HH:mm");
                }

                if (item.estadoPago == 'V')
                    estadodelPago = "Completo";
                else if (item.estadoPago == 'A')
                    estadodelPago = "Parcial";
                else estadodelPago = "Pendiente";

                if (item.estadoStikers == 'V')
                    estadoStikers = "Completo";
                else estadoStikers = "Pendiente";

                if (item.estadoLaboratorio == 'V')
                    estadoLab = "Terminado";
                else if (item.estadoLaboratorio == 'A')
                    estadoLab = "Pendiente";
                else estadoLab = "Sin solucion";

                entCliente cliente = logCliente.GetInstancia.buscarClienteId(item.IdCliente);
                dgvServicios.Rows.Add(
                    item.IdServicio,
                    item.FechaRegistro.ToString("dd-MM-yyyy HH:mm"),
                    fechasalida,
                    logTipoServicio.GetInstancia.buscarTipoServicioId(item.IdTipoServicio).Nombre,
                    cliente.Apellido + ", " + cliente.Nombre,
                    estadodelPago,
                    estadoStikers,
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
            btnSinSolucion.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.DodgerBlue; 
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);
            btnSinSolucion.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btnFinalizados_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0); 
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.DodgerBlue;
            btnSinSolucion.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btnSinSolucion_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);
            btnSinSolucion.BackColor = Color.DodgerBlue;
        }

        private void btnTodosDias_Click(object sender, EventArgs e)
        {
            btnTodosDias.BackColor = Color.DodgerBlue;
            btnHoy.BackColor = Color.FromArgb(255, 128, 0);
            btnUltimaSemana.BackColor = Color.FromArgb(255, 128, 0);
            btnUltimoMes.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            btnTodosDias.BackColor = Color.FromArgb(255, 128, 0);
            btnHoy.BackColor = Color.DodgerBlue;
            btnUltimaSemana.BackColor = Color.FromArgb(255, 128, 0);
            btnUltimoMes.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btnUltimaSemana_Click(object sender, EventArgs e)
        {
            btnTodosDias.BackColor = Color.FromArgb(255, 128, 0);
            btnHoy.BackColor = Color.FromArgb(255, 128, 0);
            btnUltimaSemana.BackColor = Color.DodgerBlue;
            btnUltimoMes.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btnUltimoMes_Click(object sender, EventArgs e)
        {
            btnTodosDias.BackColor = Color.FromArgb(255, 128, 0);
            btnHoy.BackColor = Color.FromArgb(255, 128, 0);
            btnUltimaSemana.BackColor = Color.FromArgb(255, 128, 0);
            btnUltimoMes.BackColor = Color.DodgerBlue;
        }

        private void dgvServicios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
                    dgvServicios.Rows[e.RowIndex].Cells["Stikers"].Style.BackColor = colorPendiente;

                //Laboratorio
                if (estadoLab == "Terminado")
                    dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Style.BackColor = colorCompleto;
                else if (estadoLab == "Pendiente")
                    dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Style.BackColor = colorParcial;
                else
                    dgvServicios.Rows[e.RowIndex].Cells["Laboratorio"].Style.BackColor = colorPendiente;

                if (estado == "Terminado")
                    dgvServicios.Rows[e.RowIndex].Cells["Stikers"].Style.BackColor = colorCompleto;
                else
                    dgvServicios.Rows[e.RowIndex].Cells["Stikers"].Style.BackColor = colorPendiente;
            }
        }
    }
}
