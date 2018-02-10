using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Departure address")]
        [Required]
        public string destinationAddress { get; set; }

        [Display(Name = "Destination address")]
        [Required]
        public string departureAddress { get; set; }

        [Display(Name = "Phone number")]
        public string clientPhoneNumber { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string date { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public string time { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }
    }

    public class OrderDBContext: DbContext
    {
        public DbSet<Order> orders { get; set; }
    }
}
