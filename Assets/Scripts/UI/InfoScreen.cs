using UnityEngine;

namespace UI
{
    public class InfoScreen : MonoBehaviour
    {
        public GameObject infoScreen;
        public Transform parent;

        public void LoadInfoScreen() => 
            Instantiate(infoScreen, new Vector3(0, 0, 100), infoScreen.transform.rotation, parent);
    }
}
