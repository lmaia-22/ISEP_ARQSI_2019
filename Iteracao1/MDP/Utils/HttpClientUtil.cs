using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectIteration1.Utils
{

    public class FabricPlan
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public List<long> OperationsIds { get; set; }
        public DateTime DateStart { get; set; }
    }

    public class HttpClientUtil
    {
        public static async Task<FabricPlan> GetFabricPlanRequestAsync(string request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44375/api/"); //MDF
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                FabricPlan fabricPlan = null;
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    fabricPlan = await response.Content.ReadAsAsync<FabricPlan>();
                }
                return fabricPlan;
            }
        }
    }
}