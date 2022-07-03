using UnityEngine;

namespace Interfaces
{
    public interface IObjectPool
    {
        void Initialize();
        GameObject GetItemFromPool();
        void SetItemToPool(GameObject item);
    }
}