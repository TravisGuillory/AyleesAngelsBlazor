using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AyleesAngels.Shared.Models;
using AyleesAngels.Shared.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace AyleesAngels.Client.Pages
{
    [Authorize (Roles = "Admin")]
    public partial class AddPost
    {
        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }  
        
        


        public string Post { get; set; }
        public string Title { get; set; }
        public  string PostImage { get; set; }


         
        


        public async Task SavePost()
        {
            var userName = AuthenticationState.Result.User.Identity.Name;
            

            var newPost = new BlogPost()
            {
                Title = Title,
                Author = userName,
                Post = Post,
                PostImage = PostImage,
                Posted = DateTime.Now
            };

            var savedPost = await ClientFactory.CreateClient("AyleesAngels.ServerAPI").PostAsJsonAsync<BlogPost>(Urls.AddBlogPost, newPost);
            var response = await savedPost.Content.ReadFromJsonAsync<ServiceResponse<BlogPost>>();
            int savedPostId = response.Data.Id;
            NavigationManager.NavigateTo($"viewpost/{savedPostId}");



        }
    }
}
