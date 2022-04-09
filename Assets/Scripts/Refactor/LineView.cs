using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FL
{
    public class LineView : MonoBehaviour
    {

        [Header("Tech shit")]
        public Text staticText;
        public Text dynamicText;

        private float moveSpeed = 0;

        internal void SetText(string staticDialogue, string dynamicDialogue)
        {
            staticText.text = staticDialogue;
            dynamicText.text = dynamicDialogue;
        }

        private void Update()
        {
            var pos = transform.position;
            pos.x += moveSpeed * Time.deltaTime;
            transform.position = pos;
        }

        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }
    }
}