using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingWebApp.Models
{
    [MetadataType(typeof(hotelMetaData))]
    public partial class h_hotel
    {


    }
    public class hotelMetaData
    {
        [Display(Name = "ID")]
        public int h_hotelid { get; set; }
        [Display(Name = "Name")]
        public string h_name { get; set; }

        [Display(Name = "Stars")]
        public int h_stars { get; set; }
        [Display(Name = "Address")]
        public string h_address { get; set; }
        [Display(Name = "ZIP")]
        public int h_zip { get; set; }

        [Display(Name = "City")]
        public string h_d_city { get; set; }
        [Display(Name = "Description")]

        public string h_description { get; set; }
        public string h_d_country { get; set; }

        [Display(Name = "Host")]
        public string h_ho_host { get; set; }

    

        [Display(Name = "City")]
        public virtual d_destination d_destination { get; set; }
        public virtual ho_host ho_host { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_room> r_room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<se_services> se_services { get; set; }
    }
}