using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Servicios
{
    public class FachadaServiciosEmpleado : IServicio<Empleado>
    {
        private static FachadaServiciosEmpleado instancia;

        private FachadaServiciosEmpleado () {}

        public static FachadaServiciosEmpleado GetInstancia()
        {
            if (instancia == null)
                instancia = new FachadaServiciosEmpleado();
            return instancia;
        }

        public void Crear(Empleado t)
        {
            if (t is Vendedor)
                ServicioVendedor.GetInstancia().Crear((Vendedor)t);
            else if (t is Administrativo)
                ServicioAdministrativo.GetInstancia().Crear((Administrativo)t);
            else if (t is Operario)
                ServicioOperario.GetInstancia().Crear((Operario)t);
        }

        public void Modificar(Empleado t)
        {
            if (t is Vendedor)
                ServicioVendedor.GetInstancia().Modificar((Vendedor)t);
            else if (t is Administrativo)
                ServicioAdministrativo.GetInstancia().Modificar((Administrativo)t);
            else if (t is Operario)
                ServicioOperario.GetInstancia().Modificar((Operario)t);
        }

        public void Eliminar(Empleado t)
        {
            if (t is Vendedor)
                ServicioVendedor.GetInstancia().Eliminar((Vendedor)t);
            else if (t is Administrativo)
                ServicioAdministrativo.GetInstancia().Eliminar((Administrativo)t);
            else if (t is Operario)
                ServicioOperario.GetInstancia().Eliminar((Operario)t);
        }

        public List<Empleado> BuscarTodos()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            
            foreach (Empleado unEmpleado in ServicioAdministrativo.GetInstancia().BuscarTodos())
                listaEmpleados.Add(unEmpleado);
            foreach (Empleado unEmpleado in ServicioVendedor.GetInstancia().BuscarTodos())
                listaEmpleados.Add(unEmpleado);
            foreach (Empleado unEmpleado in ServicioOperario.GetInstancia().BuscarTodos())
                listaEmpleados.Add(unEmpleado);

            return listaEmpleados;
        }
    }
}
