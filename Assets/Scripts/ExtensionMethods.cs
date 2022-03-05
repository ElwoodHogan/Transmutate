using UnityEngine;
using System.Collections.Generic;

public static class ExtensionMethods
{
    public static Vector3 XZ(this Vector3 v3)
    {
        return new Vector2(v3.x, v3.z);
    }

    public static Vector3 Abs(this Vector3 v3)
    {
        return new Vector3(Mathf.Abs(v3.x), Mathf.Abs(v3.y), Mathf.Abs(v3.z));
    }

    public static int Bool2Int(this bool b)
    {
        return b ? 1 : 0;
    }

    public static Vector3 Change(this Vector3 pos, float x, float y, float z)
    {
        return pos + new Vector3(x, y, z);
    }

    public static Vector3 SetZ(this Vector3 pos, float z)
    {
        return new Vector3(pos.x, pos.y, z);
    }
    public static Vector2 Change(this Vector2 pos, float x, float y)
    {
        return pos + new Vector2(x, y);
    }
    public static Vector2 Change(this Vector2Int pos, float x, float y)
    {
        return pos + new Vector2(x, y);
    }
    public static Vector2Int IntChange(this Vector2Int pos, int x, int y)
    {
        return pos + new Vector2Int(x, y);
    }

    public static T RandomPicker<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static int ToInt(this bool b)
    {
        return b ? 1 : 0;
    }

    public static Vector3Int Floor(this Vector3 v)
    {
        return new Vector3Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), 0);
    }

    public static bool FInRange(this float x, float incBottom, float incTop)
    {
        return (x >= incBottom && x <= incTop);
    }

    public static bool IInRange(this int x, float incBottom, float incTop)
    {
        return (x >= incBottom && x <= incTop);
    }

    public static Vector2 V3toV2(this Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }

    public static Vector3 V2toV3(this Vector2Int v2, float z)
    {
        return new Vector3(v2.x, v2.y, z);
    }

    public static Vector2Int V3toV2Int(this Vector3Int v3)
    {
        return new Vector2Int(v3.x, v3.y);
    }

    public static Vector3 V2toV3(this Vector2 v2, float z)
    {
        return new Vector3(v2.x, v2.y, z);
    }

    public static Vector3 V2IntToV3(this Vector2Int v2)
    {
        return new Vector3(v2.x, v2.y, 0);
    }

    public static Vector2 LerpByDistance(Vector2 A, Vector2 B, float x)
    {
        Vector2 P = x * (B - A).normalized + A;
        return P;
    }

    public static Vector2 Absolute(this Vector2 vect)
    {
        return new Vector2(Mathf.Abs(vect.x), Mathf.Abs(vect.y));
    }

    public static Vector2Int Floor(this Vector2 vect)
    {
        return new Vector2Int(Mathf.FloorToInt(vect.x), Mathf.FloorToInt(vect.y));
    }

    public static Vector2Int Wrap(this Vector2Int input, int rightwardMovement, int upwardMovement, int widthLimit, int heightLimit)
    {
        Vector2Int v = input.IntChange(rightwardMovement, upwardMovement);
        if (v.x < 0) v.x = widthLimit + v.x;
        if (v.x > widthLimit) v.x = v.x - widthLimit;
        if (v.y < 0) v.x = heightLimit + v.y;
        if (v.x > heightLimit) v.x = v.x - heightLimit;
        return v;
    }
}
