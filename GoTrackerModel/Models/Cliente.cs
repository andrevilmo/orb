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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Usuarios = new HashSet<Usuario>();
            this.Perfils = new HashSet<Perfil>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ClienteId { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string WebSite { get; set; }
        public string Observacoes { get; set; }
    
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual Cliente ClientePai { get; set; }
        public virtual Cliente ClienteFilhoDe { get; set; }
        public virtual SimCard SimCard { get; set; }
        public virtual ICollection<Perfil> Perfils { get; set; }
    }
}
