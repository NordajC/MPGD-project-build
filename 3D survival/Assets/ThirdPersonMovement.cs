using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get the raw horizontal and vertical input values (either -1, 0, or 1)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Create a direction vector based on the horizontal and vertical inputs
        // The y-axis remains 0 because movement is only on the x-z plane
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Check if there's any input (direction's magnitude will be non-zero if there's input)
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle using the tangent of the input values
            // Convert the angle from radians to degrees using Mathf.Rad2Deg
            float targentAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Rotate the transform to face the direction of movement
            transform.rotation = Quaternion.Euler(0f, targentAngle, 0f);

            // Move the character controller in the desired direction, adjusted by speed and the frame's delta time
            controller.Move(direction * speed * Time.deltaTime);
        }

    }
}
