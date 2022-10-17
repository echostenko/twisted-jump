using UnityEngine;

namespace Interfaces
{
    public interface IObjectFactory
    {
        GameObject CreateObject(Vector3 position, Transform parent = null);
    }
}