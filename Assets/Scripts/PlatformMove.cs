using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float platformSpeed = 2f;
    
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * platformSpeed);
    }
}
