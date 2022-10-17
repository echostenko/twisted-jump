using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LifesCounter : MonoBehaviour
    {
        public Text lifeText;
        private int continues = 5;

        public static event Action GameOverEvent;
    
        private void Awake() => 
            PlayerRespawn.PlayerRespawnedEvent += MinusContinue;

        private void Start() => 
            lifeText.text = continues.ToString();

        private void OnDestroy() => 
            PlayerRespawn.PlayerRespawnedEvent -= MinusContinue;

        private void MinusContinue()
        {
            if (continues == 1)
            {
                GameOverEvent?.Invoke();
            }
        
            continues -= 1;
            lifeText.text = continues.ToString();    
        }
    }
}
