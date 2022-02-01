using UnityEngine;

public class CreditsMove : MonoBehaviour
{
    public float creditsSpeed = 3f;

    void Update() => 
        transform
            .Translate(Vector3.up * Time.deltaTime * creditsSpeed);
}
