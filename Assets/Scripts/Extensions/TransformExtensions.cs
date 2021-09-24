using UnityEngine;

namespace Extensions.Transform
{
    public static class TransformExtensions
    {
        public static Vector3 GetRandomPoint(this Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        public static Vector3 ChangeY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 ChangeX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Quaternion OnlyY(this Quaternion rotation)
        {
            return new Quaternion(rotation.x, 0, rotation.z, rotation.w);
        }
    }
}
