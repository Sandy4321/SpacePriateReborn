using UnityEngine;

public class PlayerLifecycle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            KillPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}