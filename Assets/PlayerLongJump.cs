using UnityEngine;

public class PlayerLongJump : MonoBehaviour
{
    //float
    [SerializeField] private float Speed = 5f;
    private float Horizontal = 0.0f;

    private float JumpTime = 0.0f;
    [SerializeField]private float MaxJumpTime = 1f;

    [SerializeField] private float JumpSpeed = 1f;
    //flag
    private bool IsGrounded = false;
    private bool IsJumpEnd = false;

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

        if(!IsGrounded)
        {
            if(Input.GetButtonDown("Jump") && !IsJumpEnd)
            {
                IsGrounded = true;
                Rb.velocity = Vector2.up * JumpSpeed;
            }
        }
        else if(IsGrounded)
        {
            if (Input.GetButton("Jump") && !IsJumpEnd && JumpTime < MaxJumpTime)
            {
                JumpTime += Time.deltaTime;
                Rb.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            }

            if(!Input.GetButton("Jump"))
            {
                IsJumpEnd = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            JumpTime = 0.0f;
            IsJumpEnd = false;
            IsGrounded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}
