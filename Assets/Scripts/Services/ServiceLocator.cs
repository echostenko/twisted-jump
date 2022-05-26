using Data;
using Interfaces;
using Items;
using UnityEngine;

namespace Services
{
    public class ServiceLocator: MonoBehaviour
    {
        public static ServiceLocator instance;
        public IItemPool ItemPool;

        [SerializeField]
        private GameSettings GameSettings;
        private IAssetProvider assetProvider;
        private IItemFactory itemFactory;
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
            ItemPool.Initialize();
            itemSpawner.Initialize();
        }

        private void SetDependencies()
        {
            assetProvider = new AssetProvider();
            itemFactory = new ItemFactory(assetProvider);
            itemPositionService = new ItemPositionService();
            coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            ItemPool = new ItemPool(itemFactory, GameSettings);
            itemSpawner = new ItemSpawner(ItemPool, coroutineRunner, itemPositionService, GameSettings);
        }
    }
}