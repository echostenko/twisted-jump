using Player;
using UI;
using UnityEngine;

namespace Items
{
    public class PoisonItemDestroyer : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                ScoreManager.Instance.PlusPoint();
                PlayerMove.Instance.BuffJump();
                Destroy(gameObject);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other) => 
            Destroy(gameObject);
    }
}
