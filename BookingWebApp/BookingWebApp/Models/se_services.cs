//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class se_services
    {
        public int se_serviceid { get; set; }
        public string se_services1 { get; set; }
        public int se_h_hotel { get; set; }
    
        public virtual h_hotel h_hotel { get; set; }
    }
}