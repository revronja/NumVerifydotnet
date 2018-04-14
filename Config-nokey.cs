
namespace NumVerfifydotnet
{


    public sealed class Config
    {
        private Config() { }

        private static Config instance = null;

        private static readonly object _lock = new object();

        private static string APIKey = "";

        public static Config GetInstance()
        {
            /* acquire lock only for first instance creation */
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new Config();
                }
            }
            // otherwise return existing
            return instance;

        }
        public static string Getkey()
        {
            return APIKey;
        }
    }
}

