using Data;
using Interfaces;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GameObject bootstrap;
        [SerializeField] private GameObject firstSpawner;
        [SerializeField] private GameObject secondSpawner;
        [SerializeField] private GameObject thirdSpawner;
        [SerializeField] private GameObject platforms;
        [SerializeField] private GameSettings gameSettings;
        public override void InstallBindings()
        {
            BindBootstrap();
            BindServiceLocator();
            BindGameSettings();
            BindPlatformParents();
            BindAssetProvider();
        }

        private void BindAssetProvider() => 
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindPlatformParents()
        {
            Container.Bind<GameObject>().WithId("FirstSpawner").FromInstance(firstSpawner);
            Container.Bind<GameObject>().WithId("SecondSpawner").FromInstance(secondSpawner);
            Container.Bind<GameObject>().WithId("ThirdSpawner").FromInstance(thirdSpawner);
            Container.Bind<GameObject>().WithId("Platforms").FromInstance(platforms);
        }

        private void BindGameSettings() => 
            Container.Bind<GameSettings>().FromScriptableObject(gameSettings).AsSingle();

        private void BindBootstrap() => 
            Container.Bind<GameObject>().WithId("Bootstrap").FromInstance(bootstrap);

        private void BindServiceLocator()
        {
            Container.Bind<ServiceLocator>().AsSingle();
        }
    }
}