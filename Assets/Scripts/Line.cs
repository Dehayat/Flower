using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [TextArea]
    public string text;
    public string defaultOption;
    public Color defaultColor;
    public Option[] options;

    public string GetDefaultColor()
    {
        return ColorUtility.ToHtmlStringRGB(defaultColor);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (options != null)
        {
            foreach (var option in options)
            {
                option.line = this;
            }
        }
    }
#endif
}
