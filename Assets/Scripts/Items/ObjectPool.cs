using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class ItemPool : IItemPool
    {
        private readonly List<GameObject> availableItems = new List<GameObject>();
        private readonly List<GameObject> takenItems = new List<GameObject>();
        private readonly IItemFactory itemFactory;
        private readonly GameSettings gameSettings;

        public ItemPool(IItemFactory itemFactory, GameSettings gameSettings)
        {
            this.itemFactory = itemFactory;
            this.gameSettings = gameSettings;
        }

        public void Initialize()
        {
            for (var i = 0; i < gameSettings.ItemsCount; i++)
                availableItems.Add(itemFactory.CreateCherry(new Vector3(-5000, 5000, 0)));
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