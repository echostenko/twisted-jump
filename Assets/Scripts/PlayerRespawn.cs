using System;
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    //[SerializeField] private TimerSpawnManager spawnTimer;

    public event Action playerRespawnedEvent;
    
    private void OnCollisionEnter2D(Collision2D colider)
    {
        if (!colider.transform.CompareTag("BottomCollider")) return;
        playerRespawnedEvent?.Invoke();
        StartCoroutine(RespawnDelayCoroutine());
    }
    private IEnumerator RespawnDelayCoroutine()
    {
        yield return new WaitForSeconds(5);
        gameObject.transform.position = spawnPoint.position;

    }
    
}
