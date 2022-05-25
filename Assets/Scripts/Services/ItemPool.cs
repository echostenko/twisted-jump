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

        public ItemPool(IItemFactory itemFactory) => 
            this.itemFactory = itemFactory;

        public void Initialize()
        {
            for (int i = 0; i < itemsCount; i++) 
                availableItems.Add(itemFactory.CreateCherry(new Vector3(0, 0, 0)));
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