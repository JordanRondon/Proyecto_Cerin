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

namespace Cerin_Ingenieros
{
    public partial class preEquipo : Form
    {
        int registroSeleccionado = -1;

        public preEquipo()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarEquipo();
            listarDatosComboBoxMarca();
            dataGridView_equipos.ReadOnly = true;
            comboBox_marca.SelectedIndex = -1;
            comboBox_marca.DropDownStyle = ComboBoxStyle.DropDownList;//comboBox solo lectura
        }

        private void limpiar_entradas()
        {
            txb_serie_equipo.Text = "";
            txb_modelo_equipo.Text = "";
            comboBox_marca.SelectedIndex = -1;
            registroSeleccionado = -1;
        }

        private void hablitar_entradas()
        {
            txb_serie_equipo.Enabled = true;
            txb_modelo_equipo.Enabled = true;
            comboBox_marca.Enabled = true;
        }

        private void deshablitar_entradas()
        {
            txb_serie_equipo.Enabled = false;
            txb_modelo_equipo.Enabled = false;
            comboBox_marca.Enabled = false;
        }

        private void deshablitar_btn()
        {
            btn_nuevo.Enabled = true;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = false;
        }

        private void habilitar_btn_modificacion()
        {
            hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_cancelar.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = true;
            comboBox_marca.SelectedIndex = 0;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }
        private void ConfigCabecera()
        {
            dataGridView_equipos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Codigo" },
                new DataGridViewTextBoxColumn { HeaderText = "Serie del equipo" },
                new DataGridViewTextBoxColumn { HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca" }
            );
            dataGridView_equipos.Columns[0].Width = 80;

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_equipos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void listarEquipo()
        {

            List<entEquipo> listaEquipos = logEquipo.GetInstancia.listarEquipo();

            dataGridView_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaEquipos)
            {
                string estado;
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);

                if (item.Estado == 'D') estado = "Disponible";
                else estado = "Ocupado";
                dataGridView_equipos.Rows.Add(
                    item.IdEquipo,
                    item.SerieEquipo,
                    item.Modelo,
                    estado,
                    marca.Nombre
                );
            }
        }

        private void listarDatosComboBoxMarca()
        {
            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.DataSource = logMarca.GetInstancia.listarMarcas();
        }

        private int obtenerIndiceMarcaSelec(DataGridViewRow filaActual)
        {
            List<entMarca> listaMarca = new List<entMarca>();

            listaMarca = logMarca.GetInstancia.listarMarcas();

            entMarca marcaSeleccionada = new entMarca();

            foreach (var i in listaMarca)
            {
                //obtenemos el registro mediante un ID especifico 
                if (i.IdMarca == int.Parse(filaActual.Cells[7].Value.ToString()))
                {
                    marcaSeleccionada = i;
                }
            }

            //obtenemos la poscion dentro del comboBox mediande el nombreMarca
            int index = comboBox_marca.FindString(marcaSeleccionada.Nombre);

            if (index != -1)
                return index;
            else
                return -1;
        }

        private void dataGridView_equipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dataGridView_equipos.Rows[e.RowIndex];

            registroSeleccionado = int.Parse(filaActual.Cells[0].Value.ToString());
            txb_serie_equipo.Text = filaActual.Cells[1].Value.ToString();
            txb_modelo_equipo.Text = filaActual.Cells[2].Value.ToString();
            comboBox_marca.SelectedIndex = obtenerIndiceMarcaSelec(filaActual);

            habilitar_btn_modificacion();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true)
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    equipo.Modelo = txb_modelo_equipo.Text.Trim();
                    equipo.Observaciones = "";
                    equipo.Recomendaciones = "";
                    equipo.Estado = 'D';//estado disponible
                    equipo.IdTipo = 1; //tipo de servicio alquiler
                    equipo.IdMarca = comboBox_marca.SelectedIndex + 1;

                    logEquipo.GetInstancia.insertaEquipo(equipo);
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarEquipo();

            //reiniciar el combobox al primer elemento 
            if (comboBox_marca.Items.Count >= 0)
                comboBox_marca.SelectedIndex = 0;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true && registroSeleccionado > -1)
                {
                    entEquipo equipo = new entEquipo();

                    equipo.IdEquipo = registroSeleccionado;
                    equipo.SerieEquipo = txb_serie_equipo.Text.Trim();
                    equipo.Modelo = txb_modelo_equipo.Text.Trim();
                    equipo.Observaciones = "";
                    equipo.Recomendaciones = "";
                    equipo.Estado = 'D';//estado disponible
                    equipo.IdTipo = 1; //tipo de servicio alquiler
                    equipo.IdMarca = comboBox_marca.SelectedIndex + 1;

                    logEquipo.GetInstancia.editarEquipo(equipo);
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarEquipo();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_serie_equipo.Text != "" && txb_modelo_equipo.Text != "" && comboBox_marca.SelectedIndex != -1);

            try
            {
                if (datosIngresados == true && registroSeleccionado > -1)
                {
                    entEquipo equipo = new entEquipo();

                    equipo.IdEquipo = registroSeleccionado;

                    logEquipo.GetInstancia.deshabilitarEquipo(equipo);
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarEquipo();
            deshablitar_btn();
            deshablitar_entradas();
        }
    }
}

