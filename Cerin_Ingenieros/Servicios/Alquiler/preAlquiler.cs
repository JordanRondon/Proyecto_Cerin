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
        entCliente clienteSelecionado = null;
        List<entEquipo> equiposSelecionados;
        bool prosesoCancelado = true;
        public preAlquiler()
        {
            InitializeComponent();
            listarDatosComboBoxEmpleados();
            inicializarVariablesAux();
            ConfigCabecera();
            listarEquipos();
            comboBox_empleado.DropDownStyle = ComboBoxStyle.DropDownList;//comboBox solo lectura
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
            dataGridView_list_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_list_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            equiposSelecionados = logEquipo.GetInstancia.listarEquipoAlquiler();
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
                else if (item.Estado == 'U') estado = "Usando ahora";
                else estado = "Ocupado";
                dataGridView_list_equipos.Rows.Add(
                    item.SerieEquipo,
                    item.id_modelo,
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

            lb_dni_ruc_cliente.Text = "DNI";
            lb_nombres_cliente.Text = "Nombres";
            lb_apellidos_cliente.Text = "Apellidos";
            lb_telefono_cliente.Text = "Telefono";
        }

        //Botones
        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado!=null)
            {
                lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                txb_ruc.Text = clienteSelecionado.Ruc;
                lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                lb_telefono_cliente.Text = clienteSelecionado.Telefono;
                txb_razon_social.Text = clienteSelecionado.RazonSocial;
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
            listarEquipos();
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

            if (clienteSelecionado!=null && equiposSelecionados.Count>0)
            {
                    //REGISTRAR EL SERVICIO
                entServicio servicio = new entServicio
                {
                    FechaRegistro = DateTime.Now,
                    IdTipoServicio = logTipoServicio.GetInstancia.BuscarTipoPorNombre("ALQUILER").IdTipoServicio,
                    IdCliente = clienteSelecionado.IdCliente
                };
                //entEmpleado temp = (entEmpleado)comboBox_empleado.SelectedItem;
                servicio.IdEmpleado = comboBox_empleado.SelectedIndex + 1;//temp.IdEmpleado;
                
                int idServicio = logServicio.GetInstancia.insertarServicio(servicio);

                //REGISTRAR EQUIPO_SERVICIO
                entEquipo_Servicio equipo_Servicio = new entEquipo_Servicio();
                equipo_Servicio.IdServicio = idServicio;
                equipo_Servicio.Observaciones_preliminares = "";
                equipo_Servicio.observaciones_finales = "";
                foreach (var item in equiposSelecionados)
                {
                    equipo_Servicio.serie_equipo = item.SerieEquipo;
                    logEquipo_Servicio.GetInstancia.insertarEquipoServicio(equipo_Servicio);

                    //ACTUALIZAR EL EQUIPO A OCUPADO(PRESTADO)
                    item.Estado = 'O';
                    logEquipo.GetInstancia.editarEquipo(item);

                }
                logComprobante.GetInstancia.generarComprobante(servicio);

                prosesoCancelado = true;
                clienteSelecionado = null;
                equiposSelecionados.Clear();

                lb_dni_ruc_cliente.Text = "DNI / RUC";
                lb_apellidos_cliente.Text = "Apellidos";
                lb_nombres_cliente.Text = "Nombres";
                lb_telefono_cliente.Text = "Telefono";

                inicializarVariablesAux();

                listarEquipos();
            }
            else
            {
                MessageBox.Show("Faltan campos por completar");
            }
        }

        private void txb_ruc_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "RUC")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; // Cambia el color de texto al predeterminado
            }
        }

        private void txb_ruc_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "RUC";
                textBox.ForeColor = SystemColors.GrayText; // Cambia el color de texto a gris
            }
        }

        private void txb_razon_social_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Razon social")
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; // Cambia el color de texto al predeterminado
            }
        }

        private void txb_razon_social_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Razon social";
                textBox.ForeColor = SystemColors.GrayText; // Cambia el color de texto a gris
            }
        }
    }
}
