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

        public Action done;

        private float moveSpeed = 0;

        private string st, dy;
        internal void SetText(string staticDialogue, string dynamicDialogue)
        {
            staticText.text = staticDialogue;
            dynamicText.text = dynamicDialogue;
        }
        internal void SetText2(string staticDialogue, string dynamicDialogue)
        {
            this.st = staticDialogue;
            this.dy = dynamicDialogue;
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

        public void PlayChangeAnim()
        {
            GetComponent<Animator>().Play("ChangeOptionLoop");
        }


        public void DoChangeOption()
        {
            UpdateText();
            //LineManager.instance.DoChangeOption();
        }

        private void UpdateText()
        {
            staticText.text = st;
            dynamicText.text = dy;
        }

        public void EndChangeOption()
        {
            //LineManager.instance.EndChange();
            done?.Invoke();
        }

        public void PlayShake()
        {
            PlayChangeAnim();
        }
    }
}