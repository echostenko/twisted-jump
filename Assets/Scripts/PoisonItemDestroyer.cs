using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonItemDestroyer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint();
            PlayerMove.instance.DebuffJump();
            Destroy(gameObject);
        }
    }
}
