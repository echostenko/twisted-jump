using Player;
using Services;
using UI;
using UnityEngine;

namespace Items
{
    public class ItemDestroyer : MonoBehaviour
    {
        private ServiceLocator serviceLocator;

        private void Awake() => 
            serviceLocator = ServiceLocator.instance;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                ScoreManager.Instance.PlusPoint();
                PlayerMove.Instance.BuffJump();
                serviceLocator.cherryPool.SetItemToPool(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) => 
            serviceLocator.cherryPool.SetItemToPool(gameObject);
    }
}
