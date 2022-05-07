using UnityEngine;

public class VerticalMoveFloorControl : MonoBehaviour
{
    [SerializeField] private float VerticalMoveSpeed = 4f;
    [SerializeField] private float VerticalMoveDistance = 5f;

    float StartPos = default;
    bool IsUpDown = false;

    private void Start()
    {
        StartPos = this.transform.position.y;
    }

    private void Update()
    {
        if (StartPos - transform.position.y >= VerticalMoveDistance)
        {
            IsUpDown = true;
        }
        else if (StartPos - this.transform.position.y <= -VerticalMoveDistance)
        {
            IsUpDown = false;
        }
    }

    private void FixedUpdate()
    {
        if(!IsUpDown)
        {
            this.transform.position -= new Vector3(0f, VerticalMoveSpeed, 0f);
        }
        else if(IsUpDown)
        {
            this.transform.position += new Vector3(0f, VerticalMoveSpeed, 0f);
        }
    }
}
