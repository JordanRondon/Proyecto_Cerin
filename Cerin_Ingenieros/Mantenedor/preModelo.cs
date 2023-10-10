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

namespace Cerin_Ingenieros.Mantenedor
{
    public partial class preModelo : Form
    {
        public preModelo()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarModelos();
            ComboBoxs();
        }

        private void ComboBoxs()
        {
            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.DataSource = logMarca.GetInstancia.listarMarcas();
            comboBox_marca.SelectedIndex = -1;
        }

        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
            comboBox_marca.Enabled = false;
            comboBox_marca.SelectedIndex = -1;
        }

        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;

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
            txb_nombre.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_cancelar.Enabled = true;

            comboBox_marca .Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (comboBox_marca.Items.Count == 0) {
                MessageBox.Show("Registra una marca");
            }
            else
            {
                txb_nombre.Enabled = true;
                btn_nuevo.Enabled = false;
                btn_guardar.Enabled = true;
                btn_editar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_cancelar.Enabled = true;
                comboBox_marca.Enabled = true;
                comboBox_marca.SelectedIndex = 0;
            }
                

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }

        private void ConfigCabecera()
        {
            dataGridView_modelos.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Codigo" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Marca"}
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_modelos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            comboBox_marca.Enabled = false;
        }

        private void listarModelos()
        {
            //dataGridView_modelos.DataSource = logModelo.GetInstancia.listarModelos();

            List<entModelo> listaModelos = logModelo.GetInstancia.listarTodoModelos();

            dataGridView_modelos.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaModelos)
            {
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                dataGridView_modelos.Rows.Add(
                    item.id_modelo,
                    item.nombre,
                    marca.Nombre
                );
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo();
                    modelo.nombre = txb_nombre.Text.Trim();
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    modelo.IdMarca = marcaSelec.IdMarca;
                    logModelo.GetInstancia.insertaModelo(modelo);

                    //Actualizar botones
                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarModelos();
        }

        private void dataGridView_modelos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dataGridView_modelos.Rows[e.RowIndex];

                txb_codigo.Text = filaActual.Cells[0].Value.ToString();
                txb_nombre.Text = filaActual.Cells[1].Value.ToString();
                comboBox_marca.SelectedIndex = comboBox_marca.FindStringExact(filaActual.Cells[2].Value.ToString());

                habilitar_btn_modificacion();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo();

                    modelo.id_modelo = int.Parse(txb_codigo.Text);
                    modelo.nombre = txb_nombre.Text.Trim();
                    modelo.estado = 'D';
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    modelo.IdMarca = marcaSelec.IdMarca;

                    logModelo.GetInstancia.editarModelo(modelo);
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
            listarModelos();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo();

                    modelo.id_modelo = int.Parse(txb_codigo.Text);
                    modelo.nombre = txb_nombre.Text.Trim();
                    modelo.estado = 'S';

                    logModelo.GetInstancia.editarModelo(modelo);
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
            listarModelos();
            deshablitar_btn();
            deshablitar_entradas();
        }
    }
}
