using UnityEngine;

public class HorizontalMoveFloorControl : MonoBehaviour
{
    [SerializeField] private float HorizontalMoveSpeed = 4f;
    [SerializeField] private float HorizontalMoveDistance = 5f;

    float StartPos = default;
    bool IsLeftRight = false;

    private void Start()
    {
        StartPos = this.transform.position.x;
    }

    private void Update()
    {
        if (StartPos - transform.position.x >= HorizontalMoveDistance)
        {
            IsLeftRight = true;
        }
        else if (StartPos - this.transform.position.x <= -HorizontalMoveDistance)
        {
            IsLeftRight = false;
        }
    }

    private void FixedUpdate()
    {
        if(!IsLeftRight)
        {
            this.transform.position -= new Vector3(HorizontalMoveSpeed, 0f, 0f);
        }
        else if(IsLeftRight)
        {
            this.transform.position += new Vector3(HorizontalMoveSpeed, 0f, 0f);
        }
    }
}
