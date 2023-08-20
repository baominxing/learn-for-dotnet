using Microsoft.Owin.Hosting;

namespace SampleCode001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                HttpClient client = new HttpClient();
                Console.WriteLine(baseAddress);
                Console.ReadLine();
            }
        }
    }
}