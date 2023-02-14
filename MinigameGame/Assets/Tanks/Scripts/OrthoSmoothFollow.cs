using UnityEngine;
using System.Collections;

public class OrthoSmoothFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity;

    void LateUpdate()
    {
        if (target == null)
            return;

        velocity = target.GetComponent<Rigidbody>().velocity;
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}