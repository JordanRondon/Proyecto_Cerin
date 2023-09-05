using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.Servicios.Alquiler;
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
    public partial class preAlquiler : Form
    {
        entCliente clienteSelecionado;
        List<entEquipo> equiposSelecionados;
        bool prosesoCancelado = true;
        public preAlquiler()
        {
            InitializeComponent();
            inicializarVariablesAux();
            ConfigCabecera();
            listarEquipos();
        }

        private void ConfigCabecera()
        {
            dataGridView_list_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Codigo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );
            dataGridView_list_equipos.Columns[0].Width = 80;

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_list_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            equiposSelecionados = logEquipo.GetInstancia.listarEquipo();
            equiposSelecionados = new List<entEquipo>();
        }

        private void listarEquipos()
        {
            dataGridView_list_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in equiposSelecionados)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dataGridView_list_equipos.Rows.Add(
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
            //Configuracion de fecha y hora
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();

            //Configuracion inicial
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            btn_nuevo.Enabled = true;
            btn_cancelar.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;


        }

        //Botones
        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado!=null)
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

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            preSelectEquipoAlquiler preSelectEquipo = new preSelectEquipoAlquiler();
            preSelectEquipo.ShowDialog();

            equiposSelecionados.AddRange(preSelectEquipo.getEquipos());

            listarEquipos();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void preAlquiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActualizarEstadosEquipos();
        }
        private void ActualizarEstadosEquipos()
        {
            if (equiposSelecionados.Count > 0 && prosesoCancelado)
            {
                foreach (var item in equiposSelecionados)
                {
                    item.Estado = 'D';
                    logEquipo.GetInstancia.editarEquipo(item);
                }
                equiposSelecionados.Clear();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            prosesoCancelado = true;
            ActualizarEstadosEquipos();
            listarEquipos();
            inicializarVariablesAux();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;

            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_editar.Enabled = true;









            prosesoCancelado = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            prosesoCancelado = false;
        }
    }
}
