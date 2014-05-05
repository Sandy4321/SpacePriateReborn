using System.Runtime.Serialization.Formatters;
using Assets.Scripts.Abilities;
using Assets.Scripts.ExtensionMethods;
using UnityEngine;

public class PushSwitch : MonoBehaviour
{
    public GameObject ControlableDevice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       ControlableDevice.GetSafeInterface<IActivateable>().Activate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var deactivateableDevice = ControlableDevice.GetInterface<IDeactivateable>();
        if (deactivateableDevice != null)
        {
            deactivateableDevice.Deactivate();  
        }
    }
}
