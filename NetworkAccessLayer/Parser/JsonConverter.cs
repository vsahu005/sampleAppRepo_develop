using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace NetworkAccessLayer.Parser
{
    public class JsonConverter
    {
        public static T Serialize<T>(T param, string content) where T : new()
        {
            if (string.IsNullOrEmpty(content))
            {
                return param;
            }

            T parsedResponse;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                parsedResponse = (T)ser.ReadObject(stream);
            }
            return parsedResponse;
        }

        public static string Serialize<T>(T item)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}
