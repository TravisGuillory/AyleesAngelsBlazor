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

namespace AyleesAngels.Client.Pages
{ 
    [Authorize]
    public partial class EditPartner :ComponentBase
    {
        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        

        [Parameter]
        public string PartnerId { get; set; }

        public Partner ExistingPartner { get; set; } = new Partner();





        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(PartnerId))
            {

                await LoadPartner();
            }

        }




        public async Task UpdatePartner()
        {
            try
            {

                var updatedPartner = await ClientFactory.CreateClient("AyleesAngels.ServerAPI")
                        .PutAsJsonAsync<Partner>(Urls.UpdatePartner.Replace("{id}", PartnerId), ExistingPartner);
                var response = updatedPartner.Content.ReadFromJsonAsync<ServiceResponse<Partner>>();

                NavigationManager.NavigateTo($"partners");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private async Task LoadPartner()
        {
            try
            {

                var client = ClientFactory.CreateClient("AyleesAngels.ServerAPI.Guest");


                var response = await client.GetFromJsonAsync<ServiceResponse<Partner>>(Urls.Partner.Replace("{id}", PartnerId));
                ExistingPartner = response.Data;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }



    }
}

