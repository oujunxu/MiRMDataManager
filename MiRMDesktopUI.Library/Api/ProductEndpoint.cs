using MiRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiRMDesktopUI.Library.Api
{
    /// <summary>
    /// This class will connect to the endpoint of the api.
    /// </summary>
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;
        public ProductEndpoint(IAPIHelper aPIHelper)
        {
            _apiHelper = aPIHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    //returns the data you are looking for, the access token and the username.
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>(); // set this data inside a static class to make it public.
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            return null;
        }
    }
}
