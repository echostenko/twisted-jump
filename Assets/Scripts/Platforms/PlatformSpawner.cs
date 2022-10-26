using System.Collections;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Platforms
{
    public class PlatformSpawner
    {
        private Transform firstSpawner;
        private Transform secondSpawner;
        private Transform thirdSpawner;
        private IObjectPool platformPool;
        private ICoroutineRunner coroutineRunner;

        [Inject]
        public PlatformSpawner(IObjectPool platformPool, ICoroutineRunner coroutineRunner,  Transform firstSpawner, 
            Transform secondSpawner, Transform thirdSpawner)
        {
            this.platformPool = platformPool;
            this.coroutineRunner = coroutineRunner;
            this.firstSpawner = firstSpawner;
            this.secondSpawner = secondSpawner;
            this.thirdSpawner = thirdSpawner;
        }
        
        public void Initialize()
        {
            coroutineRunner.StartCoroutine(SpawnWithDelay(firstSpawner));
            coroutineRunner.StartCoroutine(SpawnWithDelay(secondSpawner));
            coroutineRunner.StartCoroutine(SpawnWithDelay(thirdSpawner));
        }

        private IEnumerator SpawnWithDelay(Transform parent)
        {
            var platformCount = 0;
            do
            {
                CreatePlatform(parent);
                platformCount++;
                yield return new WaitForSeconds(5);
            } while (platformCount < 100);
        }

        private void CreatePlatform(Transform parent)
        {
            var platformPosition = parent.position;
            var platform = platformPool.GetItemFromPool();
            platform.transform.SetParent(parent);
            platform.transform.SetPositionAndRotation(platformPosition, Quaternion.identity);
        }
    }
}