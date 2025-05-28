using UnityEngine;

public class DirectionalForcePlatform : MonoBehaviour
{
    public Vector3 launchDirection = Vector3.up; // Direction of force
    public float forceStrength = 10f; // Strength of the force
    public bool continuousForce = false; // Whether to apply force every frame the object is on the platform

    private void OnTriggerEnter(Collider other)
    {
        if (!continuousForce && other.attachedRigidbody != null)
        {
            other.attachedRigidbody.AddForce(launchDirection.normalized * forceStrength, ForceMode.Impulse);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (continuousForce && other.attachedRigidbody != null)
        {
            other.attachedRigidbody.AddForce(launchDirection.normalized * forceStrength * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
