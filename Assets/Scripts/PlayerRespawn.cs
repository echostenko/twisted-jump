using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] 
    private Transform spawnPoint;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player")) 
            col.transform.position = spawnPoint.position;

    }
}
