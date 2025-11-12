using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        //Debug.Log(player.position);
        //[PROPERTY] Using this to move the camera along with the player cube
        transform.position = player.position + offset;
    }
}
