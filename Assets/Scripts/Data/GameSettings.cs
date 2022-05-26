using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings: ScriptableObject
    {
        public float ItemSpawnDelay;
        public int ItemsCount;
    }
}