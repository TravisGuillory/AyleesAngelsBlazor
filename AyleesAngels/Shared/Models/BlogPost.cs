using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyleesAngels.Shared.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Posted { get; set; }
        public string Post { get; set; }
        public string PostSummary
        {
            get
            {
                if (Post?.Length > 50)
                    return Post.Substring(0, 50);

                return Post;
            }
        }
    }
}
