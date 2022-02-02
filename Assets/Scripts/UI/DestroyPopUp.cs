using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DestroyPopUp : MonoBehaviour
    {
        public Button button;

        private void Awake() => 
            button.onClick.AddListener(DestroyInfo);

        private void OnDestroy() => 
            button.onClick.RemoveListener(DestroyInfo);

        private void DestroyInfo() => 
            Destroy(gameObject);
    }
}
