using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseysOnlineStore.Models
{
    /// <summary>
    /// represents a sellable product
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "use a short descriptive name under 40 characters")]
        public string Name { get; set; }
        //numbers are always required and will default to 0
        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

    }
}