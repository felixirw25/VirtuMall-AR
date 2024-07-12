using UnityEngine;

public class FurnitureRotationFBX : MonoBehaviour
{
    private Vector2 touchStartPos;
    private float rotationSpeed = 0.5f;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle swipe gestures
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 deltaSwipe = touch.position - touchStartPos;

                    // Check for left or right swipe
                    if (Mathf.Abs(deltaSwipe.x) > Mathf.Abs(deltaSwipe.y))
                    {
                        float yRotation = deltaSwipe.x * rotationSpeed * Time.deltaTime;
                        transform.Rotate(0f, -yRotation, 0f); // Subtract Y rotation for left or add for right swipe
                    }
                    // Check for up or down swipe
                    else
                    {
                        float xRotation = deltaSwipe.y * rotationSpeed * Time.deltaTime;
                        transform.Rotate(-xRotation, 0f, 0f); // Add Z rotation for up swipe or subtract for down swipe
                    }

                    break;
            }
        }
    }
}
