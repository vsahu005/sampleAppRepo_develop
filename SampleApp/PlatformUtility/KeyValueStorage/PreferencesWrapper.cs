using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SampleApp.PlatformUtility.KeyValueStorage
{
    public class PreferencesWrapper : IPreferencesWrapper
    {
        public bool SetData(string key, string value)
        {
            bool isStored;
            try
            {
                Preferences.Set(key, value);
                isStored = true;
            }
            catch (ArgumentNullException)
            {
                isStored = false;
            }
            return isStored;
        }

        public string GetData(string key)
        {
            string value;
            try
            {
                value = Preferences.Get(key, string.Empty);
            }
            catch (ArgumentNullException)
            {
                value = string.Empty;
            }

            return value;
        }

        public void RemoveKey(string key)
        {
            Preferences.Remove(key);
        }
    }
}
