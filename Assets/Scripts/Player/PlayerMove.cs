using System;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private float horizontalInput;
        private Rigidbody2D _rigidbody;
        public static PlayerMove instance;
        public float jumpForce = 10f;
        public float speed = 3;
        public Animator animator;

        private void Awake() => 
            instance = this;

        private void Start() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput) * speed);
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
                _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        
            Vector2 characterScale = transform.localScale;

            if (horizontalInput >= 0)
                characterScale.x = 3.708483f;
            else if (horizontalInput <= 0) characterScale.x = -3.708483f;

            transform.localScale = characterScale;
        }

        /*private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                gameObject.transform.parent = other.gameObject.transform;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                gameObject.transform.parent = other.gameObject.transform;
            }
        }*/

        public void BuffJump() => 
            jumpForce += 0.2f;

        public void DebuffJump() => 
            jumpForce -= 0.2f;
    }
}
