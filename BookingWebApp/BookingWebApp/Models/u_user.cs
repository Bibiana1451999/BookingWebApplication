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
    
    public partial class u_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public u_user()
        {
            this.ra_rating = new HashSet<ra_rating>();
            this.re_reservation = new HashSet<re_reservation>();
        }
    
        public string u_username { get; set; }
        public string u_firstName { get; set; }
        public string u_lastName { get; set; }
        public string u_password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ra_rating> ra_rating { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<re_reservation> re_reservation { get; set; }
    }
}
