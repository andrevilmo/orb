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
    
    public partial class Perfil
    {
        public Perfil()
        {
            this.Usuarios = new HashSet<Usuario>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AcessoClientes { get; set; }
        public int AcessoMotoristas { get; set; }
        public int AcessoEquipamentos { get; set; }
        public int AcessoSimCard { get; set; }
        public int AcessoUsuario { get; set; }
        public int AcessoVeiculo { get; set; }
        public int AcessoPerfil { get; set; }
    
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}