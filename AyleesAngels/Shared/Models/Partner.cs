using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AyleesAngels.Shared.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LinkUrl { get; set; }
        public string ImageUrl { get; set; } = null;
    }
}
