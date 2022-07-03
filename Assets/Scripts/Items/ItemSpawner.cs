using System.Collections;
using Data;
using Interfaces;
using UnityEngine;

namespace Items
{
    public class ItemSpawner
    {
        private IObjectPool objectPool;
        private ICoroutineRunner coroutineRunner;
        private IItemPositionService itemPositionService;
        private readonly GameSettings gameSettings;

        public ItemSpawner(IObjectPool objectPool, ICoroutineRunner coroutineRunner, 
            IItemPositionService itemPositionService, GameSettings gameSettings)
        {
            this.objectPool = objectPool;
            this.coroutineRunner = coroutineRunner;
            this.itemPositionService = itemPositionService;
            this.gameSettings = gameSettings;
        }

        public void Initialize() => 
            coroutineRunner.StartCoroutine(SpawnWithDelay());

        private IEnumerator SpawnWithDelay()
        {
            var cherryCount = 0;
            do
            {
                CreateCherry();
                cherryCount++;
                yield return new WaitForSeconds(gameSettings.ItemSpawnDelay);
            } while (cherryCount < 100);
        }

        private void CreateCherry()
        {
            var cherry = objectPool.GetItemFromPool();
            cherry.transform.SetPositionAndRotation(itemPositionService.GetSpawnPosition(), Quaternion.identity);
        }
    }
}