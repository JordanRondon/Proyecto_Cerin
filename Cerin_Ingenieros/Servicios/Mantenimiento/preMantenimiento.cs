using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preMantenimiento : Form
    {
        entCliente clienteSelecionado;
        List<entEquipo> equiposSelecionados;

        public preMantenimiento()
        {
            InitializeComponent();
            inicializarVariablesAux();
            ConfigCabecera();
            listarEquipos();
            listarDatosComboBoxEmpleados();
        }
        private void listarDatosComboBoxEmpleados()
        {
            comboBox_empleado.ValueMember = "id_empleado";
            comboBox_empleado.DisplayMember = "apellidoNombre";
            comboBox_empleado.DataSource = logEmpleado.GetInstancia.listarEmpleado()
                .Select(e => new
                {
                    id_empleado = e.IdEmpleado,
                    apellidoNombre = $"{e.Apellido}, {e.Nombre}" // Combina apellido y nombre
                })
                .ToList();
        }
        private void ConfigCabecera()
        {
            dataGridView_lista_quipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Codigo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );
            dataGridView_lista_quipos.Columns[0].Width = 80;

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_lista_quipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            equiposSelecionados = logEquipo.GetInstancia.listarEquipo();
            equiposSelecionados = new List<entEquipo>();
        }

        private void listarEquipos()
        {
            dataGridView_lista_quipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in equiposSelecionados)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dataGridView_lista_quipos.Rows.Add(
                    item.IdEquipo,
                    item.SerieEquipo,
                    item.Modelo,
                    estado,
                    marca.Nombre
                );
            }
        }
        private void inicializarVariablesAux()
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_select_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();
        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            preRegistEquipoMantenimiento preRegistEquipoMantenimiento = new preRegistEquipoMantenimiento();
            preRegistEquipoMantenimiento.ShowDialog();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado != null)
            {
                if (clienteSelecionado.Dni != "")
                    lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                else
                    lb_dni_ruc_cliente.Text = clienteSelecionado.Ruc;
                lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                lb_telefono_cliente.Text = clienteSelecionado.Telefono;
            }
        }
    }
}
