using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using TaxCalcService.Models.Responses;

namespace TaxCalcService.Services
{
    public class BaseClientService
    {
        protected T Get<T>(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "5da2f821eee4035db4771edab942a4cc");

            var response = client.GetAsync(url).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
                catch
                {
                    throw new Exception("An error occurred");
                }
            }

            var taxJarError = JsonConvert.DeserializeObject<TaxJarError>(result);
            throw new Exception($"An error occurred {taxJarError.Detail}");
        }
        
        protected T Post<T>(string json, string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "5da2f821eee4035db4771edab942a4cc");

            var response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
                catch
                {
                    throw new Exception("An error occurred");
                }
            }

            var taxJarError = JsonConvert.DeserializeObject<TaxJarError>(result);
            throw new Exception($"An error occurred {taxJarError.Detail}");
        }
    }
}