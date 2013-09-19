using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace SOAPServices.Persistencia
{
    public class NHibernateHelper
    {
        private static ISessionFactory _Fabrica;

        private static ISessionFactory Fabrica
        {
            get
            {
                if (_Fabrica == null)
                {

                    var _Conf = new Configuration();
                    _Conf.SetProperty("Conection.provider", "NHibernate");
                    _Conf.SetProperty("Conection.driver_class", "NHibernate.Connection.DriverConnectionProvider");
                    _Conf.SetProperty("Conection.conectio_string", ConexionUtil.ObtenerCadena());
                    _Conf.SetProperty("adonet.batch_size", "10");
                    _Conf.SetProperty("show_sql", "true");
                    _Conf.SetProperty("dialect", "NHibernate.Dialect.MsSql2000Dialect");
                    _Conf.SetProperty("Command_timeout", "60");
                    _Conf.SetProperty("querysubstitution", "true 1, false 0, yes 'Y', No 'N'");
                    _Conf.SetProperty("Conection Provider", "NHibernate");
                    _Conf.AddAssembly(typeof(NHibernateHelper).Assembly);
                    _Fabrica = _Conf.BuildSessionFactory();

                }
                return _Fabrica;
            }

        }

        public static ISession ObtenerSesion()
        {
            return Fabrica.OpenSession();
        }
        public static void CerrarFabrica()
        {
            _Fabrica = null;
        }



    }
}