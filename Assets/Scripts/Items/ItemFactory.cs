using Interfaces;
using Services;
using Unity.Mathematics;
using UnityEngine;

namespace Items
{
    public class ItemFactory : IItemFactory
    {
        private readonly IAssetProvider assetProvider;
        private const string cherryPath = "Prefabs/Items/Cherry";

        public ItemFactory(IAssetProvider assetProvider) => 
            this.assetProvider = assetProvider;

        public GameObject CreateCherry(Vector3 position, Transform parent = null) =>
            Object.Instantiate(assetProvider.Load<GameObject>(cherryPath), position, quaternion.identity,
                parent);
    }
}
