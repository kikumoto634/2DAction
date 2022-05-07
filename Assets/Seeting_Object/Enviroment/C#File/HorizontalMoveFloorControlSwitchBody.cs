using UnityEngine;

public class HorizontalMoveFloorControlSwitchBody : MonoBehaviour
{
    [SerializeField] private float HorizontalMoveSpeed = 4f;
    [SerializeField] private float HorizontalMoveDistance = 5f;

    float StartPos = default;
    bool IsLeftRight = false;

    private GameObject Parent = null;
    private HorizontalMoveFloorControlSwitchSwitch switchControl = null;

    private void Start()
    {
        StartPos = this.transform.position.x;

        Parent = transform.parent.gameObject;
        switchControl = Parent.GetComponent<HorizontalMoveFloorControlSwitchSwitch>();
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
        if(switchControl.GetIsSwitch())
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
}
