using UnityEngine;

public class DestroyPlatformOnCollide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LeftCollider"))
        {
            Destroy(gameObject);
        }
    }
    
    
}
