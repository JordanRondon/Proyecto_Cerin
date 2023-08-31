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

namespace Cerin_Ingenieros.Servicios.Mantenimiento
{
    public partial class preRegistEquipoMantenimiento : Form
    {
        public preRegistEquipoMantenimiento()
        {
            InitializeComponent();
            CargarAccesorios();
            ConfigInicial();
        }

        private void ConfigInicial()
        {
            groupBoxAccesorios.Enabled = false;
            groupBoxObservaciones.Enabled = false;
        }


        private void CargarAccesorios()
        {
            List<entAccesorio> listaAccesorio = logAccesorio.GetInstancia.listarAccesorio();

            dgvAcesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "Opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" , ReadOnly = true } ,
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true }
            );
            dgvAcesorios.Columns[0].Width = 50;
            dgvAcesorios.Columns[2].Width = 80;

            foreach (DataGridViewColumn column in dgvAcesorios.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (var item in listaAccesorio)
            {
                dgvAcesorios.Rows.Add(
                    false,
                    item.Nombre,
                    ""
                );
            }

        }

        private void dgvAcesorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Verifica que el evento ocurrió en la primera columna
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvAcesorios.Rows[e.RowIndex].Cells[0];
                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)dgvAcesorios.Rows[e.RowIndex].Cells[2];

                // Verifica el estado del checkbox y habilita o deshabilita la edición de la tercera columna
                if (!Convert.ToBoolean(checkBoxCell.Value))
                {
                    textBoxCell.ReadOnly = false;
                    textBoxCell.Value = "1"; // aqui que asigne el valor 1 por defecto
                }
                else
                {
                    textBoxCell.ReadOnly = true;
                    textBoxCell.Value = ""; // aqui que asigne el valor null por defecto
                }
            }
        }
    }
}
