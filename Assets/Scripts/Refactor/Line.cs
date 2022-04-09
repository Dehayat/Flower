using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FL
{
    public class Line : MonoBehaviour
    {
        [TextArea]
        public string text;
        public Flower defaultFlower;

        private Flower currentFlower;

        private void Awake()
        {
            SetCurrentFlower(defaultFlower);
        }

        public void SetCurrentFlower(Flower flower)
        {
            currentFlower = flower;
        }

        public Flower GetCurrentFlower()
        {
            return currentFlower;
        }
    }
}