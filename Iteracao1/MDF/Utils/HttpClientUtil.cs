using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectIteration1.Utils
{

    public class Operation
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }

    public class HttpClientUtil
    {
        public static async Task<Operation> GetOperationRequestAsync(string request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44376/api/"); //MDP
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Operation operation = null;
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    operation = await response.Content.ReadAsAsync<Operation>();
                }
                return operation;
            }
        }
    }
}