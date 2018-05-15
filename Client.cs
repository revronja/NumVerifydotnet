using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;


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

		public class Response
		{
			public bool valid { get; set; }
			public string number { get; set; }
			public string local_format { get; set; }
			public string international_format { get; set; }
			public string country_code { get; set; }
			public string country_name { get; set; }
			public string location { get; set; }
			public string carrier { get; set; }
			public string line_type { get; set; }
			//      "valid": true,
			//"number": "14158586273",
			//"local_format": "4158586273",
			//"international_format": "+14158586273",
			//"country_prefix": "+1",
			//"country_code": "US",
			//"country_name": "United States of America",
			//"location": "Novato",
			//"carrier": "AT&T Mobility LLC",
			//"line_type": "mobile"
		}

		public static async void DownloadPageAsync()
		{
			//Response resp = new Response();
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

				//if (result != null &&
				//	result.Length >= 50)
				//{

					//string json = JsonConvert.SerializeObject(result, Formatting.Indented);
					//try
					//{

					//	resp = JsonConvert.DeserializeObject<Response>(json);
					//}
					//catch (Newtonsoft.Json.JsonSerializationException e)
					//{
					//	Console.WriteLine(e);
					//}

					//Console.WriteLine(resp.valid);
					//Console.WriteLine(resp.carrier);
					//Console.WriteLine(result.Substring(0, 50) + "...");
					//Console.WriteLine(result);

					// return result;

				var exampleModel1 = new JavaScriptSerializer().Deserialize<Dictionary<Response>(result);
			



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










