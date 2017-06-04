using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingWebApp.Models
{
    [MetadataType(typeof(userMetaData))]
    public partial class u_user
    {


    }
    public class userMetaData
    {
        [Display(Name = "Username")]
        public string u_username { get; set; }

        [Display(Name = "Firstname")]
        public string u_firstName { get; set; }
        [Display(Name = "Lastname")]
        public string u_lastName { get; set; }
        public string u_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ra_rating> ra_rating { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<re_reservation> re_reservation { get; set; }

    }
}