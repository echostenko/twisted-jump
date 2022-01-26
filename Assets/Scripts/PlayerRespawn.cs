using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TimerSpawnManager spawnTimer;
    
    private void OnCollisionEnter2D(Collision2D colider)
    {
        if (!colider.transform.CompareTag("Player")) return;
        LifesCounter.instance.DiminishLive();
        spawnTimer.SpawnTimer();
        StartCoroutine(RespawnDelayCoroutine(colider.transform));
    }
    private IEnumerator RespawnDelayCoroutine(Transform transform)
    {
        yield return new WaitForSeconds(5);
        transform.position = spawnPoint.position;

    }
    
}
