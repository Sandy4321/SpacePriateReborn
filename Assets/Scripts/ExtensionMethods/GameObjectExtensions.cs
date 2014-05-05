using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ExtensionMethods
{
    internal static class GameObjectExtensions
    {
        public static T GetSafeComponent<T>(this GameObject obj) where T : Component
        {
            var component = obj.GetComponent<T>();

            if (component == null)
            {
                Debug.LogError("Expected to find component of type " + typeof (T) + " but found none", obj);
            }

            return component;
        }

        public static T GetInterface<T>(this GameObject obj) where T : class
        {
            if (!typeof (T).IsInterface)
            {
                Debug.LogError(typeof (T) + ": is not an actual interface!");
                return null;
            }

            return obj.GetComponents<Component>().OfType<T>().FirstOrDefault();
        }

        public static T GetSafeInterface<T>(this GameObject obj) where T : class
        {
            var requestedInterface = GetInterface<T>(obj);

            if (requestedInterface == null)
            {
                Debug.LogError("Expected to find interface of type " + typeof (T) + " but found none", obj);
            }

            return requestedInterface;
        }

        public static IEnumerable<T> GetInterfaces<T>(this GameObject obj) where T : class
        {
            if (!typeof (T).IsInterface)
            {
                Debug.LogError(typeof (T) + ": is not an actual interface!");
                return Enumerable.Empty<T>();
            }

            return obj.GetComponents<Component>().OfType<T>();
        }
    }
}