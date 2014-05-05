using Assets.Scripts.Abilities;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public GameObject ExplosionPartical;
    public float ExplotionForce = 5;
    public int NumberOfParticals = 5;

    private void SpawnExplosionParticals()
    {
        for (int count = 0; count < NumberOfParticals; count++)
        {
            var partical = Instantiate(ExplosionPartical, transform.position, new Quaternion()) as GameObject;

            if (partical != null)
            {
                partical.rigidbody2D.AddForce(Random.insideUnitCircle*ExplotionForce);
            }
        }
    }
}