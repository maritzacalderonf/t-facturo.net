using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPServices.Dominio;

namespace SOAPServices.Persistencia
{
    public class FacturaDAO : BaseDAO<Factura, int>
    {

        internal Dominio.Factura Modificar(Dominio.Factura factura)
        {
            throw new NotImplementedException();
        }

        internal Dominio.Factura Crear(Dominio.Factura factura)
        {
            throw new NotImplementedException();
        }
    }

    public class FacturaDetalleDAO : BaseDAO<FacturaDetalle, FacturaDetallePK>
    {

        internal void Crear(Dominio.FacturaDetalle facturaDetalle)
        {
            throw new NotImplementedException();
        }
    }
}