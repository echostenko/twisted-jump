using UnityEngine;
using Random = UnityEngine.Random;

namespace Services
{
    public class ItemPositionService
    {
        private const float minPositionX = -8.21f;
        private const float maxPositionX = 6.19f;
        private const float positionY = 6.04f;
        private const float positionZ = 107.96f;

        private float GetPositionX(float minX, float maxX) => 
            Random.Range(minX, maxX);

        public Vector3 GetSpawnPosition()
        {
            var x = GetPositionX(minPositionX, maxPositionX);
            return new Vector3(x, positionY, positionZ);
        }
    }
}