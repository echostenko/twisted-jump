using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemDestroyer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint();
            Destroy(gameObject);
        }
    }
}
