using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MiRMDesktopUI.Library.Models;
using MiRMDesktopUI.Library.Api;


namespace MiRMDesktopUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient { get; set; }
        private ILoggedInUserModel _loggedInUser;

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedInUser = loggedInUser;
        }

        public HttpClient ApiClient {
            get
            {
                return _apiClient;
            }
        }

        //Creates a new HTTPClient which will be used as long as the WPF exists. This to only have one HttpClient open at a time. 
        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        //Creates our form and url content, and post to the token.
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string> ("grant_type","password"),
                new KeyValuePair<string, string> ("username",username),
                new KeyValuePair<string, string> ("password",password)
            });

            using (HttpResponseMessage response = await _apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    //returns the data you are looking for, the access token and the username.
                    var results = await response.Content.ReadAsAsync<AuthenticatedUser>(); // readasasync<string>
                    return results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await _apiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    //returns the data you are looking for, the access token and the username.
                    var results = await response.Content.ReadAsAsync<LoggedInUserModel>(); // set this data inside a static class to make it public.
                    _loggedInUser.CreatedDate = results.CreatedDate;
                    _loggedInUser.EmailAddress = results.EmailAddress;
                    _loggedInUser.FirstName = results.FirstName;
                    _loggedInUser.Id = results.Id;
                    _loggedInUser.LastName = results.LastName;
                    _loggedInUser.Token = token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
