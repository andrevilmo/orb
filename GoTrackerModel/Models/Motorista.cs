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
    
    public partial class Motorista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroDOC { get; set; }
        public string CategoriaCNH { get; set; }
        public string Sobrenome { get; set; }
        public System.DateTime VencimentoCNH { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Nullable<int> ClienteId { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
