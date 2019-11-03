using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeWepAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic productDynamic = new ExpandoObject();
            GetProductsAsync(productDynamic);

            //var a = productDynamic.Name;

            //Console.WriteLine(a);

            Console.ReadLine();
        }

        static async Task GetProductsAsync(dynamic Product)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:6497/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(Product), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.GetAsync("/api/products");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data Retrieved");
            }
            else
            {
                Console.WriteLine($"Failed to Get data. Status code:{response.StatusCode}");
            }
        }


    }
}
