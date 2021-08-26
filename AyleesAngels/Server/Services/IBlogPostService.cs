using AyleesAngels.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyleesAngels.Server.Services
{
    public interface IBlogPostService
    {
        Task<ServiceResponse<List<BlogPost>>> GetBlogPosts();
        Task<ServiceResponse<BlogPost>> GetBlogPost(int id);
        Task<ServiceResponse<BlogPost>> AddBlogPost(BlogPost newBlogPost);
        Task<ServiceResponse<BlogPost>> UpdateBlogPost(BlogPost updatedBlogPost);
        Task<ServiceResponse<int>> DeleteBlogPost(int id);
    }
}
