using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    static class Functions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static string ObjectToString(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            byte[] bytes = Encoding.Default.GetBytes(json);

            return Convert.ToBase64String(bytes);
        }
        public static T StringToObject<T>(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            string json = Encoding.Default.GetString(bytes);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
