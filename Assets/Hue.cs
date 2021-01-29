using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hue : MonoBehaviour
{
    public static Color white = Color.HSVToRGB(0 / 360f, 0f, 1f);
    public static Color red = Color.HSVToRGB(0 / 360f, 0.9f, 0.9f);
    public static Color green = Color.HSVToRGB(120 / 360f, 0.9f, 0.9f);
    public static Color cyan = Color.HSVToRGB(180 / 360f, 0.9f, 0.9f);
    public static Color magenta = Color.HSVToRGB(300 / 360f, 0.9f, 0.9f);
}
