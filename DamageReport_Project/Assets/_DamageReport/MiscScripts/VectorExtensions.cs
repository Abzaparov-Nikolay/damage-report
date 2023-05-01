using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 Xy(this Vector3 vector3) => new(vector3.x, vector3.y);
    public static void Xy(this ref Vector3 vector3, float x, float y)
        => vector3 = new(x, y, vector3.z);
    public static void Xy(this ref Vector3 vector3, Vector2 vector2)
        => vector3 = new(vector2.x, vector2.y, vector3.z);

    public static Vector2 Xz(this Vector3 vector3) => new(vector3.x, vector3.z);
    public static void Xz(this ref Vector3 vector3, float x, float z)
        => vector3 = new(x, vector3.y, z);
    public static void Xz(this ref Vector3 vector3, Vector2 vector2)
        => vector3 = new(vector2.x, vector3.y, vector2.y);

    public static Vector2 Yz(this Vector3 vector3) => new(vector3.y, vector3.z);
    public static void Yz(this ref Vector3 vector3, float y, float z)
        => vector3 = new(vector3.x, y, z);
    public static void Yz(this ref Vector3 vector3, Vector2 vector2)
        => vector3 = new(vector3.x, vector2.x, vector2.y);

    public static Vector3 ToXy(this Vector2 vector) => new(vector.x, vector.y);
    public static Vector3 ToXz(this Vector2 vector) => new(vector.x, 0, vector.y);
    public static Vector3 ToYz(this Vector2 vector) => new(0, vector.x, vector.y);


    /// <summary>
    /// In degrees.
    /// </summary>
    public static float Angle(this Vector2 vector) => Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

    /// <param name="angle">In degrees.</param>
    public static Vector2 Rotate(this Vector2 vector, float angle)
    {
        var newAngle = vector.Angle() + angle;
        var magnitude = vector.magnitude;
        vector.x = magnitude * Mathf.Cos(newAngle * Mathf.Deg2Rad);
        vector.y = magnitude * Mathf.Sin(newAngle * Mathf.Deg2Rad);
        return vector;
    }
}

