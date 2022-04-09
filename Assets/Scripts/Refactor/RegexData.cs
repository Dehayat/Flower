using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FL
{
    public class RegexData : MonoBehaviour
    {
        private static RegexData instance;
        public static RegexData GetInstance()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RegexData>();
            }
            return instance;
        }
        public string optionRegex = @"{option}";
        public string colorRegex = @"{color}";
    }
}