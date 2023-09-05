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

namespace Cerin_Ingenieros.Servicios.Alquiler
{
    public partial class preSelectEquipoAlquiler : Form
    {
        private List<entEquipo> lisEquiposelect;
        private List<entEquipo> selecionado = new List<entEquipo>();

        public preSelectEquipoAlquiler()
        {
            InitializeComponent();
            ConfigCabecera();
            listarEquipos();
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
            lisEquiposelect = logEquipo.GetInstancia.listarEquipo();
        }

        private void listarEquipos()
        {
            dataGridView_equipos.Rows.Clear();

            //insertar los datos 
            foreach (var item in lisEquiposelect)
            {
                string estado2 = "";
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);

                if (item.Estado == 'D') estado2 = "Disponible";
                if (item.Estado == 'U') estado2 = "Uso";
                else estado2 = "Ocupado";
                dataGridView_equipos.Rows.Add(
                    item.IdEquipo,
                    item.SerieEquipo,
                    item.Modelo,
                    estado2,
                    marca.Nombre
                );
            }
        }

        private void txb_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txb_buscar.Text))
            {
                if (rb_modelo.Checked)
                {
                    lisEquiposelect = logEquipo.GetInstancia.listarEquipoModelo(Convert.ToString(txb_buscar.Text));
                }
                else if (rb_serie.Checked)
                {
                    lisEquiposelect = logEquipo.GetInstancia.listarEquipoSerie(Convert.ToString(txb_buscar.Text));
                }
                else if (rb_marca.Checked)
                {
                    lisEquiposelect = logEquipo.GetInstancia.listarEquipoMarca(Convert.ToString(txb_buscar.Text));
                }
            }
            else
            {
                lisEquiposelect = logEquipo.GetInstancia.listarEquipo();
            }
            listarEquipos();
        }
        public List<entEquipo> getEquipos() { return selecionado; }

        public entEquipo BuscarEquipoPorSerie(string serie)
        {
            return lisEquiposelect.FirstOrDefault(equipo => equipo.SerieEquipo.Equals(serie, StringComparison.OrdinalIgnoreCase));
        }
        public void selectEquipo()
        {
            if (dataGridView_equipos.SelectedRows.Count>0)
            {
                DataGridViewRow selectedRow = dataGridView_equipos.SelectedRows[0];
                entEquipo equipo = BuscarEquipoPorSerie(Convert.ToString(selectedRow.Cells[1].Value));
                equipo.Estado = 'U';
                bool estadoE = logEquipo.GetInstancia.editarEquipo(equipo);

                if (estadoE)
                {
                    selecionado.Add(equipo);
                    listarEquipos();
                }
            }
        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            selectEquipo();
        }
    }
}
