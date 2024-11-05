using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Check if the user touches the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Rotate the object based on finger movement
                float rotationY = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                float rotationX = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;

                // Apply rotation to the object
                transform.Rotate(Vector3.up, -rotationY);
                transform.Rotate(Vector3.right, rotationX);
            }
        }
    }
}
