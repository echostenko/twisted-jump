using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerRespawn : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
    
        public static event Action PlayerRespawnedEvent;

        private void Awake() => 
            LifesCounter.GameOverEvent += DestroyPlayer;

        private void DestroyPlayer() => 
            Destroy(gameObject);

        private void OnCollisionEnter2D(Collision2D colider)
        {
            if (!colider.transform.CompareTag("BottomCollider")) return;
            PlayerRespawnedEvent?.Invoke();
            StartCoroutine(RespawnDelayCoroutine());
        }
    
        private IEnumerator RespawnDelayCoroutine()
        {
            yield return new WaitForSeconds(5);
            gameObject.transform.position = spawnPoint.position;
        }
    }
}
