using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    private GameObject Player = null;
    private Transform PlayerTransform = default;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = Player.transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, transform.position.z);
    }
}
