using System;
using System.Threading.Tasks;
using SampleApp.Models;

namespace SampleApp.Services.MusicFormServices
{
    public interface IMusicFormServices
    {
        Task<MusicForm> GetMusicFormAsync();
    }
}
