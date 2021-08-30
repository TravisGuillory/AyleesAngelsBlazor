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
    [Authorize]
    public partial class PostEditor : ComponentBase
    {
        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public string PostId { get; set; }

        public AyleesAngels.Shared.Models.BlogPost ExistingBlogPost { get; set; } = new AyleesAngels.Shared.Models.BlogPost();
        




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
                Console.WriteLine("Editing POst");
                var updatedPost = await ClientFactory.CreateClient("AyleesAngels.ServerAPI")
                        .PutAsJsonAsync<AyleesAngels.Shared.Models.BlogPost>(Urls.UpdateBlogPost.Replace("{id}", PostId), ExistingBlogPost);
                var response = updatedPost.Content.ReadFromJsonAsync<ServiceResponse<AyleesAngels.Shared.Models.BlogPost>>();
                
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


                var response = await client.GetFromJsonAsync<ServiceResponse<AyleesAngels.Shared.Models.BlogPost>>(Urls.BlogPost.Replace("{id}", PostId));
                ExistingBlogPost = response.Data;
                
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        


    }
}
