using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ScreenFixedResolution : MonoBehaviour
{
    public static void SetFixedResolution()
    {
        Screen.SetResolution(1080, 1920, true);
        FindObjectsOfType<Canvas>().ToList().ForEach(canvas => canvas.renderMode = RenderMode.ScreenSpaceCamera);
        FindObjectsOfType<Canvas>().ToList().ForEach(canvas => canvas.worldCamera = Camera.main);
    }
}