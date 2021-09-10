using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyleesAngels.Shared.Utils
{
    public class Urls
    {
        public const string BlogPosts = "api/blogposts";
        public const string BlogPost = "api/blogposts/{id}";
        public const string AddBlogPost = "api/blogposts";
        public const string UpdateBlogPost = "api/blogpost/{id}";
        public const string EditBlogPost = "api/blogpost/{id}";
        public const string DeleteBlogPost = "api/blogpost/{id}";
        
        public const string Partners = "api/partners";
        public const string Partner = "api/partners/{id}";
        public const string AddPartner = "api/partners";
        public const string UpdatePartner = "api/partners/{id}";
        public const string EditPartner = "api/partner/{id}";
        public const string DeletePartner = "api/partners/{id}";

        public const string Officers = "api/officers";
        public const string Officer = "api/officers/{id}";
        public const string AddOfficer = "api/officers";
        public const string UpdateOfficer = "api/officer/{id}";
        public const string EditOfficer = "api/officer/{id}";
        public const string DeleteOfficer = "api/officers/{id}";
    }
}
