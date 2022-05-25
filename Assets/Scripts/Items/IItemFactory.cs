using UnityEngine;

namespace Items
{
    public interface IItemFactory
    {
        GameObject CreateCherry(Vector3 position, Transform parent = null);
    }
}