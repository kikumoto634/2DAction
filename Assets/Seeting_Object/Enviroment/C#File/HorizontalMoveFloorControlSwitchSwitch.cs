using UnityEngine;

public class HorizontalMoveFloorControlSwitchSwitch : MonoBehaviour
{
    bool IsSwitch = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            IsSwitch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            IsSwitch = false;
        }
    }

    public bool GetIsSwitch()
    {
        return IsSwitch;
    }
}
