using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Start()
    {
        if (BlackScreen.instance != null)
        {
            BlackScreen.instance.FadeFromBlack();
        }
    }
}
