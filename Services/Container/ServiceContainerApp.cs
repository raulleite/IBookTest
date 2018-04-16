using DomainBook.UnitOfWork;
using Infrastructure.UnitOfWork;
using Services.Interface;
using Services.Service;
using Unity;

namespace Services.Container
{
    public static class ServiceContainersApp
    {
        private static IUnityContainer UnityContainer = new UnityContainer();

        private static void RegisterTypes()
        {
            UnityContainer.RegisterType<IUnitOfWorkBook, UnitOfWorkBook>();
            UnityContainer.RegisterType<IServiceBook, ServiceForBook>();
        }

        public static T Resolve<T>()
        {
            RegisterTypes();
            return UnityContainer.Resolve<T>();
        }
    }
}