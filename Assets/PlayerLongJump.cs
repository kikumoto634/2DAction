using UnityEngine;

public class PlayerLongJump : MonoBehaviour
{
    //float
    [SerializeField] private float Speed = 5f;
    private float Horizontal = 0.0f;

    [SerializeField] private float JumpSpeed = 1f;
    private float JumpTime = 0;
    private float MaxJumpTime = 0.25f;

    //flag
    private bool IsGrounded = false;
    private bool IsJumpUp = false;

    //vector3

    //Component
    Rigidbody2D Rb = null;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //ˆÚ“®
        Horizontal = Input.GetAxis("Horizontal");

        //’n–Ê”»’è+ƒWƒƒƒ“ƒv
        if(IsGrounded)
        { 
            if(Input.GetButtonDown("Jump"))
            {
                Rb.velocity = Vector2.up * JumpSpeed/2;
            }

            IsJumpUp = false;
            JumpTime = 0.0f;
        }
        else
        {
            if(Input.GetButton("Jump") && JumpTime < MaxJumpTime && !IsJumpUp)
            {
                JumpTime += Time.deltaTime;
                Rb.velocity = Vector2.up * JumpSpeed;
            }

            if(Input.GetButtonUp("Jump") && !IsJumpUp)
            {
                IsJumpUp = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
