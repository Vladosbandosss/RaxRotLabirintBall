﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLcontroller : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
