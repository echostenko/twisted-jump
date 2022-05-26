using System.Collections;
using Interfaces;
using Services;
using UnityEngine;

namespace Items
{
    public class ItemSpawner
    {
        private IItemPool itemPool;
        private ICoroutineRunner coroutineRunner;
        private float spawnDelay = 2f;
        private int cherryCountLimit = 10;

        public ItemSpawner(IItemPool itemPool, ICoroutineRunner coroutineRunner)
        {
            this.itemPool = itemPool;
            this.coroutineRunner = coroutineRunner;
        }

        public void Initialize()
        {
            coroutineRunner.StartCoroutine(SpawnWithDelay());
        }

        private IEnumerator SpawnWithDelay()
        {
            var cherryCount = 0;
            do
            {
                CreateCherry();
                cherryCount++;
                yield return new WaitForSeconds(spawnDelay);
            } while (cherryCount < cherryCountLimit);
        }

        private void CreateCherry()
        {
            var cherry = itemPool.GetItemFromPool();
            cherry.GetComponent<Rigidbody2D>().mass.Equals(1f);
        }
    }
}