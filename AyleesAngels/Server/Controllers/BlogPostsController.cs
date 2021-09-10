using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Shared.Models;
using AyleesAngels.Shared.Utils;

using AyleesAngels.Server.Services;


namespace AyleesAngels.Server.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

         
        [HttpGet(Urls.BlogPosts)]
        [AllowAnonymous]
        public async Task<IActionResult> BlogPosts()
        {
            return Ok(await _blogPostService.GetBlogPosts());
            
        }
        [AllowAnonymous]
        [HttpGet(Urls.BlogPost)]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            var blogPost = await _blogPostService.GetBlogPost(id);

            if (blogPost == null)
                return NotFound();

            return Ok(blogPost);
        }

        [HttpPost(Urls.AddBlogPost)]
        [Authorize]
        public async Task<IActionResult> AddBlogPost([FromBody]BlogPost newBlogPost)
        {
            var savedBlogPost = await _blogPostService.AddBlogPost(newBlogPost);
            return Created(new Uri(Urls.BlogPost.Replace("{id}", savedBlogPost.Data.Id.ToString()), UriKind.Relative), savedBlogPost);
        }

        [HttpPut(Urls.UpdateBlogPost)]
        [Authorize]
        public async Task<IActionResult> UpdateBlogPost(int id, [FromBody]BlogPost updatedBlogPost)
        {
            await _blogPostService.UpdateBlogPost(updatedBlogPost);

            return Ok(updatedBlogPost);
        }

        [HttpDelete(Urls.DeleteBlogPost)]
        [Authorize]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var response = await _blogPostService.DeleteBlogPost(id);
             
            return Ok(response);
        }
    }
}
