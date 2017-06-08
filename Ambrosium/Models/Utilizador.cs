//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Utilizador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilizador()
        {
            this.Avaliacao = new HashSet<Avaliacao>();
            this.Sugestao_Estabelecimento = new HashSet<Sugestao_Estabelecimento>();
            this.Sugestao_Produto = new HashSet<Sugestao_Produto>();
            this.Ingrediente = new HashSet<Ingrediente>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string imagem { get; set; }
        public int sugestoes { get; set; }
        public int denuncias { get; set; }
        public Nullable<System.DateTime> suspensao { get; set; }
        public int penalidade { get; set; }
        public string regime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual Regime Regime1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sugestao_Estabelecimento> Sugestao_Estabelecimento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sugestao_Produto> Sugestao_Produto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingrediente> Ingrediente { get; set; }
    }
}
