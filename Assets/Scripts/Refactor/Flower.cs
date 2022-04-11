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
            StartCoroutine(HideFlower());
        }

        IEnumerator HideFlower()
        {
            yield return new WaitForSeconds(0.15f);
            gameObject.SetActive(false);
        }

        public void Init(LineManager lineManager)
        {
            this.lineManager = lineManager;
        }
    }
}