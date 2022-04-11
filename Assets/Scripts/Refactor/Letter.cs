using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FL
{
    public class Letter : MonoBehaviour
    {

        public GameObject letterGO;
        public Text letterText;

        internal void Show(string finalText)
        {
            letterText.text = finalText;
            letterGO.SetActive(true);
        }
    }
}