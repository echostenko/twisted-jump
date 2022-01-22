using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animanor;
    private int levelToLoad;
    
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animanor.SetTrigger("Fade_out");
    }
}
    