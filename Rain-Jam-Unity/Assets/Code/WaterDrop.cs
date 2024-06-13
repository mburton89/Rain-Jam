using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 screenBounds;
    private float objectWidth;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Assuming the object has a SpriteRenderer
    }

    void Update()
    {
        // Calculate the new position based on mouse movement
        float mouseXDelta = Input.GetAxis("Mouse X");
        Vector3 newPosition = transform.position + new Vector3(mouseXDelta, 0, 0);

        // Clamp the new position to keep the object within screen boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);

        // Apply the new position
        transform.position = newPosition;
    }
}