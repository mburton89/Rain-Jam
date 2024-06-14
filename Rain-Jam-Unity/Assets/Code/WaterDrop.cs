using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 screenBounds;
    private float objectWidth;

    public GameObject splashParticlePrefab;

    public List<GameObject> characters;

    public float speed = 25.0f; // Speed of movement with arrow keys

    public bool isToxic;

    private Vector3 lastTouchPosition;
    private bool isTouching = false;

    bool isDesktop;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Assuming the object has a SpriteRenderer

        int rand = Random.Range(0, characters.Count);

        characters[rand].gameObject.SetActive(true);

        float width = Screen.width;
        float height = Screen.height;

        if (width > height)
        {
            isDesktop = true;
        }
    }

    void Update()
    {
        float moveAmount = 0;

        // Handle mouse movement
        if (Input.GetMouseButton(0) && isDesktop)
        {
            float mouseXDelta = Input.GetAxis("Mouse X");
            moveAmount += mouseXDelta / 2;
        }

        // Handle touch movement
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                Vector3 currentTouchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                float touchXDelta = currentTouchPosition.x - lastTouchPosition.x;
                moveAmount += touchXDelta;
                lastTouchPosition = currentTouchPosition;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }

        // Handle arrow key movement
        float moveInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveAmount += moveInput;

        // Combine movements
        Vector3 newPosition = transform.position + new Vector3(moveAmount, 0, 0);

        // Clamp the new position to keep the object within screen boundaries
        //newPosition.x = Mathf.Clamp(newPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);

        // Apply the new position
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Flower>())
        {
            if (isToxic)
            {
                collision.gameObject.GetComponent<Flower>().Shrink();
                GameManager.Instance.DeductPoint();
            }
            else
            {
                collision.gameObject.GetComponent<Flower>().Grow(); 
                GameManager.Instance.AddPoint();
            }
        }

        if (collision.gameObject.GetComponent<Obstacle>() && isToxic)
        {
            Destroy(collision.gameObject);
        }

        Instantiate(splashParticlePrefab, transform.position, transform.rotation, null);
        WaterSpawner.Instance.DelaySpawnWaterDrop();

        if (!isToxic && collision.gameObject.GetComponent<Flower>())
        {
            SoundManager.Instance.PlayWaterDropSound();
        }
        else
        {
            SoundManager.Instance.PlayExplosion15Sound();
        }

        Destroy(gameObject);
    }
}