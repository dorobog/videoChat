//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace videoChat.Views.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class callInfo
    {
        public System.Guid CallInfoId { get; set; }
        public System.Guid CallerId { get; set; }
        public Nullable<System.Guid> ReceiverId { get; set; }
        public string Token { get; set; }
        public string SessionId { get; set; }
        public Nullable<System.DateTime> TimeCallMade { get; set; }
        public Nullable<System.DateTime> TimeCallEnded { get; set; }
        public string TimeCallPicked { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
