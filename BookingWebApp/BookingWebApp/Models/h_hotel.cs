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
    
    public partial class h_hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public h_hotel()
        {
            this.r_room = new HashSet<r_room>();
            this.ra_rating = new HashSet<ra_rating>();
        }
    
        public int h_hotelid { get; set; }
        public string h_name { get; set; }
        public int h_stars { get; set; }
        public string h_address { get; set; }
        public int h_zip { get; set; }
        public string h_d_city { get; set; }
        public string h_description { get; set; }
        public string h_d_country { get; set; }
        public string h_ho_host { get; set; }
        public Nullable<int> h_se_service { get; set; }
    
        public virtual d_destination d_destination { get; set; }
        public virtual ho_host ho_host { get; set; }
        public virtual se_services se_services { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_room> r_room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ra_rating> ra_rating { get; set; }
    }
}
