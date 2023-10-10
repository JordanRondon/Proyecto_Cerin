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
                string estado,fechasalida;
                if (item.estado == 'P') estado = "Pendiente";
                else estado = "Terminado";
                if (item.FechaEntrega == null)
                    fechasalida = "Pendiente";
                else
                {
                    DateTime fechaaux = (DateTime)item.FechaEntrega;
                    fechasalida = fechaaux.ToString("dd-MM-yyyy HH:mm");
                }

                entCliente cliente = logCliente.GetInstancia.buscarClienteId(item.IdCliente);
                dgvServicios.Rows.Add(
                    item.IdServicio,
                    item.FechaRegistro.ToString("dd-MM-yyyy HH:mm"),
                    fechasalida,
                    logTipoServicio.GetInstancia.buscarTipoServicioId(item.IdTipoServicio).Nombre,
                    cliente.Apellido + ", " + cliente.Nombre,
                    "",
                    "",
                    "",
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
    }
}
