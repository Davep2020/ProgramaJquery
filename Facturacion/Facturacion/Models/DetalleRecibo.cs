//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facturacion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleRecibo
    {
        public int NumeroRecibo { get; set; }
        public int NumeroFacturaAbonada { get; set; }
        public int MontoAbono { get; set; }
    
        public virtual EncabezadoRecibo EncabezadoRecibo { get; set; }
        public virtual EncabezafoFactura EncabezafoFactura { get; set; }
    }
}
