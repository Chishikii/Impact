using Impact;
using UnityEngine;

public class Converter
{
    public static Vector3 ConvertVector(IVector3 v)
    {
        return new Vector3((float)v.x, (float)v.y, (float)v.z);
    }

    public static IVector3 ConvertVector(Vector3 v)
    {
        return new IVector3(v.x, v.y, v.z);
    }
}
