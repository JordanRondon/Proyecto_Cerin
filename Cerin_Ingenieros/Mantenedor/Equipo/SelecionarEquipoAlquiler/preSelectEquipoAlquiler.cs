using CapaEntidad;
using CapaLogica;
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
            dgvConfiguracion.ConfigurarColumnas(dataGridView_equipos,
                        new string[] { "Categira equipo", "Marca", "Modelo", "Serie del equipo", "Estado" });
            lisEquiposelect = logEquipo.GetInstancia.listarEquipoDisponible();
        }

        private void listarEquipos()
        {
            dataGridView_equipos.Rows.Clear();

            foreach (var equipo in lisEquiposelect)
            {
                entCategoria categoria;
                entMarca marca;
                entModelo modelo;

                (categoria, marca, modelo) = logEquipo.GetInstancia.datosCompledoDeEquipoPorId(equipo.SerieEquipo);

                string estado = equipo.Estado == 'D' ? "Disponible" : equipo.Estado == 'U' ? "SELECIONADO" : "Ocupado";

                dataGridView_equipos.Rows.Add(
                    categoria.Nombre,
                    marca.Nombre,
                    modelo.nombre,
                    equipo.SerieEquipo,
                    estado
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
                lisEquiposelect = logEquipo.GetInstancia.listarEquipoDisponible();
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
                entEquipo equipo = BuscarEquipoPorSerie(Convert.ToString(selectedRow.Cells["Serie del equipo"].Value));
                if (equipo.Estado=='D')
                {
                    if (equipo.Estado != 'O')
                    {
                        equipo.Estado = 'U';
                        bool estadoE = logEquipo.GetInstancia.editarEquipo(equipo);

                        if (estadoE)
                        {
                            selecionado.Add(equipo);
                            listarEquipos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El equipo " + equipo.SerieEquipo + " no esta disponible");
                    }

                }
                else
                {
                    MessageBox.Show("El equipo " + equipo.SerieEquipo + " ya esta en la lista");
                }
            }
        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            selectEquipo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
