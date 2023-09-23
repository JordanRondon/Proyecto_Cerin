using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logEmpleado
    {
        #region Singleton
        private static readonly logEmpleado instancia = new logEmpleado();
        public static logEmpleado GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entEmpleado> listarEmpleado() => datEmpleado.GetInstancia.listarEmpleado();

        public bool insertaEmpleado(entEmpleado empleado) => datEmpleado.GetInstancia.insertarEmpleado(empleado);

        public bool editarEmpleado(entEmpleado empleado) => datEmpleado.GetInstancia.editarEmpleado(empleado);

        public bool deshabilitarEmpleado(entEmpleado empleado) => datEmpleado.GetInstancia.deshabilitarEmpleado(empleado);

        public entEmpleado BuscarEmpleadoId(int id) => datEmpleado.GetInstancia.BuscarEmpleadoId(id);

        public entEmpleado BuscarEmpleadoDNI(string dni) => datEmpleado.GetInstancia.BuscarEmpleadoDNI(dni);
        #endregion
    }
}
