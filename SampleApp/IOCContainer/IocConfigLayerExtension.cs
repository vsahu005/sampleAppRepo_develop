using System;
using SampleApp.PlatformUtility.KeyValueStorage;
using Unity;
using Unity.Lifetime;

namespace SampleApp.IOCContainer
{
    public static class IocConfigLayerExtension
    {
        public static IUnityContainer RegisterConfigIocContainer(this IUnityContainer unityContainer)
        {
            #region Preferences
            unityContainer.RegisterType<IPreferencesWrapper,
                                        PreferencesWrapper>(new ContainerControlledLifetimeManager());
            #endregion
            return unityContainer;
        }
    }
}
