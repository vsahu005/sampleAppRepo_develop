using System;
using System.Threading.Tasks;
using NetworkAccessLayer.NetworkAccessServices.MusicFormApiAccessServices;
using NUnit.Framework;
using SampleApp.Services.MusicFormServices;
using SampleApp.Tests.MockIOCRegister;

namespace SampleApp.Tests.Services
{
    [TestFixture]
    public class MusicFormServicesTest
    {
         IMusicFormServices musicFormServices;

        [SetUp]
        public void Setup()
        {
            //intilialize Mock Ioc
            MockIocRegisterer.Init();
            //intilialize ViewModel 
            musicFormServices = MockIocRegisterer.Resolve<IMusicFormServices>(null);
        }

        [Test]
        public async Task GetMusicFormAsync_NotNullTest()
        {
            //Act
            var result =await musicFormServices.GetMusicFormAsync();
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
