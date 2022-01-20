using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject respawnTimer;
    public Transform parent;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(respawnTimer, new Vector3(0, 0, 0), respawnTimer.transform.rotation, parent);
        }
    }
}
    