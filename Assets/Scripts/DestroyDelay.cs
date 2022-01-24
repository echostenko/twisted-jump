using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 30f);
    }
}
