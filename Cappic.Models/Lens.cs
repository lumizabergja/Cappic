using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Cappic.Models
{
    public class Lens
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }


    }
}
