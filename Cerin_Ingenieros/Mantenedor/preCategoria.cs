using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using Cerin_Ingenieros.Servicios.ActualizarServicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Mantenedor
{
    public partial class preCategoria : Form
    {
        entDocumento DocSelec = new entDocumento();
        public preCategoria()
        {
            InitializeComponent();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarCategoria();
        }

        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
            txbFile.Text = "";
            txbTiempo.Text = "";
            txbNombreDocumento.Text = "";
        }

        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;
            txbFile.Enabled = false;
            txbTiempo.Enabled = false;
            txbNombreDocumento.Enabled = false;
        }

        private void deshablitar_btn()
        {
            btn_nuevo.Enabled = true;
            btn_nuevo.BackColor = configColores.btnActivo;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = false;
            btn_editar.BackColor = configColores.btDesactivado;
            btn_cancelar.Enabled = false;
            btn_cancelar.BackColor = configColores.btDesactivado;
            btnUbicacion.Enabled = false;
            btnUbicacion.BackColor = configColores.btDesactivado;
        }

        private void habilitar_btn_modificacion()
        {
            txb_nombre.Enabled = true;
            txbFile.Enabled = true;
            txbTiempo.Enabled = true;
            txbNombreDocumento.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = true;
            btn_editar.BackColor = configColores.btnActivo;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
            btnUbicacion.Enabled = true;
            btnUbicacion.BackColor = configColores.btnActivo;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txb_nombre.Enabled = true;
            txbTiempo.Enabled = true;
            txbFile.Enabled = true;
            btnUbicacion.Enabled = true;
            btnUbicacion.BackColor = configColores.btnActivo;
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = true;
            btn_guardar.BackColor = configColores.btnActivo;
            btn_editar.Enabled = false;
            btn_editar.BackColor = configColores.btDesactivado;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }

        

        private void ConfigCabecera()
        {
            dataGridView_categoria.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Codigo" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Docuemnto" },
                new DataGridViewTextBoxColumn { HeaderText = "Tiempo" }
            );

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_categoria.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void listarCategoria()
        {
            List<entCategoria> listaCategoria = logCategoria.GetInstancia.listarCategoriasEquipos();

            dataGridView_categoria.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaCategoria)
            {
                dataGridView_categoria.Rows.Add(
                    item.id_categoria_equipo,
                    item.Nombre,
                    logDocumento.GetInstancia.BuscarDocumentoPorCodigo(item.id_documento).Nombre,
                    item.tiempo_certificado
                );
            }
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archicos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFile.Text = openFileDialog1.FileName;
            }
        }

        private void subirArchivo()
        {
            if (txbNombreDocumento.Text != "" || txbFile.Text != "")
            {
                byte[] file = null;

                Stream mystream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    mystream.CopyTo(ms);
                    file = ms.ToArray();
                }

                bool valor = logDocumento.GetInstancia.insertarDocumento(txbNombreDocumento.Text, openFileDialog1.SafeFileName, file);
                if (valor)
                {
                    MessageBox.Show("Exito");
                }
                else MessageBox.Show("Error");
            }
            else MessageBox.Show("Ingrese el nombre");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "" && txbFile.Text != "" && txbTiempo.Text != "" && txbNombreDocumento.Text != "")
                {
                    subirArchivo();

                    entDocumento documento = logDocumento.GetInstancia.buscarDocumentoId(txbNombreDocumento.Text.Trim());

                    entCategoria categoria = new entCategoria
                    {
                        Nombre = txb_nombre.Text.Trim(),
                        tiempo_certificado = Convert.ToInt32(txbTiempo.Text.Trim()),
                        id_documento = documento.Id
                    };

                    logCategoria.GetInstancia.insertarCategoria(categoria);

                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                    listarCategoria();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "" && txbFile.Text != "" && txbTiempo.Text != "")
                {
                    entCategoria categoria = new entCategoria
                    {
                        Nombre = txb_nombre.Text.Trim(),
                        tiempo_certificado = Convert.ToInt32(txbTiempo.Text.Trim())
                    };

                    //falta agregar la modificacion del documentos 
                    //logCategoria.GetInstancia.editarCategoria(categoria);

                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                    listarCategoria();
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_categoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dataGridView_categoria.Rows[e.RowIndex];

                txb_codigo.Text = filaActual.Cells[0].Value.ToString();
                txb_nombre.Text = filaActual.Cells[1].Value.ToString();
                txbNombreDocumento.Text = filaActual.Cells[2].Value.ToString();
                DocSelec = logDocumento.GetInstancia.buscarDocumentoId(txbNombreDocumento.Text);
                txbTiempo.Text = filaActual.Cells[3].Value.ToString();
                habilitar_btn_modificacion();
            }
        }
    }
}
