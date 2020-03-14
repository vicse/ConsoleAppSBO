using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SBOConsolaClient
{
    class Program
    {
        static HttpClient client = new HttpClient();
        

        static async Task<HttpStatusCode> PostSendAutomatic()
        {
            HttpResponseMessage response = await client.PostAsync(
                "api/Email/SendAutomatic", null);
            response.EnsureSuccessStatusCode();
            
            return response.StatusCode;
        }

        static void Main(string[] args)
        {

            RunAsync().GetAwaiter().GetResult();

        }

        static async Task RunAsync()
        {            
            client.BaseAddress = new Uri("http://localhost:62288/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            try
            {               
                var responseStatusCode = await PostSendAutomatic();
                Console.WriteLine($"Status del servidor {responseStatusCode}");                                        
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }

    }
}
