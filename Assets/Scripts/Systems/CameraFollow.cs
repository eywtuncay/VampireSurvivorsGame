using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10); // Camera follows the player but 6 to the right
    }

}
