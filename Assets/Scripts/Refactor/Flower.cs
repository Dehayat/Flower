using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FL
{
    public class Flower : MonoBehaviour
    {
        public string[] words;
        public Color color;

        private LineManager lineManager;

        public string GetColor()
        {
            return ColorUtility.ToHtmlStringRGB(color);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            lineManager.ChooseFlower(this);
        }

        public void Init(LineManager lineManager)
        {
            this.lineManager = lineManager;
        }
    }
}