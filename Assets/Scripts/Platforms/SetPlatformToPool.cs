using System;
using Services;
using UnityEngine;

namespace Platforms
{
    public class SetPlatformToPool : MonoBehaviour
    {
        private ServiceLocator serviceLocator;

        private void Start() => 
            serviceLocator = ServiceLocator.instance;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("LeftCollider")) 
                serviceLocator.platformPool.SetItemToPool(gameObject);
        }
    }
}
