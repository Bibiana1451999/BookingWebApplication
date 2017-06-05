using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingWebApp.Models
{
    [MetadataType(typeof(roomMetaData))]
    public partial class r_room
    {


    }
    public class roomMetaData
    {
        [Display(Name = "NumberOfRooms")]
        public int r_number { get; set; }

        [Display(Name = "Hotel")]
        public int r_h_hotel { get; set; }

        [Display(Name = "Beds")]
        public Nullable<int> r_beds { get; set; }

        [Display(Name = "Price")]
        public Nullable<decimal> r_price { get; set; }

        [Display(Name = "Description")]
        public string r_description { get; set; }
        [Display(Name = "TypeOfRoom")]

        public string r_tr_typeOfRoom { get; set; }

        [Display(Name = "Hotel")]
        public virtual h_hotel h_hotel { get; set; }

        [Display(Name = "TypeOfRoom")]
        public virtual tr_typeOfRoom tr_typeOfRoom { get; set; }
       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]


    }

}
