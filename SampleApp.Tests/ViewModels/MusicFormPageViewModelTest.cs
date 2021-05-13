using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SampleApp.Tests.MockIOCRegister;
using SampleApp.ViewModels;

namespace SampleApp.Tests.ViewModels
{
    [TestFixture]
    public class MusicFormPageViewModelTest
    {
        MusicFormPageViewModel viewModel;

        [SetUp]
        public void Setup()
        {
            //intilialize Mock Ioc
            MockIocRegisterer.Init();
        }

        [Test]
        public async Task GetMusicFormAsync_NotNullTest()
        {
            //Arrange
            viewModel = new MusicFormPageViewModel();

            //Act
           var result=await viewModel.GetMusicFormAsync();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
