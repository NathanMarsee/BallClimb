using UnityEngine;

public class DirectionalForcePlatform : MonoBehaviour
{
    public float forceStrength = 10f;         // Strength of the force
    public bool continuousForce = false;      // Apply force every frame?

    private void OnTriggerEnter(Collider other)
    {
        if (!continuousForce && other.attachedRigidbody != null)
        {
            Vector3 direction = GetPushDirection(other);
            other.attachedRigidbody.AddForce(direction * forceStrength, ForceMode.Impulse);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (continuousForce && other.attachedRigidbody != null)
        {
            Vector3 direction = GetPushDirection(other);
            other.attachedRigidbody.AddForce(direction * forceStrength * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    // Calculate direction from contact point to object center (away from platform)
    private Vector3 GetPushDirection(Collider other)
    {
        Vector3 contactDirection = (other.transform.position - transform.position).normalized;

        // Optional: project to only use horizontal or vertical directions
        // Uncomment if you want 2D-style bounce:
        // contactDirection.y = 0f; // For horizontal-only push
        // contactDirection = contactDirection.normalized;

        return contactDirection;
    }
}
