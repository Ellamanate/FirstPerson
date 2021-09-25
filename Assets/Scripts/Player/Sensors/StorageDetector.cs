using Environment;

namespace Player.Sensors
{
    public class StorageDetector : TriggerDetector<ItemsStorage>
    {
        public bool TryGetStorage(out ItemsStorage storage)
        {
            if (AvailableObjects.Count != 0)
            {
                storage = AvailableObjects[0];

                return true;
            }

            storage = null;

            return false;
        }
    }
}