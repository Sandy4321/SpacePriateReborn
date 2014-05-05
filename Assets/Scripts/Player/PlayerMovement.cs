using UnityEngine;

//HERE BE HACKS AND EVIL
public class PlayerMovement : MonoBehaviour
{
    [Range(1, 60)] public float ForceMagnitude = 1.0f;
    [Range(1, 120)] public float MaxForceMagnitude = 60.0f;

    private Vector3 TargetPosition;

    //TODO make into nice util object
    private const float KP = 1.0f;
    private const float KI = 0.02f;

    private Vector2 Proportional;
    private Vector2 Integral;

    private void Start()
    {
        TargetPosition = transform.position;
    }

    private void Update()
    {
        UpdateTargetPosition();

        ApplyForceTowardsTargetPosition();

        RotateToFaceMovementDirection();
    }

    private void ApplyForceTowardsTargetPosition()
    {
        if (Vector2.Distance(rigidbody2D.transform.position, TargetPosition) > 0.6f)
        {
            var forceToApply = ClampToMaxForce(GetPiValue(TargetPosition - transform.position)*ForceMagnitude);
            rigidbody2D.AddForce(forceToApply);
        }
        else
        {
            Integral = Vector2.zero;
        }
    }

    private void UpdateTargetPosition()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TargetPosition = new Vector3(mousePositionInWorldSpace.x, mousePositionInWorldSpace.y, 0);
            Integral = Vector2.zero;
        }
    }

    private void RotateToFaceMovementDirection()
    {
        if (rigidbody2D.velocity.magnitude > 0.2f)
        {
            rigidbody2D.transform.rotation = Quaternion.Slerp(rigidbody2D.transform.rotation, Quaternion.Euler(0, 0, (Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x)*Mathf.Rad2Deg) - 90), 0.3f);
        }
    }

    private Vector2 ClampToMaxForce(Vector2 force)
    {
        return Vector2.ClampMagnitude(force, MaxForceMagnitude);
    }

    private Vector2 GetPiValue(Vector2 error)
    {
        Proportional = error;
        Integral = Integral + error;

        return (KP * Proportional) + (KI * Integral);
    }
}