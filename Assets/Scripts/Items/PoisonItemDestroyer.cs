using Player;
using UnityEngine;

namespace Items
{
    public class PoisonItemDestroyer : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                ScoreManager.Instance.MinusPoint();
                PlayerMove.instance.DebuffJump();
                Destroy(gameObject);
            }
            else if (other.transform.CompareTag("BottomCollider")) 
                Destroy(gameObject);
        }
    }
}
