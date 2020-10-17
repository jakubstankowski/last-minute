using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();



        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            // client.BaseAddress = new Uri("http://localhost:5000/api/auth/login");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string content = "{\"childrenBirthdays\":[],\"durationFrom\":6,\"durationTo\":14,\"filters\":[{\"filterId\":\"additionalType\",\"selectedValues\":[\"GT03#TUZ-LAST25\"]}],\"metaData\":{\"page\":0,\"pageSize\":30,\"sorting\":\"flightDate\"},\"numberOfAdults\":2,\"offerType\":\"BY_PLANE\",\"site\":\"last-minute?pm_source=MENU&pm_name=Last_Minute\"}";
            var result = await client.PostAsync("https://www.tui.pl/search/offers", new StringContent(content, Encoding.UTF8, "application/json"));

            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);


        }



    }


}

