using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cerin_Ingenieros.RecursosAdicionales.Clases;

namespace Cerin_Ingenieros
{
    public partial class preEmpleado : Form
    {
        int registroSeleccionado = -1;

        public preEmpleado()
        {
            InitializeComponent();
            listarDatosComboBoxRol();
            ConfigCabecera();
            deshablitar_entradas();
            deshablitar_btn();
            listarEmpleado();
            dataGridView_empleados.ReadOnly = true;
            cmb_rol.SelectedIndex = -1;
        }

        private void limpiar_entradas()
        {
            txb_nombres_empleado.Text = "";
            txb_apellidos_empleado.Text = "";
            txb_dniEmpleado.Text = "";
            txb_direccion_empleado.Text = "";
            txb_correo_empleado.Text = "";
            txb_telefono_empleado.Text = "";
            registroSeleccionado = -1;

            txb_userNamer.Text = "";
            txb_contraseña.Text = "";
            cmb_rol.SelectedIndex = -1;
        }

        private void hablitar_entradas()
        {
            txb_nombres_empleado.Enabled = true;
            txb_apellidos_empleado.Enabled = true;
            txb_dniEmpleado.Enabled = true;
            txb_direccion_empleado.Enabled = true;
            txb_correo_empleado.Enabled = true;
            txb_telefono_empleado.Enabled = true;

            txb_userNamer.Enabled = true;
            txb_contraseña.Enabled = true;
            cmb_rol.Enabled = true;
            cmb_rol.SelectedIndex = 0;
        }

        private void deshablitar_entradas()
        {
            txb_nombres_empleado.Enabled = false;
            txb_apellidos_empleado.Enabled = false;
            txb_dniEmpleado.Enabled = false;
            txb_direccion_empleado.Enabled = false;
            txb_correo_empleado.Enabled = false;
            txb_telefono_empleado.Enabled = false;

            txb_userNamer.Enabled = false;
            txb_contraseña.Enabled = false;
            cmb_rol.Enabled = false;
        }

        private void deshablitar_btn()
        {
            btn_nuevo.Enabled = true;
            btn_guardar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = false;
        }

        private void habilitar_btn_modificacion()
        {
            hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_buscar.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_cancelar.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_buscar.Enabled = true;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_cancelar.Enabled = true;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_entradas();
            deshablitar_entradas();
            deshablitar_btn();
        }

        private void listarDatosComboBoxRol()
        {
            cmb_rol.ValueMember = "id_rol";
            cmb_rol.DisplayMember = "nombre";
            cmb_rol.DataSource = logRol.GetInstancia.listarRol();
        }

            private void ConfigCabecera()
        {
            dataGridView_empleados.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Código" },
                new DataGridViewTextBoxColumn { HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { HeaderText = "Apellido" },
                new DataGridViewTextBoxColumn { HeaderText = "DNI" },
                new DataGridViewTextBoxColumn { HeaderText = "Dirreccion" },
                new DataGridViewTextBoxColumn { HeaderText = "Correo" },
                new DataGridViewTextBoxColumn { HeaderText = "Teléfono" },
                new DataGridViewTextBoxColumn { HeaderText = "UserName" },
                new DataGridViewTextBoxColumn { HeaderText = "Rol" }
            );

            dataGridView_empleados.Columns[0].Width = 60;

            //desabilitar que se pueda ordenar por columnas
            foreach (DataGridViewColumn column in dataGridView_empleados.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void listarEmpleado()
        {
            List<entEmpleado> listaEmpleado= logEmpleado.GetInstancia.listarEmpleado();
            

            dataGridView_empleados.Rows.Clear();

            //insertar los datos 
            foreach (var item in listaEmpleado)
            {
                entUsuario usuario = logUser.GetInstancia.buscarUsuario(item.id_usuario);
                string nombreRol = logRol.GetInstancia.buscarRolId(usuario.id_rol).nombre;
                dataGridView_empleados.Rows.Add(
                    item.IdEmpleado,
                    item.Nombre,
                    item.Apellido,
                    item.Dni,
                    item.Direccion,
                    item.Correo,
                    item.Telefono,
                    usuario.userName,
                    nombreRol
                );
            }
        }

        private void dataGridView_empleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow filaActual = dataGridView_empleados.Rows[e.RowIndex];

                registroSeleccionado = int.Parse(filaActual.Cells[0].Value.ToString());
                txb_nombres_empleado.Text = filaActual.Cells[1].Value.ToString();
                txb_apellidos_empleado.Text = filaActual.Cells[2].Value.ToString();
                txb_dniEmpleado.Text = filaActual.Cells[3].Value.ToString();
                txb_direccion_empleado.Text = filaActual.Cells[4].Value.ToString();
                txb_correo_empleado.Text = filaActual.Cells[5].Value.ToString();
                txb_telefono_empleado.Text = filaActual.Cells[6].Value.ToString();

                txb_userNamer.Text = filaActual.Cells[7].Value.ToString();
                //txb_contraseña.Text = filaActual.Cells[8].Value.ToString();
                int indiceRol = cmb_rol.FindString(filaActual.Cells[8].Value.ToString()); 
                if (indiceRol != -1) cmb_rol.SelectedIndex = indiceRol;
                else cmb_rol.SelectedIndex = -1;

                habilitar_btn_modificacion();

                txb_dniEmpleado.Enabled = false;
                txb_apellidos_empleado.Enabled = false;
                txb_nombres_empleado.Enabled = false;
                btn_buscar.Enabled = false;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_nombres_empleado.Text != "" && txb_apellidos_empleado.Text != "" && txb_dniEmpleado.Text != "");
            bool datos_User = txb_userNamer.Text != "" && txb_contraseña.Text != "" && cmb_rol.SelectedIndex != -1;
            try
            {

                if (datosIngresados && datos_User)
                {
                    entUsuario usuario = new entUsuario();

                    usuario.userName = txb_userNamer.Text.Trim();
                    usuario.password = classEncriptar.EncriptarContraseña(txb_contraseña.Text); ; //txb_contraseña.Text;
                    entRol rolSelec = (entRol)cmb_rol.SelectedItem;
                    usuario.id_rol = rolSelec.id_rol;
                    usuario.estado = 'A';
                    usuario.id_usuario =  logUser.GetInstancia.insertarUsuario(usuario);

                    entEmpleado empleado = new entEmpleado();

                    empleado.Nombre = txb_nombres_empleado.Text.Trim();
                    empleado.Apellido = txb_apellidos_empleado.Text.Trim();
                    empleado.Dni = txb_dniEmpleado.Text.Trim();
                    empleado.Direccion = txb_direccion_empleado.Text.Trim();
                    empleado.Correo = txb_correo_empleado.Text.Trim();
                    empleado.Telefono = txb_telefono_empleado.Text.Trim();
                    empleado.id_usuario = usuario.id_usuario;

                    logEmpleado.GetInstancia.insertaEmpleado(empleado);

                    
                }
                else
                {
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            limpiar_entradas();
            listarEmpleado();
            txb_dniEmpleado.Enabled = true;
            txb_apellidos_empleado.Enabled = true;
            txb_nombres_empleado.Enabled = true;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_nombres_empleado.Text != "" && txb_apellidos_empleado.Text != "" && txb_dniEmpleado.Text != "");
            bool datos_User = txb_userNamer.Text != "" && cmb_rol.SelectedIndex != -1;

            try
            {
                if (datosIngresados && datos_User && registroSeleccionado > -1)
                {
                    entEmpleado empleado = new entEmpleado();
                    entUsuario usuario = new entUsuario();
                    empleado.IdEmpleado = registroSeleccionado;
                    empleado.Nombre = txb_nombres_empleado.Text.Trim();
                    empleado.Apellido = txb_apellidos_empleado.Text.Trim();
                    empleado.Dni = txb_dniEmpleado.Text.Trim();
                    empleado.Direccion = txb_direccion_empleado.Text.Trim();
                    empleado.Correo = txb_correo_empleado.Text.Trim();
                    empleado.Telefono = txb_telefono_empleado.Text.Trim();
                    empleado.id_usuario = logEmpleado.GetInstancia.BuscarEmpleadoDNI(empleado.Dni).id_usuario;
                    logEmpleado.GetInstancia.editarEmpleado(empleado);

                    
                    
                    usuario.userName = txb_userNamer.Text.Trim();
                    usuario.password = txb_contraseña.Text;
                    entRol rolSelec = (entRol)cmb_rol.SelectedItem;
                    usuario.id_rol = rolSelec.id_rol;
                    usuario.estado = 'A';
                    usuario.id_usuario = empleado.id_usuario;

                    logUser.GetInstancia.editarUsuario(usuario);
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
            listarEmpleado();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = (txb_nombres_empleado.Text != "" && txb_apellidos_empleado.Text != "" && txb_dniEmpleado.Text != "");

            try
            {
                if (datosIngresados == true && registroSeleccionado > -1)
                {
                    entEmpleado empleado = new entEmpleado();
                    empleado.IdEmpleado = registroSeleccionado;
                    logEmpleado.GetInstancia.deshabilitarEmpleado(empleado);

                    entUsuario usuario = new entUsuario();
                    usuario.id_usuario = logUser.GetInstancia.buscarUsuario(empleado.IdEmpleado).id_usuario;
                    logUser.GetInstancia.deshabilitarUsuario(usuario);
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
            listarEmpleado();
            deshablitar_btn();
            deshablitar_entradas();
        }

        private void ValidarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txb_dniEmpleado.Text!="")
            {
                entApi empleado = logApi.GetInstancia.consultarDatosApi(txb_dniEmpleado.Text);

                if (empleado != null)
                {
                    txb_nombres_empleado.Text = empleado.Nombre;
                    txb_apellidos_empleado.Text = empleado.Apellido;
                    txb_dniEmpleado.Enabled = false;
                    txb_apellidos_empleado.Enabled = false;
                    txb_nombres_empleado.Enabled = false;
                }
                else
                {
                    MessageBox.Show("DNI no valida");
                }
            }            
        }
    }
}
