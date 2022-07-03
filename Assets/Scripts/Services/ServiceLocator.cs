using Data;
using Interfaces;
using Items;
using Platforms;
using UnityEngine;

namespace Services
{
    public class ServiceLocator: MonoBehaviour
    {
        public static ServiceLocator instance;
        public IObjectPool cherryPool;

        [SerializeField]
        private GameSettings GameSettings;
        private IObjectPool platformPool;
        private IAssetProvider assetProvider;
        private IObjectFactory cherryFactory;
        private IObjectFactory platformFactory;
        private ItemSpawner itemSpawner;
        private ICoroutineRunner coroutineRunner;
        private IItemPositionService itemPositionService;


        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != null) 
                Destroy(gameObject);

            SetDependencies();
            Initialize();
        }

        private void Initialize()
        {
            cherryPool.Initialize();
            platformPool.Initialize();
            itemSpawner.Initialize();
        }

        private void SetDependencies()
        {
            assetProvider = new AssetProvider();
            cherryFactory = new CherryFactory(assetProvider);
            platformFactory = new PlatformFactory(assetProvider);
            itemPositionService = new ItemPositionService();
            coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            cherryPool = new CherryPool(cherryFactory, GameSettings);
            platformPool = new PlatformPool(platformFactory, GameSettings);
            itemSpawner = new ItemSpawner(cherryPool, coroutineRunner, itemPositionService, GameSettings);
        }
    }
}