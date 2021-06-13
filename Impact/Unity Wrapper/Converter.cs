using Impact;
using UnityEngine;

public class Converter
{
    public static Vector3 ConvertVector(IVector3 v)
    {
        return new Vector3((float)v.X, (float)v.Y, (float)v.Z);
    }

    public static IVector3 ConvertVector(Vector3 v)
    {
        return new IVector3(v.x, v.y, v.z);
    }
}
