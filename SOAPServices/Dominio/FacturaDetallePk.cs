using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOAPServices.Dominio
{
    class FacturaDetallePk
    {
        public Producto Producto { get; set; }

        public Factura Factura { get; set; }
    }
}
