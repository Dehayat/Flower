using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FL
{
    public struct lineControlData
    {
        public LineView lineView;
    }

    public class LineController : MonoBehaviour
    {
        public LineView[] lineViews;
        public float lineSpeed = 30f;
        public float startXPosition = 1000;

        private int currentLineView = 0;
        public lineControlData ShowLine(string staticText, string dynamicText)
        {
            currentLineView++;
            if (currentLineView >= lineViews.Length)
            {
                currentLineView = 0;
            }
            var lineView = lineViews[currentLineView];

            lineView.SetText(staticText, dynamicText);
            lineView.SetSpeed(lineSpeed);

            lineControlData data;
            data.lineView = lineView;

            var rectTransform = lineView.GetComponent<RectTransform>();
            var position = rectTransform.anchoredPosition;
            position.x = startXPosition;
            rectTransform.anchoredPosition = position;

            return data;
        }

        public void UpdateLine(lineControlData currentLineControl, string staticText, string dynamicText)
        {
            var lineView = currentLineControl.lineView;

            lineView.SetText(staticText, dynamicText);
        }
    }
}