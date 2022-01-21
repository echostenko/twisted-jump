using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformDestroy : MonoBehaviour
{
    public float delay = 1;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player")) 
            StartCoroutine(DestroyPlatformDelay(delay));
    }

    private IEnumerator DestroyPlatformDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);

    }
}
