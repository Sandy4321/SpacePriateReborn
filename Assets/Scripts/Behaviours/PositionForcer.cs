using UnityEngine;

/**
 * Applies a force to all colliders intersecting with ther attached trigger2D towards the specified point. 
 * Does so in a non-linear way, *Cough* Only used in airlock right now *Cough*.
 */
public class PositionForcer : MonoBehaviour
{
    public float ForceDistance;
    public float ForceMagnitude;
    public bool IsActive = true;
    public Transform TargetTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsActive)
        {
            ApplyForceToTarget(collision);
        }
    }

    private void ApplyForceToTarget(Collider2D collision)
    {
        GameObject targetObject = collision.gameObject;
        Vector3 tragetObjectPosition = targetObject.transform.position;
        Rigidbody2D targetRigidbody = targetObject.rigidbody2D;

        Vector2 forceDireciton = CalculateForceDirection(tragetObjectPosition);
        float forceMagnitude = CalculateForceMagnitude(tragetObjectPosition);

        if (targetRigidbody != null)
        {
            targetRigidbody.AddForce(forceDireciton*forceMagnitude);
        }
    }

    private Vector2 CalculateForceDirection(Vector2 tragetObjectPosition)
    {
        return (tragetObjectPosition - (Vector2)TargetTransform.position).normalized;
    }

    private float CalculateForceMagnitude(Vector2 targetObjectPosition)
    {
        float distanceToTarget = Vector2.Distance(TargetTransform.position, targetObjectPosition);
        return (ForceDistance/Mathf.Pow(distanceToTarget, 2.0f))*ForceMagnitude;
    }
}