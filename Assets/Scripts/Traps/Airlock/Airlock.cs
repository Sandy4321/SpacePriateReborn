using Assets.Scripts.Abilities;
using Assets.Scripts.Behaviours;
using Assets.Scripts.ExtensionMethods;
using UnityEngine;

public class Airlock : MonoBehaviour, IToggleable
{
    public float CooldownDurationInSeconds = 10f;

    private Animator AirlockAnimator;
    private CooldownTimer CooldownTimer;

    private void Start()
    {
        AirlockAnimator = gameObject.GetSafeComponent<Animator>();
        CooldownTimer = new CooldownTimer(CooldownDurationInSeconds);
    }

    public void Activate()
    {
        if (CooldownTimer.IsNotOnCooldown())
        {
            AirlockAnimator.SetTrigger(AnimationConstants.Activate);
            CooldownTimer.StartCooldown();
        }
    }

    public void Deactivate()
    {
        AirlockAnimator.SetTrigger(AnimationConstants.Deactivate);
    }
}