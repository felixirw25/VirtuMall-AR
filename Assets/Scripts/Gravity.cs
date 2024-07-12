using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    // Reference to the Rigidbody component of the character
    public Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the character GameObject
        rb = GetComponent<Rigidbody>();

        // Freeze rotation along all axes to prevent rotation upon collision
        rb.freezeRotation = true;
    }

    // OnCollisionEnter is called when this object collides with another collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
