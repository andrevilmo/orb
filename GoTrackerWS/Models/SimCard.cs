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
    
    public partial class SimCard
    {
        public SimCard()
        {
            this.Equipamentoes = new HashSet<Equipamento>();
        }
    
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string PIN { get; set; }
        public string PUK { get; set; }
        public string ICCID { get; set; }
        public string PlanoDados { get; set; }
    
        public virtual ICollection<Equipamento> Equipamentoes { get; set; }
    }
}
