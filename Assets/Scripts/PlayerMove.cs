using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontalInput;
    public float jumpForce = 10f;
    public float speed = 3;
    public Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        Vector2 characterScale = transform.localScale;

        if (horizontalInput >= 0)
            characterScale.x = 3.708483f;
        else if (horizontalInput <= 0) characterScale.x = -3.708483f;

        transform.localScale = characterScale;
    }

    
}
