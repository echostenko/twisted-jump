using UnityEngine;

public class DestroyPlatformUnderPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
            Destroy(gameObject, 1f);
    }
}

