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
    
    public partial class Clientes
    {
        public Clientes()
        {
            this.EncabezadoRecibo = new HashSet<EncabezadoRecibo>();
            this.EncabezafoFactura = new HashSet<EncabezafoFactura>();
        }
    
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<int> SaldoMes { get; set; }
        public Nullable<int> AbonoMes { get; set; }
    
        public virtual ICollection<EncabezadoRecibo> EncabezadoRecibo { get; set; }
        public virtual ICollection<EncabezafoFactura> EncabezafoFactura { get; set; }
    }
}