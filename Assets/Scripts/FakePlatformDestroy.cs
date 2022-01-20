using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformDestroy : MonoBehaviour
{
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
