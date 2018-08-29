using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace MobilePlanningMap
{
public class MwsRestService
    {
        const string API_KEY = "<it's a secret!>"; // API Gateway token
        const string BASE_URI = "https://api.myworksites.co.nz/v1/dev/"; // Production MWS Public API

        /// <summary>
        /// Gets the oldest 100 latest worksites for Auckland Transport
        /// </summary>
        /// <returns>The worksite polygons.</returns>
        public async System.Threading.Tasks.Task<IList<Worksite>> LatestAtWorksitesAsync() {
            var apiEndpoint = "worksite-search?filter=%7B%22where%22%3A%20%7B%22jurisdictionId%22%3A%202%2C%20%22applicationType%22%3A%20%22WORKSITE%22%7D%2C%20%22limit%22%3A%20100%2C%20%22order%22%3A%20%22id%20ASC%22%2C%20%22fields%22%3A%20%7B%22id%22%3A%20true%2C%20%22name%22%3Atrue%2C%20%22location%22%3A%20true%7D%7D";
            IList<Worksite> worksites = new List<Worksite>();
            try
            {
                using (var client = new HttpClient()) {
                    client.DefaultRequestHeaders.Add("x-api-key", API_KEY);
                    client.BaseAddress = new Uri(BASE_URI);
                    var response = await client.GetAsync(apiEndpoint);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        worksites = JsonConvert.DeserializeObject<List<Worksite>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return worksites.Take(100).ToList();
        }


    }
}
