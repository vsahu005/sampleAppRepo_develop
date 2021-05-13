using System;
using System.Threading.Tasks;
using NetworkAccessLayer.NetworkAccessServices.MusicFormApiAccessServices;
using NetworkAccessLayer.Parser;
using SampleApp.Extensions.ModelExtensions;
using SampleApp.Models;

namespace SampleApp.Services.MusicFormServices
{
    public class MusicFormServices : IMusicFormServices
    {
        readonly IMusicFormApiServices musicFormApiServices;

        public MusicFormServices(IMusicFormApiServices musicFormApiServices)
        {
            this.musicFormApiServices = musicFormApiServices;
        }

        async public Task<MusicForm> GetMusicFormAsync()
        {
            var musicForm = await musicFormApiServices.GetMusicFormAsync().ConfigureAwait(false);
            return musicForm.ApiObjectToModel();
        }
    }
}
