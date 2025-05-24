using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float launchForce = 15f;            // Strength of the launch
    public Vector3 launchDirection = Vector3.up; // Launch direction

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            // Reset current vertical velocity and launch
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(launchDirection.normalized * launchForce, ForceMode.VelocityChange);
        }
    }
}
