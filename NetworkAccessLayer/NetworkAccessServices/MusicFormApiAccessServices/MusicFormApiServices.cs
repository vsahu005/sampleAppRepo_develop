using System;
using System.Threading.Tasks;
using NetworkAccessLayer.DataObjects;
using NetworkAccessLayer.Parser;
using NetworkAccessLayer.StaticJsonHelper;

namespace NetworkAccessLayer.NetworkAccessServices.MusicFormApiAccessServices
{
    public class MusicFormApiServices : IMusicFormApiServices
    {
        public Task<MusicForm> GetMusicFormAsync()
        {
            var musicFormJsonString = StaticDataHelper.GetMusicForm();

            var musicForm = JsonConverter.Serialize<MusicForm>(default, musicFormJsonString);

            return Task.FromResult(musicForm);
        }
    }
}
