using System;
using System.Threading.Tasks;
using NetworkAccessLayer.DataObjects;

namespace NetworkAccessLayer.NetworkAccessServices.MusicFormApiAccessServices
{
    public interface IMusicFormApiServices
    {
        Task<MusicForm> GetMusicFormAsync();
    }
}
