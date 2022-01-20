using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startTime = 5f;
    [SerializeField]
    public Text respawnTimer; 

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        respawnTimer.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
