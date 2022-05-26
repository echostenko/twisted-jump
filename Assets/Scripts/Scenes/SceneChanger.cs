using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneChanger : MonoBehaviour
    {
        private int levelToLoad;
        private GameObject popUp;
    
        public void LoadStartScene() => SceneManager.LoadScene(0);
        public void LoadFirstLevel() => SceneManager.LoadScene(1);
        public void LoadSecondLevel() => SceneManager.LoadScene(2);
        public void LoadThirdLevel() => SceneManager.LoadScene(3);
        public void LoadCreditsScene() => SceneManager.LoadScene(5);
        public void LoadArcadeScene() => SceneManager.LoadScene(6);
    }
}
    