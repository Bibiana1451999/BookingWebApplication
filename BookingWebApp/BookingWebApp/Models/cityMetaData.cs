using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingWebApp.Models
{
    [MetadataType(typeof(cityMetaData))]
    public partial class d_destination
    {


    }
    public class cityMetaData
    {
        [Display(Name = "City")]
        public string d_city { get; set; }

        [Display(Name = "Country")]
        public string d_country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<h_hotel> h_hotel { get; set; }

    }
}