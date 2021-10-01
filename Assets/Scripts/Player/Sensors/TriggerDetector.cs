using System.Collections.Generic;

using UnityEngine;

using Utils;

namespace MainGame.PlayerModule.Sensors
{
    public class TriggerDetector<T> : MonoBehaviour
    {
        protected List<T> AvailableObjects = new List<T>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T obj) && !AvailableObjects.Contains(obj))
            {
                ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

                AvailableObjects.Add(obj);

                OnAvailableEnter(obj);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T obj))
            {
                ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

                AvailableObjects.Remove(obj);

                OnAvailableExit(obj);
            }
        }

        protected virtual void OnAvailableEnter(T obj) { }
        protected virtual void OnAvailableExit(T obj) { }
    }
}