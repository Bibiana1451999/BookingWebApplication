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
    
    public partial class ra_rating
    {
        public int ra_ratingId { get; set; }
        public Nullable<int> ra_rating1 { get; set; }
        public string ra_comment { get; set; }
        public string ra_u_user { get; set; }
        public Nullable<int> ra_h_hotel { get; set; }
    
        public virtual h_hotel h_hotel { get; set; }
        public virtual u_user u_user { get; set; }
    }
}
