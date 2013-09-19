using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


using System.ServiceModel;
using System.Text;
using SOAPServices.Dominio;
using SOAPServices.Persistencia;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class FacturaDetalle
    {
       
        [DataMember]
        public FacturaDetallePK PK { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
        [DataMember]
        public decimal Subtotal { get; set; }

    }
     [DataContract]
    public class FacturaDetallePK 
    {
        [DataMember]
        public Factura Factura { get; set; }
        [DataMember]
        public Producto Producto { get; set; }

        public override bool Equals(object obj)
        {
        if (Factura  == ((FacturaDetallePk)obj).Factura ||
          Producto == ((FacturaDetallePk)obj).Producto)
            return true;
         return false;
         }
        public override int GetHashCode()
        {
            return Factura.Numero;
         }
    
    }

   
    
}