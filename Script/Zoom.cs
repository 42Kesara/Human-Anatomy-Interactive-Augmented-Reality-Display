using UnityEngine;

public class Zoom : MonoBehaviour
{
    private float scaleMin = 0.5f;  // Minimum zoom-out scale
    private float scaleMax = 3.0f;  // Maximum zoom-in scale
    private float initialDistance;  // Initial distance between touches
    private Vector3 initialScale;   // Initial scale of the object

    void Update()
    {
        // Check if there are exactly two touches on the screen
        if (Input.touchCount == 2)
        {
            // Store the touches
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Calculate the current distance between the two touches
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);

            // Check if a new pinch gesture is starting
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                // Set initial distance and scale
                initialDistance = currentDistance;
                initialScale = transform.localScale;
            }
            // Check if either touch is moving to continue scaling
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                // Calculate scaling factor based on initial and current distance
                float scaleFactor = currentDistance / initialDistance;
                Vector3 newScale = initialScale * scaleFactor;

                // Clamp the new scale within the minimum and maximum range
                newScale = Vector3.Max(Vector3.one * scaleMin, Vector3.Min(newScale, Vector3.one * scaleMax));

                // Apply the new scale to the object
                transform.localScale = newScale;
            }
        }
    }
}
