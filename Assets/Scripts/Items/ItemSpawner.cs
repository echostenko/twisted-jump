using System.Collections;
using Data;
using Interfaces;
using UnityEngine;

namespace Items
{
    public class ItemSpawner
    {
        private IItemPool itemPool;
        private ICoroutineRunner coroutineRunner;
        private IItemPositionService itemPositionService;
        private readonly GameSettings gameSettings;

        public ItemSpawner(IItemPool itemPool, ICoroutineRunner coroutineRunner, 
            IItemPositionService itemPositionService, GameSettings gameSettings)
        {
            this.itemPool = itemPool;
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
            } while (cherryCount < gameSettings.ItemsCount);
        }

        private void CreateCherry()
        {
            var cherry = itemPool.GetItemFromPool();
            cherry.transform.SetPositionAndRotation(itemPositionService.GetSpawnPosition(), Quaternion.identity);
        }
    }
}