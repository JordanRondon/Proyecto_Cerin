
// --------------------------------------------------------------
// Nombre del archivo: preEmpleado.cs
// Descripción: Clase que gestiona la interfaz de usuario para la
//              administración de empleados.
// --------------------------------------------------------------

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
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private int registroSeleccionado = -1;

        public preEmpleado()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        /// <summary>
        /// Inicializa el formulario al cargar.
        /// </summary>
        private void InicializarFormulario()
        {
            ListarDatosComboBoxRol();
            ConfigCabecera();
            Deshablitar_entradas();
            ConfigInicialBtn();
            ListarEmpleado();
            cmb_rol.SelectedIndex = -1;
        }

        /// <summary>
        /// Limpia todas las entradas en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Habilita las entradas en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Deshabilita las entradas en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Configura los botones a su estado inicial.
        /// </summary>
        private void ConfigInicialBtn()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_buscar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, false, configColores.btDesactivado);

        }

        /// <summary>
        /// Configura los botones para la modificación de registros.
        /// </summary>
        private void ConfigModificacionBtn()
        {
            Hablitar_entradas();
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_buscar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_editar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Nuevo".
        /// </summary>
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Hablitar_entradas();
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_buscar, true, configColores.btnActivo);
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Cancelar".
        /// </summary>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpiar_entradas();
            Deshablitar_entradas();
            ConfigInicialBtn();
        }

        /// <summary>
        /// Lista los datos del ComboBox de roles en la interfaz.
        /// </summary>
        private void ListarDatosComboBoxRol()
        {
            cmb_rol.ValueMember = "id_rol";
            cmb_rol.DisplayMember = "nombre";
            cmb_rol.DataSource = logRol.GetInstancia.listarRol();
        }

        /// <summary>
        /// Configura la cabecera de la tabla en la interfaz.
        /// </summary>
        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dataGridView_empleados,new string[] { "Código", "Nombre", "Apellido", "DNI", "Dirreccion", "Correo", "Teléfono", "UserName", "Rol"});
            dataGridView_empleados.Columns[0].Width = 60;
        }

        /// <summary>
        /// Lista los empleados en la interfaz.
        /// </summary>
        private void ListarEmpleado()
        {
            List<entEmpleado> listaEmpleado= logEmpleado.GetInstancia.listarEmpleado();

            dataGridView_empleados.Rows.Clear();

            //insertar los datos 
            foreach (var empleado in listaEmpleado)
            {
                entUsuario usuario;
                entRol rol;

                (usuario, rol) = logEmpleado.GetInstancia.ObtenerDatosEmpleadoId(empleado.IdEmpleado);
                dataGridView_empleados.Rows.Add(
                    empleado.IdEmpleado,
                    empleado.Nombre,
                    empleado.Apellido,
                    empleado.Dni,
                    empleado.Direccion,
                    empleado.Correo,
                    empleado.Telefono,
                    usuario.userName,
                    rol.nombre
                );
            }
        }

        /// <summary>
        /// Maneja el evento de doble clic en una celda de la tabla de empleados.
        /// </summary>
        private void dataGridView_empleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow filaActual = dataGridView_empleados.Rows[e.RowIndex];
                ConfigModificacionBtn();
                registroSeleccionado = int.Parse(filaActual.Cells["Código"].Value.ToString());
                txb_nombres_empleado.Text = filaActual.Cells["Nombre"].Value.ToString();
                txb_apellidos_empleado.Text = filaActual.Cells["Apellido"].Value.ToString();
                txb_dniEmpleado.Text = filaActual.Cells["DNI"].Value.ToString();
                txb_direccion_empleado.Text = filaActual.Cells["Dirreccion"].Value.ToString();
                txb_correo_empleado.Text = filaActual.Cells["Correo"].Value.ToString();
                txb_telefono_empleado.Text = filaActual.Cells["Teléfono"].Value.ToString();
                txb_userNamer.Text = filaActual.Cells["UserName"].Value.ToString();
                cmb_rol.SelectedIndex = cmb_rol.FindString(filaActual.Cells["Rol"].Value.ToString()); 
                

                txb_dniEmpleado.Enabled = false;
                txb_apellidos_empleado.Enabled = false;
                txb_nombres_empleado.Enabled = false;
                btn_buscar.Enabled = false;
                btn_buscar.BackColor = configColores.btDesactivado;
            }
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Guardar".
        /// </summary>
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
                        MessageBox.Show("El \"USERNAME\" ya esta registrado, cambia de USERNAME");
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Editar".
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Eliminar".
        /// </summary>
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

        /// <summary>
        /// Valida la entrada de teclado para permitir solo números.
        /// </summary>
        private void ValidarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidaciones.ValidarNumero(sender, e);
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Buscar".
        /// </summary>
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
