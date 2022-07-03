using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Platforms
{
    public class PlatformPool : IObjectPool
    {
        private readonly List<GameObject> availableItems = new List<GameObject>();
        private readonly List<GameObject> takenItems = new List<GameObject>();
        private readonly IObjectFactory platformFactory;
        private Transform platformsParent;

        public PlatformPool(IObjectFactory platformFactory, Transform platformsParent)
        {
            this.platformFactory = platformFactory;
            this.platformsParent = platformsParent;
        }

        public void Initialize()
        {
            for (var i = 0; i < 30; i++)
                availableItems.Add(platformFactory.CreateObject(new Vector3(-5000, 5000, 0), platformsParent));
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