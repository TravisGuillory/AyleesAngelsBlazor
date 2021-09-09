using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyleesAngels.Shared.Models
{
    public class Officer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string? Relation { get; set; }
        public string Story { get; set; }
        public string ImageUrl { get; set; }
    }
}
