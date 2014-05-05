using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
    }
}