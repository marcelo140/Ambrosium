﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ambrosium.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ambrosium_bdEntities2 : DbContext
    {
        public ambrosium_bdEntities2()
            : base("name=ambrosium_bdEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Estabelecimento> Estabelecimento { get; set; }
        public virtual DbSet<Galeria> Galeria { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Regime> Regime { get; set; }
        public virtual DbSet<Sugestao_Estabelecimento> Sugestao_Estabelecimento { get; set; }
        public virtual DbSet<Sugestao_Produto> Sugestao_Produto { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
    }
}
