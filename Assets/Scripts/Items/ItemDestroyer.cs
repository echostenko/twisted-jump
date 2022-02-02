using Player;
using UnityEngine;

namespace Items
{
    public class ItemDestroyer : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                ScoreManager.Instance.PlusPoint();
                PlayerMove.instance.BuffJump();
                Destroy(gameObject);
            }
            else if (other.transform.CompareTag("BottomCollider")) 
                Destroy(gameObject);
        }
    }
}
