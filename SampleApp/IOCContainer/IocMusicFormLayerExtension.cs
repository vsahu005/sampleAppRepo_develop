using System;
using NetworkAccessLayer.NetworkAccessServices.MusicFormApiAccessServices;
using SampleApp.Services.MusicFormServices;
using Unity;
using Unity.Lifetime;

namespace SampleApp.IOCContainer
{
    public static class IocMusicFormLayerExtension
    {
        public static IUnityContainer RegisterMusicIocContainer(this IUnityContainer unityContainer)
        {
            //Network Layer
            unityContainer.RegisterType<IMusicFormApiServices,
                                        MusicFormApiServices>(new ContainerControlledLifetimeManager());

            //Buisness Layer
            unityContainer.RegisterType<IMusicFormServices,
                                       MusicFormServices>(new ContainerControlledLifetimeManager());

            return unityContainer;
        }
    }
}
