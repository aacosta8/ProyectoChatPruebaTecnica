//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatPruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int id { get; set; }
        public int idRoom { get; set; }
        public int idUser { get; set; }
        public string text { get; set; }
        public int idState { get; set; }
        public System.DateTime date_created { get; set; }
    
        public virtual Room Room { get; set; }
        public virtual State State { get; set; }
        public virtual User User { get; set; }
    }
}