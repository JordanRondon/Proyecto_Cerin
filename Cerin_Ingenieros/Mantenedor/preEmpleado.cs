using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cerin_Ingenieros.RecursosAdicionales.Clases;

namespace Cerin_Ingenieros
{
    public partial class preEmpleado : Form
    {
        private int registroSeleccionado = -1;

        public preEmpleado()
        {
            InitializeComponent();
            InicializarFormulario();
        }
        private void InicializarFormulario()
        {
            ListarDatosComboBoxRol();
            ConfigCabecera();
            Deshablitar_entradas();
            ConfigInicialBtn();
            ListarEmpleado();
            cmb_rol.SelectedIndex = -1;
        }

        private void Limpiar_entradas()
        {
            txb_nombres_empleado.Text = "";
            txb_apellidos_empleado.Text = "";
            txb_dniEmpleado.Text = "";
            txb_direccion_empleado.Text = "";
            txb_correo_empleado.Text = "";
            txb_telefono_empleado.Text = "";
            txb_userNamer.Text = "";
            txb_contraseña.Text = "";
            cmb_rol.SelectedIndex = -1;
            registroSeleccionado = -1;
        }

        private void Hablitar_entradas()
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

        private void Deshablitar_entradas()
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
            cmb_rol.SelectedIndex = -1;
        }

        private void ConfigInicialBtn()
        {
            btn_nuevo.Enabled = true;
            btn_nuevo.BackColor = configColores.btnActivo;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_buscar.Enabled = false;
            btn_buscar.BackColor = configColores.btDesactivado;
            btn_editar.Enabled = false;
            btn_editar.BackColor = configColores.btDesactivado;
            btn_eliminar.Enabled = false;
            btn_eliminar.BackColor = configColores.btDesactivado;
            btn_cancelar.Enabled = false;
            btn_cancelar.BackColor = configColores.btDesactivado;
        }

        private void ConfigModificacionBtn()
        {
            Hablitar_entradas();
            btn_nuevo.Enabled = false;
            btn_nuevo.BackColor = configColores.btDesactivado;
            btn_guardar.Enabled = false;
            btn_guardar.BackColor = configColores.btDesactivado;
            btn_buscar.Enabled = true;
            btn_buscar.BackColor = configColores.btnActivo;
            btn_editar.Enabled = true;
            btn_editar.BackColor = configColores.btnActivo;
            btn_eliminar.Enabled = true;
            btn_eliminar.BackColor = configColores.btnActivo;
            btn_cancelar.Enabled = true;
            btn_cancelar.BackColor = configColores.btnActivo;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Hablitar_entradas();
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
            btn_buscar.Enabled = true;
            btn_buscar.BackColor = configColores.btnActivo;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpiar_entradas();
            Deshablitar_entradas();
            ConfigInicialBtn();
        }

        private void ListarDatosComboBoxRol()
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

        private void ListarEmpleado()
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
                ConfigModificacionBtn();
                registroSeleccionado = int.Parse(filaActual.Cells[0].Value.ToString());
                txb_nombres_empleado.Text = filaActual.Cells[1].Value.ToString();
                txb_apellidos_empleado.Text = filaActual.Cells[2].Value.ToString();
                txb_dniEmpleado.Text = filaActual.Cells[3].Value.ToString();
                txb_direccion_empleado.Text = filaActual.Cells[4].Value.ToString();
                txb_correo_empleado.Text = filaActual.Cells[5].Value.ToString();
                txb_telefono_empleado.Text = filaActual.Cells[6].Value.ToString();
                txb_userNamer.Text = filaActual.Cells[7].Value.ToString();

                cmb_rol.SelectedIndex = cmb_rol.FindString(filaActual.Cells[8].Value.ToString()); 
                

                txb_dniEmpleado.Enabled = false;
                txb_apellidos_empleado.Enabled = false;
                txb_nombres_empleado.Enabled = false;
                btn_buscar.Enabled = false;
                btn_buscar.BackColor = configColores.btDesactivado;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = !string.IsNullOrWhiteSpace(txb_nombres_empleado.Text) &&
                                    !string.IsNullOrWhiteSpace(txb_apellidos_empleado.Text) &&
                                    !string.IsNullOrWhiteSpace(txb_dniEmpleado.Text);
            bool datos_User = !string.IsNullOrWhiteSpace(txb_userNamer.Text) &&
                             !string.IsNullOrWhiteSpace(txb_contraseña.Text) &&
                             cmb_rol.SelectedIndex != -1;

            try
            {
                if (datosIngresados && datos_User)
                {
                    entUsuario usuario = new entUsuario
                    {
                        userName = txb_userNamer.Text.Trim(),
                        password = classEncriptar.EncriptarContraseña(txb_contraseña.Text)
                    };
                    entRol rolSelec = (entRol)cmb_rol.SelectedItem;
                    usuario.id_rol = rolSelec.id_rol;
                    usuario.estado = 'A';
                    usuario.id_usuario =  logUser.GetInstancia.insertarUsuario(usuario);

                    if (usuario.id_usuario <= 0)
                    {
                        MessageBox.Show("El usuario ya esta registrado, cambia de USERNAME");
                        return;
                    }

                    entEmpleado empleado = new entEmpleado
                    {
                        Nombre = txb_nombres_empleado.Text.Trim(),
                        Apellido = txb_apellidos_empleado.Text.Trim(),
                        Dni = txb_dniEmpleado.Text.Trim(),
                        Direccion = txb_direccion_empleado.Text.Trim(),
                        Correo = txb_correo_empleado.Text.Trim(),
                        Telefono = txb_telefono_empleado.Text.Trim(),
                        id_usuario = usuario.id_usuario
                    };

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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Limpiar_entradas();
            ListarEmpleado();
            ConfigInicialBtn();
            Deshablitar_entradas();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = !string.IsNullOrWhiteSpace(txb_nombres_empleado.Text) &&
                                    !string.IsNullOrWhiteSpace(txb_apellidos_empleado.Text) &&
                                    !string.IsNullOrWhiteSpace(txb_dniEmpleado.Text);
            bool datos_User = !string.IsNullOrWhiteSpace(txb_userNamer.Text) && cmb_rol.SelectedIndex != -1;

            try
            {
                if (datosIngresados && datos_User && registroSeleccionado > -1)
                {
                    entEmpleado empleado = new entEmpleado
                    {
                        IdEmpleado = registroSeleccionado,
                        Nombre = txb_nombres_empleado.Text.Trim(),
                        Apellido = txb_apellidos_empleado.Text.Trim(),
                        Dni = txb_dniEmpleado.Text.Trim(),
                        Direccion = txb_direccion_empleado.Text.Trim(),
                        Correo = txb_correo_empleado.Text.Trim(),
                        Telefono = txb_telefono_empleado.Text.Trim()
                    };
                    empleado.id_usuario = logEmpleado.GetInstancia.BuscarEmpleadoDNI(empleado.Dni).id_usuario;
                    logEmpleado.GetInstancia.editarEmpleado(empleado);

                    entUsuario usuario = new entUsuario
                    {
                        userName = txb_userNamer.Text.Trim(),
                        password = txb_contraseña.Text
                    };
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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Limpiar_entradas();
            ListarEmpleado();
            ConfigInicialBtn();
            Deshablitar_entradas();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            bool datosIngresados = !string.IsNullOrWhiteSpace(txb_nombres_empleado.Text) &&
                                    !string.IsNullOrWhiteSpace(txb_apellidos_empleado.Text) &&
                                    !string.IsNullOrWhiteSpace(txb_dniEmpleado.Text);

            try
            {
                if (datosIngresados == true && registroSeleccionado > -1)
                {
                    entEmpleado empleado = new entEmpleado
                    {
                        IdEmpleado = registroSeleccionado
                    };
                    logEmpleado.GetInstancia.deshabilitarEmpleado(empleado);

                    entUsuario usuario = new entUsuario
                    {
                        id_usuario = logUser.GetInstancia.buscarUsuario(empleado.IdEmpleado).id_usuario
                    };
                    logUser.GetInstancia.deshabilitarUsuario(usuario);
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

            Limpiar_entradas();
            ListarEmpleado();
            ConfigInicialBtn();
            Deshablitar_entradas();
        }

        private void ValidarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidaciones.ValidarNumero(sender, e);
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

        private void txb_userNamer_Leave(object sender, EventArgs e)
        {

        }
    }
}
