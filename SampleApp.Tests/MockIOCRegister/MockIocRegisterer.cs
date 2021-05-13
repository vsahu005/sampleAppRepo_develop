using System;
using CommonServiceLocator;
using NetworkAccessLayer.NetworkAccessServices.MusicFormApiAccessServices;
using SampleApp.PlatformUtility.KeyValueStorage;
using SampleApp.Services.MusicFormServices;
using Unity;
using Unity.ServiceLocation;

namespace SampleApp.Tests.MockIOCRegister
{
    public static class MockIocRegisterer
    {
        public static void Init()
        {
            UnityServiceLocator unityServiceLocator
                = new UnityServiceLocator(MockConfigureUnityContainer());

            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }

        public static T Resolve<T>(T param)
        {
            var service = ServiceLocator.Current.GetInstance<T>();
            return service;
        }

        private static IUnityContainer MockConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();

            //Network Layer
            unityContainer.RegisterType<IMusicFormApiServices, MusicFormApiServices>();

            //Buisness Layer
            unityContainer.RegisterType<IMusicFormServices, MusicFormServices>();
            unityContainer.RegisterType<IPreferencesWrapper, PreferencesWrapper>();
            

            return unityContainer;
        }
    }
}
