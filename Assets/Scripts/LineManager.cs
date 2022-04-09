using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
    public static LineManager instance;

    public Line[] lines;
    public float startPosition = 100;

    [Header("Tech Shit")]
    public LineUI[] linesUI;

    public Player player;

    public string preOptionStatic;
    public string postOptionStatic;

    public string preLineDynamic;
    public string postLineDynamic;

    public string preOptionDynamic;
    public string postOptionDynamic;

    public string optionRegex = @"{option}";
    public string colorRegex = @"{color}";

    private Line currentLine;
    private int currentUIIndex = -1;

    private void Awake()
    {
        instance = this;
    }
    private Option savedOption;
    public void ChangeOption(Option option)
    {
        StartChange();
        savedOption = option;
    }

    private void StartChange()
    {
        player.isMoving = false;
        foreach (var lineUI in linesUI)
        {
            lineUI.isMoving = false;
        }
        linesUI[currentUIIndex].PlayChangeAnim();
    }

    public void DoChangeOption()
    {
        var option = savedOption;
        string dialog = currentLine.text;
        Regex findDefault = new Regex(optionRegex);
        string optionColor = preOptionDynamic;
        Regex findColor = new Regex(colorRegex);
        optionColor = findColor.Replace(optionColor, option.GetColor());
        linesUI[currentUIIndex].SetText(
            findDefault.Replace(dialog, preOptionStatic + option.option + postOptionStatic),
            preLineDynamic + findDefault.Replace(dialog, postLineDynamic + optionColor + option.option + postOptionDynamic + preLineDynamic) + postLineDynamic
            );
        savedOption = null;
    }
    public void EndChange()
    {
        player.isMoving = true;
        foreach (var lineUI in linesUI)
        {
            lineUI.isMoving = true;
        }
    }


    public void ChangeLine(Line line)
    {
        float lastEndPosition = startPosition;
        //if (currentUIIndex != -1)
        //{
        //    lastEndPosition = linesUI[currentUIIndex].GetEndPosition();
        //}

        currentUIIndex++;
        if (currentUIIndex >= linesUI.Length)
        {
            currentUIIndex = 0;
        }

        currentLine = line;
        instance = this;
        string dialog = currentLine.text;
        Regex findDefault = new Regex(@"{option}");
        var match = findDefault.Match(dialog);
        //staticText.text = findDefault.Replace(dialog, preOptionStatic + lines[0].defaultOption + postOptionStatic);
        string optionColor = preOptionDynamic;
        Regex findColor = new Regex(@"{color}");
        optionColor = findColor.Replace(optionColor, currentLine.GetDefaultColor());
        //dynamicText.text = preLineDynamic + findDefault.Replace(dialog, postLineDynamic + optionColor + currentLine.defaultOption + postOptionDynamic + preLineDynamic) + postLineDynamic;
        linesUI[currentUIIndex].SetText(
            findDefault.Replace(dialog, preOptionStatic + currentLine.defaultOption + postOptionStatic),
            preLineDynamic + findDefault.Replace(dialog, postLineDynamic + optionColor + currentLine.defaultOption + postOptionDynamic + preLineDynamic) + postLineDynamic
            );
        linesUI[currentUIIndex].SetStartPosition(lastEndPosition);
    }
}
