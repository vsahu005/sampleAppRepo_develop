using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleApp.Base.Views;
using SampleApp.ViewModels;
using Xamarin.Forms;

namespace SampleApp.Views
{
    public partial class MusicFormPage : BaseContentPage
    {
        readonly MusicFormPageViewModel viewModel;
        public MusicFormPage()
        {
            InitializeComponent();
            viewModel = BindingContext as MusicFormPageViewModel;
        }

        void OnValueChanged(object sender, EventArgs e)
        {
            viewModel.ValidateForm();
        }
    }
}
