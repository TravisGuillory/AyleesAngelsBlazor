using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Server.Data;
using AyleesAngels.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AyleesAngels.Server.Services
{
    public class BlogPostService : IBlogPostService
    {
        
        private readonly BlogPostDbContext _context;

        public BlogPostService(BlogPostDbContext context)
        {
           
            _context = context;
        }

        public async Task<ServiceResponse<List<BlogPost>>> GetBlogPosts()
        {
            ServiceResponse<List<BlogPost>> serviceResponse = new ServiceResponse<List<BlogPost>>();
            
            serviceResponse.Data = await _context.BlogPosts.ToListAsync(); ;
            return serviceResponse;
        }

        public async Task<ServiceResponse<BlogPost>> GetBlogPost(int id)
        {
            ServiceResponse<BlogPost> serviceResponse = new ServiceResponse<BlogPost>();
            serviceResponse.Data = await _context.BlogPosts.FirstOrDefaultAsync(p => p.Id == id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<BlogPost>> AddBlogPost(BlogPost newBlogPost)
        {
            ServiceResponse<BlogPost> serviceResponse = new ServiceResponse<BlogPost>();
            await _context.BlogPosts.AddAsync(newBlogPost);
            await _context.SaveChangesAsync();
            serviceResponse.Data = newBlogPost;

            return serviceResponse;
        }

        public async Task<ServiceResponse<BlogPost>> UpdateBlogPost(BlogPost updatedBlogPost)
        {
            ServiceResponse<BlogPost> serviceResponse = new ServiceResponse<BlogPost>();
            try
            {
                
                _context.Entry(updatedBlogPost).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                serviceResponse.Data = updatedBlogPost;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        

        
        public async Task<ServiceResponse<List<BlogPost>>> DeleteBlogPost(int id)
        {
            ServiceResponse<List<BlogPost>> serviceResponse = new ServiceResponse<List<BlogPost>>();

            try
            {
                var postToDelete = await _context.BlogPosts.FirstOrDefaultAsync(p => p.Id == id);
                _context.BlogPosts.Remove(postToDelete);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.BlogPosts.ToList();
            }
            catch (Exception ex)
            {
                
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            
            return serviceResponse;

        }
    }
}
