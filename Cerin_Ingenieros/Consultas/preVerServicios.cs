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
        List<entServicio> listaServiciosGeneral = logServicio.GetInstancia.listarServicios();
        public preVerServicios()
        {
            InitializeComponent();
            ConfigurarCabecera();
            
            listarServicios(listaServiciosGeneral);
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
            dgvServicios.Columns["ID"].Width = 40;
            dgvServicios.Columns["FechaRegistro"].Width = 75;
            dgvServicios.Columns["FechaEntrega"].Width = 75;
            dgvServicios.Columns["Tipo"].Width = 65;
            dgvServicios.Columns["Pago"].Width = 40;
            dgvServicios.Columns["Stikers"].Width = 40;
            dgvServicios.Columns["Laboratorio"].Width = 50;
            dgvServicios.Columns["Estado"].Width = 80;
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

            dgvServicios.Rows.Clear();
            listarServicios(listaServiciosGeneral);

        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.DodgerBlue; 
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);

            dgvServicios.Rows.Clear();
            List<entServicio> lista = logServicio.GetInstancia.listarServiciosPendientes();
            listarServicios(lista);
        }

        private void btnFinalizados_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0); 
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.DodgerBlue;

            dgvServicios.Rows.Clear();
            List<entServicio> lista = logServicio.GetInstancia.listarServiciosTerminados();
            listarServicios(lista);
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

        private DataGridViewCellEventArgs anterior =null;

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && e.ColumnIndex<5)
            {
                Color colorSelect = Color.FromArgb(255, 224, 192);
                Color noSelect = Color.White;

                if (anterior!=null)
                {
                    dgvServicios.Rows[anterior.RowIndex].Cells["ID"].Style.BackColor = noSelect;
                    dgvServicios.Rows[anterior.RowIndex].Cells["FechaRegistro"].Style.BackColor = noSelect;
                    dgvServicios.Rows[anterior.RowIndex].Cells["FechaEntrega"].Style.BackColor = noSelect;
                    dgvServicios.Rows[anterior.RowIndex].Cells["Tipo"].Style.BackColor = noSelect;
                    dgvServicios.Rows[anterior.RowIndex].Cells["Cliente"].Style.BackColor = noSelect;
                }

                anterior = e;
                dgvServicios.Rows[e.RowIndex].Cells["ID"].Style.BackColor = colorSelect;
                dgvServicios.Rows[e.RowIndex].Cells["FechaRegistro"].Style.BackColor = colorSelect;
                dgvServicios.Rows[e.RowIndex].Cells["FechaEntrega"].Style.BackColor = colorSelect;
                dgvServicios.Rows[e.RowIndex].Cells["Tipo"].Style.BackColor = colorSelect;
                dgvServicios.Rows[e.RowIndex].Cells["Cliente"].Style.BackColor = colorSelect;
            }else if(e.RowIndex>=0 && e.ColumnIndex >= 0)
            {
                dgvServicios.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                dgvServicios.Rows[e.RowIndex].Cells["ID"].Selected = true;
            }
        }
    }
}
