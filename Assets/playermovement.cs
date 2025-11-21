using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 50f;
    public float maxSpeed = 15f;


    [Range(1f, 10f)] //[ATTRIBUTE] cap the speed of size change from 1 to 0
    public float scaleSpeed = 1.0f;
    public Vector3 minScale = new Vector3(0.25f, 0.25f, 0.25f);
    public Vector3 maxScale = new Vector3(5f, 5f, 5f);

    void Update()
    {
        if (FindObjectOfType<GameManager>().gameHasEnded) return;

        float dir = 0f;

        //+= and -= means if W and S held at same time, no change in size
        if (Input.GetKey(KeyCode.W)) dir += 1f; //grow
        if (Input.GetKey(KeyCode.S)) dir -= 1f; //shrink

        if (dir != 0f)
        {
            Vector3 s = transform.localScale + Vector3.one * (dir * scaleSpeed * Time.deltaTime);

            s.x = Mathf.Clamp(s.x, minScale.x, maxScale.x);
            s.y = Mathf.Clamp(s.y, minScale.y, maxScale.y);
            s.z = Mathf.Clamp(s.z, minScale.z, maxScale.z);

            transform.localScale = s;
        }
    }

    // Use for physics
    void FixedUpdate()
    {
        if (FindObjectOfType<GameManager>().gameHasEnded) return;

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.linearVelocity.z > maxSpeed)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, maxSpeed);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // If we fall off the map
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}