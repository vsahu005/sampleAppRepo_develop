using System;
using System.IO;
using System.Reflection;

namespace NetworkAccessLayer.Parser
{
    public static class JsonParser
    {
        public static string ParseJsonFromFile(string fileName)
        {
            var assembly = typeof(JsonParser).GetTypeInfo().Assembly;
            Stream stream;
            stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{fileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                return jsonString;
            }
        }
    }
}
