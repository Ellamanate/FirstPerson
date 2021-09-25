using System.Collections.Generic;

using UnityEngine;

namespace Player.Sensors
{
    public class TriggerDetector<T> : MonoBehaviour
    {
        [SerializeField] protected List<T> AvailableObjects = new List<T>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T obj) && !AvailableObjects.Contains(obj))
            {
                AvailableObjects.Add(obj);

                OnAvailableEnter(obj);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T obj))
            {
                AvailableObjects.Remove(obj);

                OnAvailableExit(obj);
            }
        }

        protected virtual void OnAvailableEnter(T obj) { }
        protected virtual void OnAvailableExit(T obj) { }
    }
}