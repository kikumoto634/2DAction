using UnityEngine;

public class PlayerLongJump : MonoBehaviour
{
    //float
    [SerializeField] private float Speed = 5f;
    private float Horizontal = 0.0f;

    private float JumpTime = 0.0f;
    [SerializeField]private float MaxJumpTime = 1f;

    [SerializeField] private float JumpSpeed = 1f;

    [SerializeField] private float FallSpeed = -25.0f;
    //flag
    private bool IsGrounded = false;
    private bool IsJumpEnd = false;

    //vector3

    //Component
    Rigidbody2D Rb = null;

    //parent
    private GameObject emptyObject = null;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //移動
        Horizontal = Input.GetAxis("Horizontal");

        //地面判定+ジャンプ

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

            if(Rb.velocity.y < FallSpeed)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, FallSpeed);
                Debug.Log("許容オーバー");
            }
        }
        //Debug.Log(Rb.velocity.y);
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

            if(transform.parent == null)
            {
                emptyObject = new GameObject();
                emptyObject.name = "PlayerParent";
                emptyObject.transform.parent = collision.gameObject.transform;
                transform.parent = emptyObject.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;

            if(transform.parent != null)
            {
                transform.parent = null;
                Destroy(emptyObject);
            }
        }
    }
}
