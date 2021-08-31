using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using AyleesAngels.Shared.Models;
using AyleesAngels.Shared.Utils;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace AyleesAngels.Client.Pages
{
    public partial class ViewPost
    {
        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string PostId { get; set; }

        public BlogPost BlogPost { get; set; } = new BlogPost();

        protected override async Task OnInitializedAsync()
        {
            await LoadBlogPost();

        }

        private async Task LoadBlogPost()
        {
            try
            {

                var client = ClientFactory.CreateClient("AyleesAngels.ServerAPI.Guest");
                var response = await client.GetFromJsonAsync<ServiceResponse<BlogPost>>(Urls.BlogPost.Replace("{id}", PostId));
                BlogPost = response.Data;

                
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex);
            }
        }

        private async Task DeletePost()
        {
            await ClientFactory.CreateClient("AyleesAngels.ServerAPI").DeleteAsync(Urls.DeleteBlogPost.Replace("{id}",PostId));
            
            NavigationManager.NavigateTo("/");
        }

        
    }
}