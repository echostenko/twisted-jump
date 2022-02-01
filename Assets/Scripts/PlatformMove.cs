using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float platformSpeed = 2f;
    
    private void Update() => 
        transform.Translate(Vector3.left * Time.deltaTime * platformSpeed);
}
