using System;
namespace NetworkAccessLayer.StaticJsonHelper
{
    public static class StaticDataHelper
    {
        public static string GetMusicForm()
        {
            return Parser.JsonParser.ParseJsonFromFile("music_form.json");
        }
    }
}
