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
    
    public partial class Galeria
    {
        public int id { get; set; }
        public string path { get; set; }
        public int estabelecimento { get; set; }
    
        public virtual Estabelecimento Estabelecimento1 { get; set; }
    }
}
