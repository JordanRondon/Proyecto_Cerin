
// --------------------------------------------------------------
// Nombre del archivo: preCategoria.cs
// Descripción: Clase que gestiona la interfaz de usuario para el
//              mantenimiento de categorías de equipos.
// --------------------------------------------------------------

using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Mantenedor
{
    public partial class preCategoria : Form
    {
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private entDocumento DocSelec = new entDocumento();
        private Dictionary<string, entDocumento> certificados;
        private Dictionary<int, entDocumento> certificadosId;
        private List<entCategoria> categorias;

        public preCategoria()
        {
            InitializeComponent();            
            CargarCategorias();
            deshablitar_entradas();
            deshablitar_btn();
            ConfigCabecera();
            listarCategoria();
        }

        /// <summary>
        /// Carga las categorías, documentos y configura la interfaz.
        /// </summary>
        private void CargarCategorias()
        {
            certificados = new Dictionary<string, entDocumento>();
            certificadosId = new Dictionary<int, entDocumento>();
            categorias = new List<entCategoria>();
            categorias = logCategoria.GetInstancia.listarCategoriasEquipos();
            foreach (var categoria in categorias)
            {
                entDocumento doc = logDocumento.GetInstancia.BuscarDocumentoPorCodigo(categoria.id_documento);
                if (BuscarDocPorId(doc.Id)==null)
                {
                    certificados.Add(doc.Nombre, doc);
                    certificadosId.Add(doc.Id, doc);
                }
            }
        }

        /// <summary>
        /// Limpia las entradas en la interfaz.
        /// </summary>
        private void limpiar_entradas()
        {
            txb_codigo.Text = "";
            txb_nombre.Text = "";
            txbFile.Text = "";
            txbTiempo.Text = "";
            txbNombreDocumento.Text = "";
        }

        /// <summary>
        /// Deshabilita las entradas en la interfaz.
        /// </summary>
        private void deshablitar_entradas()
        {
            txb_codigo.Enabled = false;
            txb_nombre.Enabled = false;
            txbFile.Enabled = false;
            txbTiempo.Enabled = false;
            txbNombreDocumento.Enabled = false;
        }

        /// <summary>
        /// Deshabilita los botones en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Habilita los botones para la modificación en la interfaz.
        /// </summary>
        private void habilitar_btn_modificacion()
        {
            txb_nombre.Enabled = true;
            txbFile.Enabled = true;
            txbTiempo.Enabled = true;
            txbNombreDocumento.Enabled = false;
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

        /// <summary>
        /// Evento al hacer clic en el botón "Nuevo".
        /// Habilita las entradas para la creación de una nueva categoría.
        /// </summary>
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txb_nombre.Enabled = true;
            txbTiempo.Enabled = true;
            txbFile.Enabled = true;
            btnUbicacion.Enabled = true;
            txbNombreDocumento .Enabled = true;
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

        /// <summary>
        /// Evento al hacer clic en el botón "Cancelar".
        /// Cancela la operación y deshabilita entradas y botones.
        /// </summary>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }

        /// <summary>
        /// Configura la cabecera de la tabla en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Lista las categorías en la tabla de la interfaz.
        /// </summary>
        private void listarCategoria()
        {
            dataGridView_categoria.Rows.Clear();
            //insertar los datos 
            foreach (var item in categorias)
            {
                dataGridView_categoria.Rows.Add(
                    item.id_categoria_equipo,
                    item.Nombre,
                    BuscarDocPorId(item.id_documento).Nombre,
                    item.tiempo_certificado
                );
            }
        }

        /// <summary>
        /// Busca un documento por su nombre en el diccionario de certificados.
        /// </summary>
        private entDocumento BuscarDocPorNombre(string nombre)
        {
            if (certificados.TryGetValue(nombre, out entDocumento doc))
            {
                return doc;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Busca un documento por su ID en el diccionario de certificados.
        /// </summary>
        public entDocumento BuscarDocPorId(int id)
        {
            if (certificadosId.TryGetValue(id, out entDocumento doc))
            {
                return doc;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Evento al hacer clic en el botón "Ubicación".
        /// Permite seleccionar la ubicación de un archivo.
        /// </summary>
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

        /// <summary>
        /// Sube un archivo al sistema, insertando un nuevo documento.
        /// </summary>
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

        /// <summary>
        /// Evento al hacer clic en el botón "Guardar".
        /// Guarda una nueva categoría y su documento asociado.
        /// </summary>
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "" && txbFile.Text != "" && txbTiempo.Text != "" && txbNombreDocumento.Text != "")
                {
                    subirArchivo();

                    entDocumento documento = logDocumento.GetInstancia.buscarDocumentoId(txbNombreDocumento.Text.Trim());
                    certificados.Add(documento.Nombre,documento);
                    certificadosId.Add(documento.Id, documento);
                    entCategoria categoria = new entCategoria
                    {
                        Nombre = txb_nombre.Text.Trim(),
                        tiempo_certificado = Convert.ToInt32(txbTiempo.Text.Trim()),
                        id_documento = documento.Id
                    };

                    logCategoria.GetInstancia.insertarCategoria(categoria);
                    categorias.Add(categoria);
                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                    CargarCategorias();
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

        /// <summary>
        /// Evento al hacer clic en el botón "Editar".
        /// Edita una categoría existente y su documento asociado.
        /// </summary>
        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_nombre.Text != "" && txbFile.Text != "" && txbTiempo.Text != "" && txbNombreDocumento.Text!="")
                {
                    byte[] file = null;
                    Stream mystream = openFileDialog1.OpenFile();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        mystream.CopyTo(ms);
                        file = ms.ToArray();
                    }

                    entDocumento doc = BuscarDocPorNombre(txbNombreDocumento.Text);
                    doc.RealName = txbNombreDocumento.Text + ".docx";
                    doc.Doc = file;

                    bool valor = logDocumento.GetInstancia.editarDocumento(doc);
                    if (valor)
                    {
                        MessageBox.Show("Exito");
                    }
                    else MessageBox.Show("Error");

                    entCategoria categoria = new entCategoria
                    {
                        id_categoria_equipo = Convert.ToInt16(txb_codigo.Text),
                        Nombre = txb_nombre.Text.Trim(),
                        tiempo_certificado = Convert.ToInt32(txbTiempo.Text.Trim()),
                        id_documento = doc.Id
                    };

                    logCategoria.GetInstancia.editarCategoria(categoria);

                    deshablitar_btn();
                    deshablitar_entradas();
                    limpiar_entradas();
                    CargarCategorias();
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

        /// <summary>
        /// Evento al hacer doble clic en una celda de la tabla.
        /// Carga los datos de la categoría seleccionada para edición.
        /// </summary>
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
