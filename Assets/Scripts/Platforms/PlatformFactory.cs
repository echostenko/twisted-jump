using Interfaces;
using UnityEngine;
using Zenject;

namespace Platforms
{
    public class PlatformFactory : IObjectFactory
    {
        private readonly IAssetProvider assetProvider;
        private const string platformPath = "Prefabs/Platforms/Wood Platform";

        [Inject]
        public PlatformFactory(IAssetProvider assetProvider) =>
            this.assetProvider = assetProvider;

        public GameObject CreateObject(Vector3 position, Transform parent = null) =>
            Object.Instantiate(assetProvider.Load<GameObject>(platformPath), position, Quaternion.identity, parent);
    }
}