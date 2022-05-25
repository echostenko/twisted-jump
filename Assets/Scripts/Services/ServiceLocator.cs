using Items;
using UnityEngine;

namespace Services
{
    public class ServiceLocator: MonoBehaviour
    {
        private IAssetProvider assetProvider;
        private IItemFactory itemFactory;
        private IItemPool itemPool;


        private void Awake()
        {
            assetProvider = new AssetProvider();
            itemFactory = new ItemFactory(assetProvider);
            itemPool = new ItemPool(itemFactory);
        }

        private void Start()
        {
            itemPool.Initialize();
        }
    }
}