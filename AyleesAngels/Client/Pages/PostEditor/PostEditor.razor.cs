using AyleesAngels.Shared.Models;
using AyleesAngels.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AyleesAngels.Client.Pages.PostEditor
{
    [Authorize (Roles = "Admin")]
    public partial class PostEditor
    {
        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public string PostId { get; set; }

        public BlogPost ExistingBlogPost { get; set; } = new BlogPost();
        




        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(PostId))
            {
                
                await LoadBlogPost();
            }
        
        }

        
        

        public async Task UpdatePost()
        {
            try
            {
                
                var updatedPost = await ClientFactory.CreateClient("AyleesAngels.ServerAPI")
                        .PutAsJsonAsync<BlogPost>(Urls.UpdateBlogPost.Replace("{id}", PostId), ExistingBlogPost);
                var response = updatedPost.Content.ReadFromJsonAsync<ServiceResponse<BlogPost>>();
                
                NavigationManager.NavigateTo($"viewpost/{PostId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        private async Task LoadBlogPost()
        {
            try
            {

                var client = ClientFactory.CreateClient("AyleesAngels.ServerAPI.Guest");


                var response = await client.GetFromJsonAsync<ServiceResponse<BlogPost>>(Urls.BlogPost.Replace("{id}", PostId));
                ExistingBlogPost = response.Data;
                
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        


    }
}
