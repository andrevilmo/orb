//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoTrackerWS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Veiculo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int MotoristaId { get; set; }
        public int ClienteId { get; set; }
        public int Equipamento_Id { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Equipamento Equipamento { get; set; }
        public virtual Motorista Motorista { get; set; }
    }
}
