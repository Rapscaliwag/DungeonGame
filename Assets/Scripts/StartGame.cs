﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{

    public void StartTheGame (string changeSceneTo)
    {
        Application.LoadLevel(changeSceneTo);
    }
}
