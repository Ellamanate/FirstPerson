using UnityEngine;

using MainGame.Environment;

namespace MainGame.PlayerModule.Sensors
{
    public class ItemsDetector : TriggerDetector<Item>
    {
        public bool TryGetNeraest(out Item nearest)
        {
            if (AvailableObjects.Count == 0)
            {
                nearest = null;
                return false;
            }

            nearest = AvailableObjects[0];

            if (AvailableObjects.Count == 1) return true;

            var minDistance = GetDistance(nearest.transform);

            foreach (var item in AvailableObjects)
            {
                var distance = GetDistance(item.transform);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = item;
                }
            }

            return true;
        }

        private float GetDistance(Transform item)
        {
            return Vector3.Distance(item.position, transform.position);
        }
    }
}