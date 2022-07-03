using Interfaces;
using Unity.Mathematics;
using UnityEngine;

namespace Items
{
    public class CherryFactory : IObjectFactory
    {
        private readonly IAssetProvider assetProvider;
        private const string cherryPath = "Prefabs/Items/Cherry";

        public CherryFactory(IAssetProvider assetProvider) => 
            this.assetProvider = assetProvider;

        public GameObject CreateObject(Vector3 position, Transform parent = null) =>
            Object.Instantiate(assetProvider.Load<GameObject>(cherryPath), position, quaternion.identity,
                parent);
    }
}
