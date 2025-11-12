using UnityEngine;

public class playercollision : MonoBehaviour
{

    public playermovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("hit an obstacle");
            movement.enabled = false;
        }
    }
}
