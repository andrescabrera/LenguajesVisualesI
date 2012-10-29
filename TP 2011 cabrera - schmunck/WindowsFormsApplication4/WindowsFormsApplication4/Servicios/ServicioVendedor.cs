using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Servicios
{
    public class ServicioVendedor : Servicio<Vendedor>
    {
        private static ServicioVendedor instancia;

        private ServicioVendedor()
        { }

        public static ServicioVendedor GetInstancia()
        {
            if (instancia == null)
                instancia = new ServicioVendedor();

            return instancia;
        }

        public override void Crear(Vendedor vendedor)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.VendedorPersistenceManager.Alta(vendedor);

                pm.End();
            }
        }

        public override void Modificar(Vendedor vendedor)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.VendedorPersistenceManager.Modificar(vendedor);

                pm.End();
            }
        }

        public override void Eliminar(Vendedor vendedor)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.VendedorPersistenceManager.Eliminar(vendedor);

                pm.End();
            }
        }


        public override List<Vendedor> BuscarTodos()
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                List<Vendedor> vendedores = pm.VendedorPersistenceManager.ListarTodos();

                pm.End();

                return vendedores;
            }
        }
    }
}
