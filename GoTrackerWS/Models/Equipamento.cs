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
    
    public partial class Equipamento
    {
        public Equipamento()
        {
            this.Veiculoes = new HashSet<Veiculo>();
        }
    
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public string Modelo { get; set; }
        public int SimCardId { get; set; }
    
        public virtual ICollection<Veiculo> Veiculoes { get; set; }
        public virtual SimCard SimCard { get; set; }
    }
}
