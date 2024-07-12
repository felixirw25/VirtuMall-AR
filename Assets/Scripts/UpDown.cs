using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class UpDown : MonoBehaviour
{
    public float radius = 1f;
    public int segments = 64;
    public float movementSpeed = 1.5f;
    public float maxHeight = 3f;
    public float minHeight;

    private LineRenderer lineRenderer;
    private float yOffset = 0f;
    private bool movingUp = true;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
    }

    void Update()
    {
        // Move the circle up and down
        yOffset += movingUp ? movementSpeed * Time.deltaTime : -movementSpeed * Time.deltaTime;
        if (yOffset >= maxHeight)
        {
            yOffset = maxHeight;
            movingUp = false;
        }
        else if (yOffset <= minHeight)
        {
            yOffset = minHeight;
            movingUp = true;
        }

        // Update the Y position of the circle
        transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
    }
}
