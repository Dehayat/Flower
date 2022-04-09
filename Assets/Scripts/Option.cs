using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public string option;
    public Color color;
    public Line line;

    public string GetColor()
    {
        return ColorUtility.ToHtmlStringRGB(color);
    }
}
