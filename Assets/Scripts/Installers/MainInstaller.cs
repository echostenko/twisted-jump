using Data;
using Interfaces;
using Items;
using Platforms;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private ScriptableObject gameSettings;
        public override void InstallBindings()
        {
            BindAssetProvider();
            BindCherryFactory();
            BindPlatformFactory();
            BindCherryPool();
            BindGameSettings();
            BindItemPositionService();
            BindPlatformSpawner();
        }

        private void BindPlatformSpawner() => 
            Container.Bind<PlatformSpawner>().AsSingle();

        private void BindItemPositionService() => 
            Container.Bind<IItemPositionService>().To<ItemPositionService>().AsSingle();

        private void BindGameSettings() => 
            Container.Bind<GameSettings>().FromScriptableObject(gameSettings).AsSingle();

        private void BindCherryPool() => 
            Container.Bind<CherryPool>().AsSingle();

        private void BindPlatformFactory() => 
            Container.Bind<PlatformFactory>().AsSingle();

        private void BindCherryFactory() => 
            Container.Bind<CherryFactory>().AsSingle();

        private void BindAssetProvider() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }
}