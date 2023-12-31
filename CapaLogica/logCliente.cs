﻿using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCliente
    {
        #region Singleton
        private static readonly logCliente instancia = new logCliente();
        public static logCliente GetInstancia => instancia;
        #endregion

        #region Metodos

        public List<entCliente> listarClientes() => datCliente.GetInstancia.listarCliente();

        public bool insertarCliente(entCliente cliente) => datCliente.GetInstancia.insertarCliente(cliente);

        public bool editarCliente(entCliente cliente) => datCliente.GetInstancia.editarCliente(cliente);

        public List<entCliente> listarClienteDni(string dni) => datCliente.GetInstancia.listarClienteDni(dni);

        public List<entCliente> listarClienteNombre(string nombre) => datCliente.GetInstancia.listarClienteNombre(nombre);

        public List<entCliente> listarClienteRuc(string ruc) => datCliente.GetInstancia.listarClienteRuc(ruc);

        public bool ValidarDniUnica(string dni) => datCliente.GetInstancia.ValidarDniUnica(dni);

        public bool ValidarRucUnica(string ruc) => datCliente.GetInstancia.ValidarRucUnica(ruc);

        public entCliente buscarClienteId(int id_cliente) => datCliente.GetInstancia.buscarClienteId(id_cliente);

        public bool deshabilitarCliente(int id) => datCliente.GetInstancia.deshabilitarCliente(id);

        #endregion
    }
}
