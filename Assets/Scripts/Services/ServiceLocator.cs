using Data;
using Interfaces;
using Items;
using Platforms;
using UnityEngine;

namespace Services
{
    public class ServiceLocator
    {
        private readonly GameSettings gameSettings;
        private readonly Transform firstSpawner;
        private readonly Transform secondSpawner;
        private readonly Transform thirdSpawner;
        private readonly Transform platforms;
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

        public ServiceLocator(GameSettings gameSettings, Transform firstSpawner, Transform secondSpawner, Transform thirdSpawner, Transform platforms)
        {
            this.gameSettings = gameSettings;
            this.firstSpawner = firstSpawner;
            this.secondSpawner = secondSpawner;
            this.thirdSpawner = thirdSpawner;
            this.platforms = platforms;
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
            assetProvider = new AssetProvider();
            cherryFactory = new CherryFactory(assetProvider);
            platformFactory = new PlatformFactory(assetProvider);
            itemPositionService = new ItemPositionService();
            coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            cherryPool = new CherryPool(cherryFactory, gameSettings);
            platformPool = new PlatformPool(platformFactory, platforms);
            itemSpawner = new ItemSpawner(cherryPool, coroutineRunner, itemPositionService, gameSettings);
            platformSpawner = new PlatformSpawner(platformPool, coroutineRunner, firstSpawner, secondSpawner, thirdSpawner);
        }
    }
}