using System;
using UnityEngine;

public class RespawnTimerSpawnManager : MonoBehaviour
{
    public GameObject respawnTimer;
    public Transform parent;
    public PlayerRespawn PlayerRespawn;
    
    public void Awake()
    {
        PlayerRespawn.playerRespawnedEvent += PlayerRespawnOnplayerRespawnedEvent;
    }
    
    private void PlayerRespawnOnplayerRespawnedEvent()
    {
        Instantiate(respawnTimer, new Vector3(0, 0, 0), respawnTimer.transform.rotation, parent);    
    }

    private void OnDestroy()
    {
        PlayerRespawn.playerRespawnedEvent -= PlayerRespawnOnplayerRespawnedEvent;
    }
}
    