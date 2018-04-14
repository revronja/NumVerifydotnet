using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NumVerfifydotnet
{
    public sealed class Client
    {
        

        private Client() { }

        private static Client instance = null;

        private static readonly object _lock = new object();

        public static Client GetInstance()
        {
            /* acquire lock only for first instance creation */
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new Client();
                }
            }
            // otherwise return existing
            return instance;

        }
         public static async void DownloadPageAsync()
        {
            string ak = Config.Getkey();
            string Phonenumber = "14158586273";
            string page = "http://apilayer.net/api/validate?access_key=" + ak +
                "&number=" + Phonenumber;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await
                   client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                if (result != null &&
                    result.Length >= 50)
                {
                    Console.WriteLine(result.Substring(0, 50) + "...");
                   // return result;
                }
            }
        }
    }
}





/*
 * Non-lock version
 * 
    public sealed class Singleton
    {
        // A private constructor to restrict the object creation from outside
        private Singleton()
        {
        }
        // A private static instance of the same class
        private static readonly Singleton instance = null;
        static Singleton()
        {
            // create the instance only if the instance is null
            instance = new Singleton();
        }
        public static Singleton GetInstance()
        {
            // return the already existing instance
            return instance;
        }
    }

*/










