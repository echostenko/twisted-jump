using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GameObject bootstrap;
        public override void InstallBindings()
        {
            BindBootstrap();
            BindServiceLocator();
        }

        private void BindBootstrap() => 
            Container.Bind<GameObject>().WithId("Bootstrap").FromInstance(bootstrap);

        private void BindServiceLocator()
        {
            Container.Bind<ServiceLocator>().AsSingle();
        }
    }
}