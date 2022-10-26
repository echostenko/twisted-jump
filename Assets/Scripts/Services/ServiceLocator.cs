using Data;
using Interfaces;
using Items;
using Platforms;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ServiceLocator
    {
        private readonly GameSettings gameSettings;
        private readonly GameObject firstSpawner;
        private readonly GameObject secondSpawner;
        private readonly GameObject thirdSpawner;
        private readonly GameObject platforms;
        public static ServiceLocator instance;
        public IObjectPool cherryPool;
        public IObjectPool platformPool;

        private IAssetProvider assetProvider;
        private IObjectFactory cherryFactory;
        private IObjectFactory platformFactory;
        private ItemSpawner itemSpawner;
        private PlatformSpawner platformSpawner;
        private ICoroutineRunner coroutineRunner;
        private IItemPositionService itemPositionService;

        [Inject]
        public ServiceLocator(GameSettings gameSettings, 
            [Inject(Id = "FirstSpawner")] GameObject firstSpawner, 
            [Inject(Id = "SecondSpawner")] GameObject secondSpawner, 
            [Inject(Id = "ThirdSpawner")] GameObject thirdSpawner, 
            [Inject(Id = "Platforms")] GameObject platforms,
            IAssetProvider assetProvider)
        {
            this.gameSettings = gameSettings;
            this.firstSpawner = firstSpawner;
            this.secondSpawner = secondSpawner;
            this.thirdSpawner = thirdSpawner;
            this.platforms = platforms;
            this.assetProvider = assetProvider;
        }

        public void Initialize()
        {
            if (instance == null)
                instance = this;
            else if (instance != null) 
                return;

            SetDependencies();
            InitializeServices();
        }

        private void InitializeServices()
        {
            cherryPool.Initialize();
            platformPool.Initialize();
            itemSpawner.Initialize();
            platformSpawner.Initialize();
        }

        private void SetDependencies()
        {
            cherryFactory = new CherryFactory(assetProvider);
            platformFactory = new PlatformFactory(assetProvider);
            itemPositionService = new ItemPositionService();
            coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            cherryPool = new CherryPool(cherryFactory, gameSettings);
            platformPool = new PlatformPool(platformFactory, platforms.transform);
            itemSpawner = new ItemSpawner(cherryPool, coroutineRunner, itemPositionService, gameSettings);
            platformSpawner = new PlatformSpawner(platformPool, coroutineRunner, firstSpawner.transform, secondSpawner.transform, thirdSpawner.transform);
        }
    }
}