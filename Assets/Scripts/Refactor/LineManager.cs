using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FL
{
    public class LineManager : MonoBehaviour
    {
        public LineController lineController;
        public LineGenerator lineGenerator;
        public Letter letter;

        private Dictionary<Line, lineControlData> lineControlData = new Dictionary<Line, lineControlData>();
        private Line currentLine;
        private lineControlData currentLineControl;

        private string finalText = "";

        internal void FinishGame()
        {
            letter.Show(finalText);
            lineController.StopLines();
        }

        private void Awake()
        {
            var lineTriggers = FindObjectsOfType<LineTrigger>();
            foreach (var trigger in lineTriggers)
            {
                trigger.Init(this);
            }
            var flowers = FindObjectsOfType<Flower>();
            foreach (var flower in flowers)
            {
                flower.Init(this);
            }
            FindObjectOfType<MailBox>().Init(this);
        }

        public void SaveLine(Line line)
        {
            finalText += lineGenerator.GenerateLine(line);
            if (line.newLine)
            {
                finalText += "\n";
            }
        }

        public void ShowLine(Line line)
        {
            var lineData = lineController.ShowLine(lineGenerator.GenerateLineStatic(line), lineGenerator.GenerateLineDynamic(line));
            lineControlData.Add(line, lineData);
        }

        public void ActivateLine(Line line)
        {
            currentLine = line;
            currentLineControl = lineControlData[line];
            lineControlData.Remove(line);
        }

        public void ChooseFlower(Flower flower)
        {
            currentLine.SetCurrentFlower(flower);
            lineController.UpdateLine(currentLineControl, lineGenerator.GenerateLineStatic(currentLine), lineGenerator.GenerateLineDynamic(currentLine));
        }

    }
}