using Data;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        public static PlayerMove Instance;
        public Animator animator;
        public PlayerData playerData;

        private float horizontalInput;
        private Rigidbody2D _rigidbody;
        private float jumpForce;
        private float speed;

        private void Awake() => 
            Instance = this;

        private void Start()
        {
            jumpForce = playerData.jumpForce;
            speed = playerData.speed;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Crate")) 
                gameObject.transform.parent = other.gameObject.transform;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Crate")) 
                gameObject.transform.parent = other.gameObject.transform;
        }

        public void BuffJump() => 
            jumpForce += 0.2f;

        public void DebuffJump() => 
            jumpForce -= 0.2f;
    }
}
