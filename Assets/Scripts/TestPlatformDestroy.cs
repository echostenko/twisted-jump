using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatformDestroy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
