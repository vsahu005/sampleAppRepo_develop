using System;
using System.Threading.Tasks;
using SampleApp.Base.ViewModels;
using SampleApp.Services.MusicFormServices;
using SampleApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using SampleApp.PlatformUtility.KeyValueStorage;
using SampleApp.Constants;
using NetworkAccessLayer.Parser;

namespace SampleApp.ViewModels
{
    public class MusicFormPageViewModel : BaseViewModel
    {

        #region Services
        readonly IMusicFormServices musicFormServices;
        readonly IPreferencesWrapper preferencesWrapper;
        #endregion

        #region Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Properties
        private ObservableCollection<Field> fields;
        public ObservableCollection<Field> Fields
        {
            get => fields;
            set => SetValue(ref fields, value);
        }

        private bool isFormValidated;
        public bool IsFormValidated
        {
            get => isFormValidated;
            set => SetValue(ref isFormValidated, value);
        }

        private string pageTitle;
        public string PageTitle
        {
            get => pageTitle;
            set => SetValue(ref pageTitle, value);
        }
        #endregion

        public MusicFormPageViewModel()
        {
            musicFormServices = IOCContainer.IocRegisterer.Resolve<IMusicFormServices>(default);
            preferencesWrapper = IOCContainer.IocRegisterer.Resolve<IPreferencesWrapper>(default);

            InitCommands();
            LoadFormData();
        }

        private void LoadFormData()
        {
            Task.Run(async () =>
            {
                var musicFormData = await GetMusicFormAsync().ConfigureAwait(false);
                PageTitle = musicFormData.Title;

            });
        }

        private void InitCommands()
        {
            SaveCommand = new Command(async () => await ExecuteSaveCommandAsync().ConfigureAwait(false));
            CancelCommand = new Command(ExecuteCancelCommand);
        }

        #region Command Methods
        private void ExecuteCancelCommand()
        {
            //todo Close the page here
        }

        async Task ExecuteSaveCommandAsync()
        {
            string musicFormJsonString = SaveMusicFormData();
            await ShowAlert(musicFormJsonString).ConfigureAwait(false);

        }

        private static async Task ShowAlert(string musicFormJsonString)
        {
            //All the strings of the app should come from AppResources
            //For single or multiple languages support
            await Application.Current.MainPage.DisplayAlert("Data Saved", musicFormJsonString, "Ok").ConfigureAwait(false);
        }

        private string SaveMusicFormData()
        {
            //Saving Form data in securestorage as json
            var musicFormJsonString = JsonConverter.Serialize(Fields);
            preferencesWrapper.SetData(Constant.SaveMusicFormKey, musicFormJsonString);
            return musicFormJsonString;
        }
        #endregion

        async public Task<MusicForm> GetMusicFormAsync()
        {
            var musicFormData = await musicFormServices.GetMusicFormAsync().ConfigureAwait(false);
            Fields = new ObservableCollection<Field>(musicFormData.Fields);
            return musicFormData;
        }

        public void ValidateForm()
        {
            if (Fields is null || Fields.Count.Equals(default))
            {
                return;
            }

            //Also we can set a validation for rating
            //which should be >0 and <=5 
            IsFormValidated = !(Fields.Any(obj => string.IsNullOrEmpty(obj.Value)));
        }

    }
}
