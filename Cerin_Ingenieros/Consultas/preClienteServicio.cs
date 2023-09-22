﻿using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios;
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
    public partial class preClienteServicio : Form
    {
        private entCliente clienteSelecionado = null;
        private int id_servicio = -1;

        public preClienteServicio()
        {
            InitializeComponent();
            ConfigCabecera();
            dataGridView_servicios.ReadOnly = true;
            dataGridView_equipos.ReadOnly = true;
            dataGridView_Accesorios.ReadOnly = true;
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
            lb_nombre_razonSocial.Text = "CLIENTE O RAZÓN SOCIAL";
            lb_dni_ruc.Text = "DNI O RUC";
            lb_nombreEmpleado.Text = "EMPLEADO";
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
                new DataGridViewTextBoxColumn { HeaderText = "Estado" }
            );
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_servicios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Instrumento" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie" },
                new DataGridViewTextBoxColumn { HeaderText = "modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Accesorios Adicionales" }
            );
            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView_Accesorios.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad" }
            );
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
                    estado
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
                string estado = null;
                entCategoria categoriaEquipo = logCategoria.GetInstancia.buscarCategoriaId(item.id_categoria);
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entModelo modelo = logModelo.GetInstancia.BuscarModeloPorId(item.id_modelo);

                switch (item.Estado)
                {
                    case 'D': estado = "Disponible"; break;
                    case 'O': estado = "Ocupado"; break;
                    case 'P': estado = "En Proceso"; break;
                    case 'E': estado = "Entregado"; break;
                    case 'S': estado = "Eliminado"; break;
                    case 'U': estado = "En Uso"; break;
                }

                dataGridView_equipos.Rows.Add(
                    categoriaEquipo.Nombre,
                    item.SerieEquipo,
                    modelo.nombre,
                    marca.Nombre,
                    estado,
                    item.otrosaccesorios
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
            preSeleccionarCliente preSeleccionarCliente = new preSeleccionarCliente();
            preSeleccionarCliente.ShowDialog();

            clienteSelecionado = preSeleccionarCliente.getCliente();

            if (clienteSelecionado != null)
            {

                if (clienteSelecionado.Dni != null)
                {
                    lb_nombre_razonSocial.Text = clienteSelecionado.Nombre.ToString() + ' ' + clienteSelecionado.Apellido.ToString();
                    lb_dni_ruc.Text = clienteSelecionado.Dni.ToString();
                }
                else
                {
                    lb_nombre_razonSocial.Text = clienteSelecionado.RazonSocial.ToString();
                    lb_dni_ruc.Text = clienteSelecionado.Ruc.ToString();
                }
            }
            else MessageBox.Show("Cliente no exite");
            listarServicios();
        }

        private void dataGridView_servicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView_Accesorios.Rows.Clear();
                limpiarTextBox();

                DataGridViewRow filaActual = dataGridView_servicios.Rows[e.RowIndex];
                id_servicio = int.Parse(filaActual.Cells[0].Value.ToString());
                
                int idEmpleado = logServicio.GetInstancia.buscarServicio(id_servicio).IdEmpleado;
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
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView_servicios.Rows.Clear();
            limpiarEntradas();
        }
    }
}
