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
    
    public partial class Sugestao_Estabelecimento
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string telefone { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int utilizador { get; set; }
        public int estabelecimento { get; set; }
    
        public virtual Estabelecimento Estabelecimento1 { get; set; }
        public virtual Utilizador Utilizador1 { get; set; }
    }
}