using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDestroyer : MonoBehaviour
{
    public GameObject nextLevelWindow;
    public Transform parent;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(nextLevelWindow, new Vector3(0, 0, 0), nextLevelWindow.transform.rotation, parent);
        }
    }

    
    
}
