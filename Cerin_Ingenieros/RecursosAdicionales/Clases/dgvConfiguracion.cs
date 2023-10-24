using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.RecursosAdicionales.Clases
{
    public static class dgvConfiguracion
    {
        /// <summary>
        /// Configura las columnas de un DataGridView
        /// </summary>
        /// <param name="dataGridView">El DataGridView al que se le agregara las columnas</param>
        /// <param name="headers">Matriz de cadenas que contiene el nombre de las columnas</param>
        public static void ConfigurarColumnas(DataGridView dataGridView, string[] headers)
        {
            //Configuracion de columnas
            foreach (var header in headers)
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = header, Name = header });
            }

            // Deshabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

    }
}
