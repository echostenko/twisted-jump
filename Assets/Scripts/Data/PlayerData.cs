using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player")]
    public class PlayerData : ScriptableObject
    {
        public float jumpForce;
        public float speed;
    }
}
