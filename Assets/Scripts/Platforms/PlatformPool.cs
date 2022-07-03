using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Platforms
{
    public class PlatformPool : IObjectPool
    {
        private readonly List<GameObject> availableItems = new List<GameObject>();
        private readonly List<GameObject> takenItems = new List<GameObject>();
        private readonly IObjectFactory platformFactory;
        private readonly GameSettings gameSettings;

        public PlatformPool(IObjectFactory platformFactory, GameSettings gameSettings)
        {
            this.platformFactory = platformFactory;
            this.gameSettings = gameSettings;
        }

        public void Initialize()
        {
            for (var i = 0; i < gameSettings.ItemsCount; i++)
                availableItems.Add(platformFactory.CreateObject(new Vector3(-5000, 5000, 0)));
        }

        public GameObject GetItemFromPool()
        {
            var platform = availableItems[0];
            availableItems.Remove(platform);
            takenItems.Add(platform);
            platform.SetActive(true);

            return platform;
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