//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI_Sared.Models.API
{
    using System;
    using System.Collections.Generic;
    
    public partial class TelefonoCliente
    {
        public int ID { get; set; }
        public int idCliente { get; set; }
        public int idTipoTelefono { get; set; }
        public string telefono { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual TipoTelefono TipoTelefono { get; set; }
    }
}
