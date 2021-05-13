using System;
using CommonServiceLocator;
using Unity;
using Unity.ServiceLocation;

namespace SampleApp.IOCContainer
{
    public class IocRegisterer
    {
        public static void Init()
        {
            UnityServiceLocator unityServiceLocator = new UnityServiceLocator(ConfigureUnityContainer());

            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }

        public static T Resolve<T>(T param)
        {
            var service = ServiceLocator.Current.GetInstance<T>();
            return service;
        }

        private static IUnityContainer ConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterMusicIocContainer();
            unityContainer.RegisterConfigIocContainer();

            return unityContainer;
        }
    }
}
