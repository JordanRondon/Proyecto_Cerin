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
            ListarAccesorios();
        }

        private void ListarAccesorios()
        {
            //Lista de accesosrios 
            List<entAccesorio> listaAccesorios = logAccesorio.GetInstancia.listarAccesorios();

            //Configuracion del data grid view
            dgvAccesorios.Columns.AddRange(
                new DataGridViewCheckBoxColumn { HeaderText = "Opcion" },
                new DataGridViewTextBoxColumn { HeaderText = "nombre", ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "Cantidad", ReadOnly = true}
            );
            dgvAccesorios.Columns[0].Width = 60;
            dgvAccesorios.Columns[2].Width = 100;


            //Cargado de datos al datagridview
            foreach (var item in listaAccesorios)
            {
                dgvAccesorios.Rows.Add(
                    false,
                    item.Nombre,
                    ""
                );

            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccesorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Verifica que el evento ocurrió en la primera columna
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvAccesorios.Rows[e.RowIndex].Cells[0];
                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)dgvAccesorios.Rows[e.RowIndex].Cells[2];

                // Verifica el estado del checkbox y habilita o deshabilita la edición de la tercera columna
                if (!Convert.ToBoolean(checkBoxCell.Value))
                {
                    textBoxCell.ReadOnly = false;
                }
                else
                {
                    textBoxCell.ReadOnly = true;
                }
            }
        }
    }
}
