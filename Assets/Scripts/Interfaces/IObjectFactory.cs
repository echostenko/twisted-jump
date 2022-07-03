using UnityEngine;

namespace Interfaces
{
    public interface IItemFactory
    {
        GameObject CreateCherry(Vector3 position, Transform parent = null);
    }
}