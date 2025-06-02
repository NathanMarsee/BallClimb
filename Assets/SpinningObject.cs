using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1;
    public bool xAxis = false;
    public bool yAxis = true;
    public bool zAxis = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = 0; float y = 0; float z = 0;
        if (xAxis)
            x = speed;
        if (yAxis)
            y = speed;
        if (zAxis)
            z = speed;

        rb.MoveRotation(Quaternion.Euler(transform.eulerAngles.x + x, transform.eulerAngles.y + y, transform.eulerAngles.z + z));
    }
}
