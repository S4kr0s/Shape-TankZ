using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rigidbody;
    private Vector3 movementVector;
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);

    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get Movement Data instantly for smooth input
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        // Get Mouse World Point
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        // Rotate to Mouse
        transform.LookAt(worldPosition);
    }

    private void FixedUpdate()
    {
        // Currently Magic Number, assign Map Size instead
        Vector3 movingPosition = rigidbody.position + movementVector * (speed * Time.deltaTime);
        movingPosition.x = Mathf.Clamp(movingPosition.x, -50, 50);
        movingPosition.z = Mathf.Clamp(movingPosition.z, -50, 50);
        rigidbody.MovePosition(movingPosition);
    }
}
