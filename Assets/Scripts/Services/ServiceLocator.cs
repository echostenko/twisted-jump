using Items;
using UnityEngine;

namespace Services
{
    public class ServiceLocator: MonoBehaviour
    {
        private IAssetProvider assetProvider;
        private IItemFactory itemFactory;
        private IItemPool itemPool;
        private ItemSpawner itemSpawner;
        private ICoroutineRunner coroutineRunner;
        private ItemPositionService itemPositionService;


        private void Awake() => 
            SetDependencies();

        private void Start()
        {
            itemPool.Initialize();
            itemSpawner.Initialize();
        }

        private void SetDependencies()
        {
            assetProvider = new AssetProvider();
            itemFactory = new ItemFactory(assetProvider);
            itemPositionService = new ItemPositionService();
            itemPool = new ItemPool(itemFactory, itemPositionService);
            coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            itemSpawner = new ItemSpawner(itemPool, coroutineRunner);
        }
    }
}