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
    
    public partial class crud_VisitaRead_Result
    {
        public int ID { get; set; }
        public int idUsuario { get; set; }
        public System.DateTime fechaHoraInicio { get; set; }
        public System.DateTime fechaHoraFinal { get; set; }
        public string ubicacionGPS { get; set; }
        public int idCliente { get; set; }
        public string estado { get; set; }
    }
}