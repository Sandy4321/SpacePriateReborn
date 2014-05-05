using UnityEngine;

namespace Assets.Scripts.Player
{
    public class AcradePlayerMovement : MonoBehaviour
    {
        [Range(1, 60)] public float ForceMagnitude = 1.0f;
        [Range(1, 120)] public float MaxForceMagnitude = 60.0f;

        private Vector3 MovementInput = Vector3.zero;
        private Vector2 ToMouseVector;
        private float ToMouseAngle;

        void Update()
        {
            MovementInput = new Vector3(-Input.GetAxis("Vertical") , Input.GetAxis("Horizontal"));

            var mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("mousePositionInWorldSpace: " + mousePositionInWorldSpace);

            ToMouseVector = new Vector2(transform.position.x, transform.position.y) -  new Vector2(mousePositionInWorldSpace.x, mousePositionInWorldSpace.y);

            ToMouseAngle = Mathf.Atan2(ToMouseVector.y, ToMouseVector.x)*Mathf.Rad2Deg;

            var toMouseQuaternion = Quaternion.AngleAxis(ToMouseAngle, Vector3.forward);

           

            var forceDirection = (toMouseQuaternion*MovementInput).normalized;

//            var forceDirectionAngle = Mathf.Atan2(-forceDirection.y, -forceDirection.x)*Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, toMouseQuaternion, 0.5f);

            rigidbody2D.AddForce(forceDirection * ForceMagnitude);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0,1000));
            }
        }
    }
}