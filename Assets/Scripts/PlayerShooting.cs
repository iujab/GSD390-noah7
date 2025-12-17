using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Should be better / more applicable to imported stuff
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // This now checks the object hit OR any of its parents for the Target script
            Target target = hit.transform.GetComponentInParent<Target>();
            
            if (target != null)
            {
                target.TakeHit();
            }
        }
    }
}