using System;
using System.Threading.Tasks;

namespace SampleApp.PlatformUtility.KeyValueStorage
{
    public interface IPreferencesWrapper
    {
        bool SetData(string key, string value);

        string GetData(string key);

        void RemoveKey(string key);
    }
}
