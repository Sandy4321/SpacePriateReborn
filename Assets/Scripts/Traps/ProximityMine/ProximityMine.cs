using Assets.Scripts.Abilities;
using Assets.Scripts.ExtensionMethods;
using UnityEngine;

/**
 * Animator avtivates an explotion on last frame. 
 */

public class ProximityMine : MonoBehaviour, IActivateable
{
    public float CooldownDurationInSeconds = 2;

    private CooldownTimer CooldownTimer;
    private Animator ExplosionAnimator;

    public void Activate()
    {
        StartExplosion();
    }

    private void Start()
    {
        ExplosionAnimator = gameObject.GetSafeComponent<Animator>();
        CooldownTimer = new CooldownTimer(CooldownDurationInSeconds);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartExplosion();
    }

    private void StartExplosion()
    {
        if (CooldownTimer.IsNotOnCooldown())
        {
            ExplosionAnimator.SetTrigger(AnimationConstants.Activate);
            CooldownTimer.StartCooldown();
        }
    }
}