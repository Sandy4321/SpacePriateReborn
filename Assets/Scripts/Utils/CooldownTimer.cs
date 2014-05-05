using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class CooldownTimer {

        private readonly float CooldownDuration;
        private float CooldownStartTime = -1337;

        public CooldownTimer(float cooldownDurationInSeconds)
        {
            CooldownDuration = cooldownDurationInSeconds;
        }

        public void StartCooldown()
        {
            CooldownStartTime = Time.time;
        }

        public bool IsNotOnCooldown()
        {
            return Time.time - CooldownStartTime > CooldownDuration;
        }
    }
}