using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace SOAPServices.Persistencia
{
    
    
        public class BaseDAO<Entidad, Id>
        {
            public Entidad Crear(Entidad entidad)
            {
                using (ISession session = NHibernateHelper.ObtenerSesion())
                {
                    session.Save(entidad);
                    session.Flush();
                }
                return entidad;
            }
            public Entidad Obtener(Id id)
            {
                using (ISession session = NHibernateHelper.ObtenerSesion())
                {
                    return session.Get<Entidad>(id);
                }
            }
            public Entidad Modificar(Entidad entidad)
            {
                using (ISession session = NHibernateHelper.ObtenerSesion())
                {

                    session.Update(entidad);
                    session.Flush();

                }
                return entidad;
            }
            public void Eliminar(Entidad entidad)
            {
                using (ISession session = NHibernateHelper.ObtenerSesion())
                {
                    session.Delete(entidad);
                    session.Flush();
                }
            }

            public ICollection<Entidad> ListarTodos() 
            {
                using (ISession session = NHibernateHelper.ObtenerSesion())
                {
                    ICriteria busqueda = session.CreateCriteria(typeof(Entidad));
                    return busqueda.List<Entidad>();
                }
            }

        }

    
}