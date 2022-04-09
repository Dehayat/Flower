using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace FL
{
    public class LineGenerator : MonoBehaviour
    {
        public Line l;
        public Flower f;

        public string preOptionStatic;
        public string postOptionStatic;

        public string preLineDynamic;
        public string postLineDynamic;

        public string preOptionDynamic;
        public string postOptionDynamic;

        public string GenerateLine(Line line)
        {
            Flower flower = line.GetCurrentFlower();
            string text = line.text;
            if (flower != null)
            {
                Regex optionsRegex = new Regex(RegexData.GetInstance().optionRegex);
                var matches = optionsRegex.Matches(line.text);
                if (matches.Count != flower.words.Length)
                {
                    Debug.LogError("line options in " + line + " do not match word count in flower " + flower);
                    return null;
                }
                for (int i = 0; i < matches.Count; i++)
                {
                    text = optionsRegex.Replace(text, flower.words[i], 1);
                }
            }
            return text;
        }

        public string GenerateLineStatic(Line line)
        {
            string text = line.text;
            Flower flower = line.GetCurrentFlower();
            if (flower != null)
            {
                Regex optionsRegex = new Regex(RegexData.GetInstance().optionRegex);
                var matches = optionsRegex.Matches(line.text);
                if (matches.Count != flower.words.Length)
                {
                    Debug.LogError("line options in " + line + " do not match word count in flower " + flower);
                    return null;
                }
                for (int i = 0; i < matches.Count; i++)
                {
                    text = optionsRegex.Replace(text, preOptionStatic + flower.words[i] + postOptionStatic, 1);
                }
            }
            return text;
        }
        public string GenerateLineDynamic(Line line)
        {
            string text = preLineDynamic + line.text + postLineDynamic;
            Flower flower = line.GetCurrentFlower();

            if (flower != null)
            {
                Regex optionsRegex = new Regex(RegexData.GetInstance().optionRegex);
                var matches = optionsRegex.Matches(line.text);
                if (matches.Count != flower.words.Length)
                {
                    Debug.LogError("line options in " + line + " do not match word count in flower " + flower);
                    return null;
                }
                for (int i = 0; i < matches.Count; i++)
                {
                    text = optionsRegex.Replace(text, postLineDynamic + preOptionDynamic + flower.words[i] + postOptionDynamic + preLineDynamic, 1);
                }

                Regex colorRegex = new Regex(RegexData.GetInstance().colorRegex);
                text = colorRegex.Replace(text, flower.GetColor());
            }
            return text;
        }
    }
}