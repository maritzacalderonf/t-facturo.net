using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPServices.Dominio;
using SOAPServices.Persistencia;

namespace SOAPServices
{
    public class FacturacionService : IFacturacionService
    {
            private  ClienteDAO clienteDAO = new ClienteDAO();
            private  ProductoDAO productoDAO = new ProductoDAO();
            private  FacturaDAO facturaDAO = new FacturaDAO();
            private  FacturaDetalleDAO facturaDetalleDAO = new FacturaDetalleDAO();

        public Factura Facturar(int rucCliente, List<Item> items)
        {
        Cliente cliente = clienteDAO.Obtener(rucCliente);
         if (cliente == null)
            throw new FaultException<ClienteInexistenteError>(
                new ClienteInexistenteError()
                {
                    CodigoError =10,
                    MensajeError = "El cliente con RUC" + rucCliente + "no existe."
                }
                );

         Factura factura = new Factura()
         {
             Cliente = cliente,
             Fecha = DateTime.Now,
             Total = 0m
         };

         factura = facturaDAO.Crear(factura);
         Producto producto = null;
         FacturaDetalle facturaDetalle = null; 
         decimal total = 0m;
         foreach (Item item in items)
          {

                producto = productoDAO.Obtener(item.CodigoProducto);
                facturaDetalle = new FacturaDetalle()
                {
                    PK = new FacturaDetallePK()
                    {
                        Factura = factura,
                        Producto = producto
                    },
                    Cantidad = item.Cantidad,
                    Subtotal = item.Cantidad * producto.Precio
                };
                total = total + facturaDetalle.Subtotal;
                
                facturaDetalleDAO.Crear(facturaDetalle);
          }

        factura.Total= total;
        factura = facturaDAO.Modificar(factura);
        return factura;

        }
        public ICollection<Factura> ListarFacturas()
        {
            return facturaDAO.ListarTodos();
            //dfg
        }
   }
    
}
