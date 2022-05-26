using UnityEngine;

namespace Services
{
    public interface IItemPool
    {
        void Initialize();
        GameObject GetItemFromPool();
        void SetItemToPool(GameObject cherry);
    }
}