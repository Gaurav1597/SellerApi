using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerApi.Models
{
    public class Sellerslist
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string sellername { get; set; }
        [Required]
        public string company { get; set; }
        [Required]
        public string producttype { get; set; }
        [Required]
        public string commission { get; set; }
    }
}
