using System;
using UnityEngine;

public class BossDestroyer : MonoBehaviour
{
    public event Action bossDestroyedEvent;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            DestroyBoss();
        }
    }

    private void DestroyBoss()
    {
        Destroy(gameObject);
        bossDestroyedEvent?.Invoke();
    }
}
