using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  
    public Text scoreText;
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void PlusPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    
    public void MinusPoint()
    {
        if (score <= 0) return;
        score -= 1;
        scoreText.text = score.ToString();
    }
    
}
