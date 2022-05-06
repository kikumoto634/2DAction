using UnityEngine;

public class PlayerLongJump : MonoBehaviour
{
    //float
    [SerializeField] private float Speed = 5f;
    private float Horizontal = 0.0f;

    [SerializeField] private float JumpSpeed = 1f;
    //flag
    private bool IsGrounded = false;

    //vector3

    //Component
    Rigidbody2D Rb = null;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //移動
        Horizontal = Input.GetAxis("Horizontal");

        //地面判定+ジャンプ
        if(IsGrounded)
        { 
            if(Input.GetButtonDown("Jump"))
            {
                Rb.velocity = Vector2.up * JumpSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            Debug.Log("地面設置");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
