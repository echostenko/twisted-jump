using Data;
using Interfaces;
using Items;
using UnityEngine;

namespace Services
{
    public class ServiceLocator: MonoBehaviour
    {
        [SerializeField]
        private GameSettings GameSettings;
        
        private IAssetProvider assetProvider;
        private IItemFactory itemFactory;
        private IItemPool itemPool;
        private ItemSpawner itemSpawner;
        private ICoroutineRunner coroutineRunner;
        private IItemPositionService itemPositionService;


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
            coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            itemPool = new ItemPool(itemFactory, GameSettings);
            itemSpawner = new ItemSpawner(itemPool, coroutineRunner, itemPositionService, GameSettings);
        }
    }
}