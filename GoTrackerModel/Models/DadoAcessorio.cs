//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoTrackerModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DadoAcessorio
    {
        public int idDadoAcessorio { get; set; }
        public int idDadoLido { get; set; }
        public int DadoSerial { get; set; }
        public int AcessorioSerial { get; set; }
        public Nullable<int> AcessorioBatteryLevel { get; set; }
        public Nullable<int> AcessorioButtonStatus { get; set; }
        public Nullable<int> AcessorioInternalTemperature { get; set; }
    
        public virtual DadoLido DadoLido { get; set; }
    }
}
