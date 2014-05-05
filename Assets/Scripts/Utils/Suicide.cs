using UnityEngine;

namespace Assets.Scripts.Utils
{
    internal class Suicide : MonoBehaviour
    {
        public int LifetimeInSeconds = 5;

        private void Start()
        {
            Invoke("CommitSuicide", LifetimeInSeconds);
        }

        private void CommitSuicide()
        {
            Destroy(gameObject);
        }
    }
}