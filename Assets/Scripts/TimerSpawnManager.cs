using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpawnManager : MonoBehaviour
{
    public GameObject respawnTimer;
    public Transform parent;

    public void SpawnTimer() => Instantiate(respawnTimer, new Vector3(0, 0, 0), respawnTimer.transform.rotation, parent);
}
    