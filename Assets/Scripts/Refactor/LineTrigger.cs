using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FL
{
    public class LineTrigger : MonoBehaviour
    {
        public Line line;
        public bool showLine = true;
        public bool setActive = false;
        public bool saveLine = false;

        private LineManager lineManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (showLine)
            {
                lineManager.ShowLine(line);
            }
            if (setActive)
            {
                lineManager.ActivateLine(line);
            }
            if (saveLine)
            {
                lineManager.SaveLine(line);
            }
        }

        public void Init(LineManager lineManager)
        {
            this.lineManager = lineManager;
        }
    }
}