using CapaEntidad;
using Cerin_Ingenieros.Servicios.Alquiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preAlquiler : Form
    {
        entCliente clienteSelecionado;
        public preAlquiler()
        {
            InitializeComponent();
            inicializarVariablesAux();
        }
        private void inicializarVariablesAux()
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        //Botones
        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();

            clienteSelecionado = preSelectCliente.getCliente();

            if (clienteSelecionado!=null)
            {
                if (clienteSelecionado.Dni != "")
                    lb_dni_ruc_cliente.Text = clienteSelecionado.Dni;
                else
                    lb_dni_ruc_cliente.Text = clienteSelecionado.Ruc;
                lb_apellidos_cliente.Text = clienteSelecionado.Apellido;
                lb_nombres_cliente.Text = clienteSelecionado.Nombre;
                lb_telefono_cliente.Text = clienteSelecionado.Telefono;
            }

        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            preSelectEquipoAlquiler preSelectEquipo = new preSelectEquipoAlquiler();
            preSelectEquipo.ShowDialog();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
