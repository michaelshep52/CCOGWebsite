using System;
using System.ComponentModel.DataAnnotations;

namespace CCOGWebsite.Models
{
    public class Giving
    {
        public int Id { get; set; }
        [Required]
        [Range(5, 1000, ErrorMessage = "Givings must be between $5 and $1000")]
        public string Amount { get; set; }

        [Required(ErrorMessage ="You must select what your giving is going toward!")]
        public string GivingTowards { get; set; }

        public Giving()
        {
        }
    }
}

