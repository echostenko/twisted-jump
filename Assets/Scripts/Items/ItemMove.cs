using UnityEngine;

namespace Items
{
    public class ItemMove : MonoBehaviour
    {
        public float itemSpeed = 0f;

        void Update() => 
            transform.Translate(Vector3.down * Time.deltaTime * itemSpeed);
    }
}
