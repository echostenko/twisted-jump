using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Items
{
    public class CherryPool : IObjectPool
    {
        private readonly List<GameObject> availableItems = new List<GameObject>();
        private readonly List<GameObject> takenItems = new List<GameObject>();
        private readonly IObjectFactory objectFactory;
        private readonly GameSettings gameSettings;

        public CherryPool(IObjectFactory objectFactory, GameSettings gameSettings)
        {
            this.objectFactory = objectFactory;
            this.gameSettings = gameSettings;
        }

        public void Initialize()
        {
            for (var i = 0; i < gameSettings.ItemsCount; i++)
                availableItems.Add(objectFactory.CreateObject(new Vector3(-5000, 5000, 0)));
        }

        public GameObject GetItemFromPool()
        {
            var cherry = availableItems[0];
            availableItems.Remove(cherry);
            takenItems.Add(cherry);
            cherry.SetActive(true);

            return cherry;
        }

        public void SetItemToPool(GameObject item)
        {
            if (!takenItems.Contains(item))
                return;
            
            availableItems.Add(item);
            takenItems.Remove(item);
            item.SetActive(false);
        }
        
    }
}