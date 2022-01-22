using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startTime = 60f;
    [SerializeField]
    public Text gameTimer;
    [SerializeField] 
    public GameObject gameOver;
    public Transform parent;
    public GameObject player;
    

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        gameTimer.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            SceneManager.LoadScene(2);
            /*DestroyImmediate(gameObject);
            Destroy(player);
            Instantiate(gameOver, new Vector3(0, 0, 0), gameOver.transform.rotation, parent);*/
        }
        
    }
}
