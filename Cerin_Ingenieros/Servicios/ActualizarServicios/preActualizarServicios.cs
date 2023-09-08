﻿using CapaEntidad;
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
        public preActualizarServicios()
        {
            InitializeComponent();
            dataGridView_equipos.ReadOnly = true;
            dataGridView_Accesorios.ReadOnly = true;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            entServicio servicioActual = new entServicio();
            entCliente cliente = new entCliente();
            entTipo tipoServicio = new entTipo();
            if (logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString())) != null)
            {
                servicioActual = logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString()));
                cliente = logCliente.GetInstancia.buscarClienteId(servicioActual.IdCliente);
                tipoServicio = logTipo.GetInstancia.buscarTipoServicioId(servicioActual.IdTipo);
                if (cliente.Nombre != null)
                    label_nombre_ruc_cliente.Text = cliente.Apellido + ", " + cliente.Nombre;
                else
                    label_nombre_ruc_cliente.Text = cliente.RazonSocial;

                label_tipo_Servicio.Text = tipoServicio.Nombre;
                listarEquipos(servicioActual.IdServicio);
            }
            else
                MessageBox.Show("Código de Servicio inexistente");
        }

        private void listarEquipos(int id_servicio)
        {
            dataGridView_equipos.DataSource = logEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(id_servicio);
        }
    }
}
