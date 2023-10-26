using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Properties;
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
    public partial class preVerServicios : Form
    {
        private List<entServicio> listaServiciosGeneral = logServicio.GetInstancia.listarServicios();
        private List<entTipoServicio> listaTipoServicios = logTipoServicio.GetInstancia.listarTipoServicios();
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
            dgvConfiguracion.ConfigurarColumnas(dgvServicios,new string[] { "ID", "Fecha de registro", "Fecha de entrega", "Tipo servicio", "Cliente" });
            dgvConfiguracion.ConfigurarColumnasImage(dgvServicios,new string[] { "Pago", "Stikers", "Laboratorio", "Estado" });
            
            dgvServicios.Columns["ID"].Width = 40;
            dgvServicios.Columns["Pago"].Width = 51;
            dgvServicios.Columns["Stikers"].Width = 50;
            dgvServicios.Columns["Laboratorio"].Width = 50;
            dgvServicios.Columns["Estado"].Width = 73;
            dgvServicios.Columns["Fecha de registro"].Width = 165;
            dgvServicios.Columns["Fecha de entrega"].Width = 165;
            dgvServicios.Columns["Tipo servicio"].Width = 130;

        }

        private Image ObtenerEstadoEnImage(char estado, string columnName)
        {
            Dictionary<char, Image> estadoImagen = new Dictionary<char, Image>();

            if (columnName == "Pago")
            {
                estadoImagen['V'] = Resources.Verde;
                estadoImagen['A'] = Resources.Amarillo_parcial;
                estadoImagen['R'] = Resources.Rojo_sin_inicial;
            }
            else if (columnName == "Laboratorio")
            {
                estadoImagen['V'] = Resources.Verde;
                estadoImagen['A'] = Resources.Amarillo;
                estadoImagen['R'] = Resources.Rojo;
            }
            else if (columnName == "Stikers")
            {
                estadoImagen['V'] = Resources.Verde;
                estadoImagen['A'] = Resources.Amarillo;
            }
            else
            {
                estadoImagen['T'] = Resources.Verde;
                estadoImagen['P'] = Resources.Amarillo;
            }
            return estadoImagen.TryGetValue(estado, out Image result) ? result : null;
        }

        private void ListarServicios(List<entServicio> lista)
        {
            dgvServicios.Rows.Clear();

            foreach (var item in lista)
            {
                string fechasalida = item.FechaEntrega == null ? "Pendiente" : ((DateTime)item.FechaEntrega).ToString("dd-MM-yyyy HH:mm");

                Image estadoPago = ObtenerEstadoEnImage(item.estadoPago, "Pago");
                Image estadoStiker = ObtenerEstadoEnImage(item.estadoStikers, "Stikers");
                Image estadoLab = ObtenerEstadoEnImage(item.estadoLaboratorio, "Laboratorio");
                Image estado = ObtenerEstadoEnImage(item.estado, "Estado");
                entCliente cliente = logCliente.GetInstancia.buscarClienteId(item.IdCliente);
                entTipoServicio tipoServicio = listaTipoServicios.FirstOrDefault(tipo => tipo.IdTipoServicio == item.IdTipoServicio);

                dgvServicios.Rows.Add(
                    item.IdServicio,
                    item.FechaRegistro.ToString("dd-MM-yyyy HH:mm"),
                    fechasalida,
                    tipoServicio.Nombre,
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

            ListarServicios(listaServiciosGeneral);
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0);
            btnPendientes.BackColor = Color.DodgerBlue;
            btnFinalizados.BackColor = Color.FromArgb(255, 128, 0);

            List<entServicio> lista = logServicio.GetInstancia.listarServiciosPendientes();
            ListarServicios(lista);
        }

        private void btnFinalizados_Click(object sender, EventArgs e)
        {
            btnTodosTipos.BackColor = Color.FromArgb(255, 128, 0); 
            btnPendientes.BackColor = Color.FromArgb(255, 128, 0);
            btnFinalizados.BackColor = Color.DodgerBlue;

            List<entServicio> lista = logServicio.GetInstancia.listarServiciosTerminados();
            ListarServicios(lista);
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
