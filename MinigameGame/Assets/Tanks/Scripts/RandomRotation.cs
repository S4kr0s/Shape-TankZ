using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour
{
    public float torque;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float turn = Random.Range(-1f, 1f);
        rb.AddTorque(transform.up * torque * turn);
        rb.velocity = Vector3.zero;
    }
}