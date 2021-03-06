using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CsharpUtil {
    private static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0);

    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action) {
        foreach (var item in enumerable)
            action(item);
    }

    public static long CurrentTimeMillis() {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public static long CurrentTimeNanos() {
        return (long)((DateTime.UtcNow - EPOCH).TotalMilliseconds * 1000000.0);
    }

    public static T Last<T>(this T[] array) {
        return array[array.Length - 1];
    }

    public static Vector2 ToVector2DroppingY(this Vector3 vector3) {
        return new Vector2(vector3.x, vector3.z);
    }

    public static Vector3 ZeroY(this Vector3 vector3) {
        return new Vector3(vector3.x, 0, vector3.z);
    }

    public static string ToDetailedString(this Vector3 vector3) {
        return $"({vector3.x}, {vector3.y}, {vector3.z})";
    }

    public static float normalized(this float thisFloat) {
        if (Mathf.Approximately(thisFloat, 0)) return 0f;
        if (thisFloat < 0) return -1;
        return 1;
    }

    public static bool isAboutZero(this float thisFloat) {
        return Mathf.Approximately(0, thisFloat);
    }

    public static string FormatAsPercent(this float thisFloat) {
        return string.Format("{0:P1}", thisFloat);
    }

    public static void SafeInvoke<T>(this Action<T> action, T arg) {
        if (action != null) action(arg);
    }

    public static void SafeInvoke<T, U>(this Action<T, U> action, T arg1, U arg2) {
        if (action != null) action(arg1, arg2);
    }
}
