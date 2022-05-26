using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Services
{
    public class ItemPool : IItemPool
    {
        private readonly List<GameObject> availableItems = new List<GameObject>();
        private readonly List<GameObject> takenItems = new List<GameObject>();
        private readonly int itemsCount = 10;
        private readonly IItemFactory itemFactory;
        private ItemPositionService itemPositionService;

        public ItemPool(IItemFactory itemFactory, ItemPositionService itemPositionService)
        {
            this.itemFactory = itemFactory;
            this.itemPositionService = itemPositionService;
        }

        public void Initialize()
        {
            for (var i = 0; i < itemsCount; i++)
            {
                var spawnPosition = itemPositionService.GetSpawnPosition();
                availableItems.Add(itemFactory.CreateCherry(spawnPosition));
            } 
        }

        public GameObject GetItemFromPool()
        {
            var cherry = availableItems[0];
            availableItems.Remove(cherry);
            takenItems.Add(cherry);
            cherry.SetActive(true);

            return cherry;
        }

        public void SetItemToPool(GameObject cherry)
        {
            if (!takenItems.Contains(cherry))
                return;
            
            availableItems.Add(cherry);
            takenItems.Remove(cherry);
            cherry.SetActive(false);
        }
        
    }
}