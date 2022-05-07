using UnityEngine;

public class BouncerControl : MonoBehaviour
{
    [SerializeField] private float BoundSpeed = 100f;

    private GameObject Player = null;
    private Rigidbody2D Rb = null;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rb = Player.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rb.AddForce(Vector2.up * BoundSpeed, ForceMode2D.Impulse);
        }
    }
}
