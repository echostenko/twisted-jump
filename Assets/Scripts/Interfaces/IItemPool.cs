using UnityEngine;

namespace Interfaces
{
    public interface IItemPool
    {
        void Initialize();
        GameObject GetItemFromPool();
        void SetItemToPool(GameObject cherry);
    }
}