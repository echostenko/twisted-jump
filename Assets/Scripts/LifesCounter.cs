using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesCounter : MonoBehaviour
{
    public static LifesCounter instance;
    public GameObject gameOverScreen;
    public Transform parent;
    public Text lifeText;
    private int score = 5;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lifeText.text = score.ToString();
    }

    public void DiminishLive()
    {
        if (score == 1) Instantiate(gameOverScreen, new Vector3(0, 0, 0), gameOverScreen.transform.rotation, parent);
        score -= 1;
        lifeText.text = score.ToString();
    }
}
