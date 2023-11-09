using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
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
            comboBoxCategoria.ValueMember = "id_categoria_equipo";
            comboBoxCategoria.DisplayMember = "nombre";
            List<entCategoria> lista =  logCategoria.GetInstancia.listarCategoriasEquipos();
            comboBoxCategoria.DataSource = lista;
            comboBoxCategoria.SelectedIndex = -1;

            comboBox_marca.ValueMember = "id_Marca";
            comboBox_marca.DisplayMember = "nombre";
            comboBox_marca.SelectedIndex = -1;
        }

        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
            comboBox_marca.Enabled = false;
            comboBox_marca.SelectedIndex = -1;

            comboBoxCategoria.Enabled = false;
            comboBoxCategoria.SelectedIndex = -1;
        }

        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;
        }

        private void deshablitar_btn()
        {
            btn_nuevo.Enabled = true;
            btn_nuevo.BackColor = configColores.btnActivo;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = false;
            btn_editar.BackColor = configColores.btDesactivado;
            btn_eliminar.Enabled = false;
            btn_eliminar.BackColor = configColores.btDesactivado;
            btn_cancelar.Enabled = false;
            btn_cancelar.BackColor = configColores.btDesactivado;
        }

        private void habilitar_btn_modificacion()
        {
            txb_nombre.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = true;
            btn_editar.BackColor = configColores.btnActivo;
            btn_eliminar.Enabled = true;
            btn_eliminar.BackColor = configColores.btnActivo;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
            comboBox_marca .Enabled = true;
            comboBoxCategoria .Enabled = true;
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
                btn_nuevo.BackColor = configColores.btDesactivado;
                btn_editar.Enabled = false;
                btn_editar.BackColor = configColores.btDesactivado;
                btn_eliminar.Enabled = false;
                btn_eliminar.BackColor = configColores.btDesactivado;
                btn_cancelar.Enabled = true;
                btn_cancelar.BackColor = configColores.btnActivo;
                btn_guardar.Enabled = true;
                btn_guardar.BackColor = configColores.btnActivo;
                comboBox_marca.SelectedIndex = 0;
                comboBox_marca.Enabled = true;
                comboBoxCategoria.SelectedIndex = 0;
                comboBoxCategoria.Enabled = true;

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
                new DataGridViewTextBoxColumn { HeaderText = "Marca"},
                new DataGridViewTextBoxColumn { HeaderText = "Categoria" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_modelos.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            comboBox_marca.Enabled = false;
            comboBoxCategoria.Enabled = false;
        }

        private void listarModelos()
        {
            List<entModelo> listaModelos = logModelo.GetInstancia.listarTodoModelos();

            dataGridView_modelos.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaModelos)
            {
                entMarca marca = logMarca.GetInstancia.BuscarMarcaPorId(item.IdMarca);
                entCategoria categoria = logCategoria.GetInstancia.buscarCategoriaId(item.IdCategoriaEquipo);
                dataGridView_modelos.Rows.Add(
                    item.id_modelo,
                    item.nombre,
                    marca.Nombre,
                    categoria.Nombre
                );
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo
                    {
                        nombre = txb_nombre.Text.Trim()
                    };
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    modelo.IdMarca = marcaSelec.IdMarca;

                    entCategoria catSelec = (entCategoria)comboBoxCategoria.SelectedItem;
                    modelo.IdCategoriaEquipo = catSelec.id_categoria_equipo;

                    logModelo.GetInstancia.insertaModelo(modelo);

                    //Actualizar botones
                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                    listarModelos();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void dataGridView_modelos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dataGridView_modelos.Rows[e.RowIndex];

                txb_codigo.Text = filaActual.Cells[0].Value.ToString();
                txb_nombre.Text = filaActual.Cells[1].Value.ToString();

                comboBox_marca.SelectedIndex = comboBox_marca.FindStringExact(filaActual.Cells[2].Value.ToString());
                comboBoxCategoria.SelectedIndex = comboBoxCategoria.FindStringExact(filaActual.Cells[3].Value.ToString());

                habilitar_btn_modificacion();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo
                    {
                        id_modelo = int.Parse(txb_codigo.Text),
                        nombre = txb_nombre.Text.Trim(),
                        estado = 'D'
                    };
                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    modelo.IdMarca = marcaSelec.IdMarca;

                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    modelo.IdCategoriaEquipo = categoria.id_categoria_equipo;

                    logModelo.GetInstancia.editarModelo(modelo);

                    limpiar_entradas();
                    listarModelos();
                    deshablitar_btn();
                    deshablitar_entradas();
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_codigo.Text != "" && txb_nombre.Text != "")
                {
                    entModelo modelo = new entModelo
                    {
                        id_modelo = int.Parse(txb_codigo.Text),
                        nombre = txb_nombre.Text.Trim(),
                        estado = 'S'
                    };

                    entMarca marcaSelec = (entMarca)comboBox_marca.SelectedItem;
                    modelo.IdMarca = marcaSelec.IdMarca;

                    entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedItem;
                    modelo.IdCategoriaEquipo = categoria.id_categoria_equipo;

                    logModelo.GetInstancia.editarModelo(modelo);

                    limpiar_entradas();
                    listarModelos();
                    deshablitar_btn();
                    deshablitar_entradas();
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            entCategoria categoria = (entCategoria)comboBoxCategoria.SelectedValue;
            if (categoria != null)
            {
                List<entMarca>marcas = logMarca.GetInstancia.listarMarcasPorCategoria(categoria.id_categoria_equipo);
                comboBox_marca.DataSource = marcas;
            }
        }
    }
}
