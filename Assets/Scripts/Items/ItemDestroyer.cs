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
        }

        private void OnTriggerEnter2D(Collider2D other) => 
            Destroy(gameObject);
    }
}
