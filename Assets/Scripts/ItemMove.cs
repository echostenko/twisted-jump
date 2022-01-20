using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float itemSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * itemSpeed);
    }
}
